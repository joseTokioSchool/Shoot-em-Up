using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] GameObject player1, player2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log("PowerUP!");

            player1.SetActive(false);
            player2.transform.position = player1.transform.position;
            player2.SetActive(true);
            collision.gameObject.SetActive(false);

            AudioManager.AudioInstance.PowerUpClip();
        }
    }
}
