using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPool;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.AudioInstance.ShootClip();

            bulletPool.GetComponent<BulletPool>().ShootBullet();
        }
    }
}
