using UnityEngine;

public class Bullet : MonoBehaviour // Para desactivar el objeto cuando sale de la pantalla o choca con un obstaculo. También se encarga de desactivar el obstaculo.
{
    [SerializeField] float damage;
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Colision de los Obstaculos.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.SetActive(false); // Para desactivar el obstaculo.
            gameObject.SetActive(false); // Para desactivar la bala.
            GameManager.Instance.ExplosionController(collision.transform.position);

            /* AUDIO Y PUNTUACIÓN */
            AudioManager.AudioInstance.ExplosionClip();
            GameManager.Instance.PlayerScored();
            Debug.Log("+1");
        }

        // Colision de los Enemigos
        if (collision.gameObject.CompareTag("SmallEnemy"))
        {
            collision.gameObject.GetComponent<Enemy>().SmallEnemyDamage(damage);
            gameObject.SetActive(false); // Para desactivar la bala.
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().EnemyDamage(damage);
            gameObject.SetActive(false); // Para desactivar la bala.
        }
    }
}
