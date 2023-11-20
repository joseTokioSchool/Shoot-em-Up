using System.Collections;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    private GameObject[] bullets;

    [SerializeField] int bulletPoolSize;
    int shootNumber = -1;
    void Start()
    {
        bullets = new GameObject[bulletPoolSize];

        for (int i = 0; i < bulletPoolSize; i++)
        {
            bullets[i] = Instantiate(bullet, transform.position, Quaternion.identity);
            bullets[i].SetActive(false);
        }
    }
    public void ShootBullet()
    {
        shootNumber++;
        if (shootNumber >= bulletPoolSize)
        {
            shootNumber = 0;
        }
        bullets[shootNumber].transform.position = transform.position;
        bullets[shootNumber].SetActive(true);
    }
    public IEnumerator ShootBomb()
    {
        shootNumber++;
        if (shootNumber >= bulletPoolSize)
        {
            shootNumber = 0;
        }
        bullets[shootNumber].transform.position = transform.position;
        bullets[shootNumber].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        bullets[shootNumber].SetActive(false);
    }
}
