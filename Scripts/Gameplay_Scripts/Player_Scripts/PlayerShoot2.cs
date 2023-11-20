using UnityEngine;

public class PlayerShoot2 : MonoBehaviour
{
    [SerializeField] GameObject bulletPoolLeft;
    [SerializeField] GameObject bulletPoolRight;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.AudioInstance.ShootClip();

            bulletPoolLeft.GetComponent<BulletPool>().ShootBullet();
            bulletPoolRight.GetComponent<BulletPool>().ShootBullet();
        }
    }
}
