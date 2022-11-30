using Data.UnityObject;
using Data.ValueObject;
using Keys;
using Signals;
using UnityEngine;

namespace Controllers.PlayerManager
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables

        [SerializeField] private Rigidbody move;
        [SerializeField] private GameObject idleObj;

        #endregion
        #region Private Variables

        [Header("Data")] private PlayerData _playerData;

        private float _inputSpeed;
        private Vector2 _clamp;
        private Vector3 _joystickInput;
        private Vector3 _resetPos;
        private bool _isTouchingPlayer;
        private bool _station;
        private bool _minigameHelicopter;
        private bool _hyperCasual;

        #endregion
        #endregion

        private void Awake()
        {
            _playerData = GetPlayerData();
            _isTouchingPlayer = false;
            _station = true;
            _hyperCasual = true;
        }
        
        private PlayerData GetPlayerData()
        {
            return Resources.Load<SO_PlayerData>("Data/SO_PlayerData").PlayerData;
        }
        public void HyperCasualMovementController(HorizontalInputParams inputParams)
        {
            _inputSpeed = inputParams.XValue;
            _clamp = inputParams.ClampValues;
        }

        public void CasualMovementController(JoystickInputParams joystickInputParams)
        {
            _joystickInput = joystickInputParams.JoystickMove;
        }

        public void GameChange()
        {
            _hyperCasual = false;
        }

        private void FixedUpdate()
        {
            if (_isTouchingPlayer)
            {
                if (_hyperCasual)
                {
                    if (!_station)
                        HyperCaualMove();
                    else
                        StopMove();
                }
                else
                {
                    if (!_station)
                    {
                        CasualMove();
                    }
                    else
                    {
                        StopMove();
                    }
                }
            }
        }
        
        private void HyperCaualMove()
        {
            move.velocity = new Vector3(_inputSpeed * _playerData.MovementSide, move.velocity.y, _playerData.MoveSpeed);
            move.position = new Vector3(Mathf.Clamp(move.position.x, _clamp.x, _clamp.y), move.position.y, move.position.z);
        }

        private void CasualMove()
        {
            move.velocity = new Vector3(_joystickInput.x * _playerData.MovementSide, move.velocity.y, _joystickInput.z * _playerData.MovementSide);
            if (_joystickInput.x == 0 || _joystickInput.z == 0)
            {
                idleObj.GetComponent<Animator>().ResetTrigger("Runner");
            }
            else
            {
                idleObj.GetComponent<Animator>().ResetTrigger("Idle");
            }
        }

        private void StopMove()
        {
            move.velocity = Vector3.zero;
        }

        public void Station(bool variable)
        {
            _station = variable;
        }

        public void SlowMove(){
            
            switch (_playerData.MoveSpeed)
            {
                case 10:
                    _playerData.MoveSpeed = 3;
                    break;
                case 3:
                    PlayerSignals.Instance.onStackStriking?.Invoke();
                    _playerData.MoveSpeed = 10;
                    break;
            }
        }
        
        public void Play()
        {
            _resetPos = transform.position;
            _isTouchingPlayer = true;
            _station = false;
            PlayerSignals.Instance.onPlayerAnimation?.Invoke("Runner");
        }

        public void Finish()
        {
            _station = true;
        }

        public void Reset()
        {
            transform.position = _resetPos;
            _isTouchingPlayer = false;
            _station = true;
            _hyperCasual = true;
            _playerData.MoveSpeed = 10;
            MinigameSignals.Instance.onSetCamera?.Invoke(transform.gameObject);
        }
    }
}