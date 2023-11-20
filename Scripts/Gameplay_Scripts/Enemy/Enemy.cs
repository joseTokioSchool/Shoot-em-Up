using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SuperBombController superBombController;
    [SerializeField] private Healthbar healthbar;

    [SerializeField] private float maxLife;
    [SerializeField] float life;

    private void Awake()
    {
        superBombController = FindObjectOfType<SuperBombController>();
    }
    private void Start()
    {
        life = maxLife;
        healthbar.UpdateHealthbar(maxLife, life);
    }

    /*---------------------------------------- DELEGADOS ----------------------------------------*/
    private void OnEnable()
    {
        superBombController.throwMegaBombReleased += AllEnemyDamage;
    }
    private void OnDisable()
    {
        superBombController.throwMegaBombReleased -= AllEnemyDamage;
    }
    public void AllEnemyDamage() // Funci�n para hacer da�o a todo lo que haya en pantalla
    {
        life -= 2;
        healthbar.UpdateHealthbar(maxLife, life); // L�nea de c�digo para actualizar la barra de vida
        if (life <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.ExplosionController(transform.position);

            // AUDIO Y PUNTUACI�N
            AudioManager.AudioInstance.ExplosionClip();
            GameManager.Instance.PlayerScored();

        }
        Debug.Log("Bomba Lanzada");
    }
    /*------------------------------------------------------------------------------------------*/
    public void SmallEnemyDamage(float damage) // Funcion para hacer da�o al enemigo peque�o
    {
        life -= damage;
        healthbar.UpdateHealthbar(maxLife, life); // L�nea de c�digo para actualizar la barra de vida
        if (life <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.ExplosionController(transform.position);

            // AUDIO Y PUNTUACI�N
            AudioManager.AudioInstance.ExplosionClip();
            GameManager.Instance.PlayerScored();

            //Debug.Log("Enemigo peque�o eliminado");
        }
    }
    public void EnemyDamage(float damage) // Funcion para hacer da�o al enemigo grande
    {
        life -= damage;
        healthbar.UpdateHealthbar(maxLife, life); // L�nea de c�digo para actualizar la barra de vida
        if (life <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.ExplosionController(transform.position);

            // AUDIO Y PUNTUACI�N
            AudioManager.AudioInstance.ExplosionClip();
            GameManager.Instance.PlayerScored();

            //Debug.Log("Enemigo grande da�ado");
        }
    }
}
