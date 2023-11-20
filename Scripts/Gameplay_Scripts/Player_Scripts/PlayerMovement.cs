using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    float movement;
    float xBound = 8.5f;

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        movement = Input.GetAxisRaw("Horizontal");
        Vector2 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x + movement * speed * Time.deltaTime, -xBound, xBound);
        transform.position = playerPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("SmallEnemy"))
        {
            Debug.Log("GameOver");
            gameObject.SetActive(false);

            AudioManager.AudioInstance.GameOverClip();
            GameManager.Instance.GameOver();
        }
    }
}
