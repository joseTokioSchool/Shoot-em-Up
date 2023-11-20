using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float direction; // Positivo para ir hacia arriba, negativo para ir hacia abajo.
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        Vector2 backMove = direction * speed * Time.fixedDeltaTime * transform.up;
        rb.MovePosition(rb.position + backMove);
    }
}
