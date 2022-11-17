using UnityEngine;

namespace Controllers
{
    public class BulletController : MonoBehaviour
    {
        public void BulletDestroy()
        {
            Destroy(transform.gameObject);
        }
    }
}