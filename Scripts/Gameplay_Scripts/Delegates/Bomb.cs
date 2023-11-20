using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour // No usado en el juego
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
