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
    public void AllEnemyDamage() // Función para hacer daño a todo lo que haya en pantalla
    {
        life -= 2;
        healthbar.UpdateHealthbar(maxLife, life); // Línea de código para actualizar la barra de vida
        if (life <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.ExplosionController(transform.position);

            // AUDIO Y PUNTUACIÓN
            AudioManager.AudioInstance.ExplosionClip();
            GameManager.Instance.PlayerScored();

        }
        Debug.Log("Bomba Lanzada");
    }
    /*------------------------------------------------------------------------------------------*/
    public void SmallEnemyDamage(float damage) // Funcion para hacer daño al enemigo pequeño
    {
        life -= damage;
        healthbar.UpdateHealthbar(maxLife, life); // Línea de código para actualizar la barra de vida
        if (life <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.ExplosionController(transform.position);

            // AUDIO Y PUNTUACIÓN
            AudioManager.AudioInstance.ExplosionClip();
            GameManager.Instance.PlayerScored();

            //Debug.Log("Enemigo pequeño eliminado");
        }
    }
    public void EnemyDamage(float damage) // Funcion para hacer daño al enemigo grande
    {
        life -= damage;
        healthbar.UpdateHealthbar(maxLife, life); // Línea de código para actualizar la barra de vida
        if (life <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.ExplosionController(transform.position);

            // AUDIO Y PUNTUACIÓN
            AudioManager.AudioInstance.ExplosionClip();
            GameManager.Instance.PlayerScored();

            //Debug.Log("Enemigo grande dañado");
        }
    }
}
