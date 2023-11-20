using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBombController : MonoBehaviour
{
    public delegate void ThrowMegaBombDelegate();
    public event ThrowMegaBombDelegate throwMegaBombReleased; // Función implementada en el script Enemy

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (throwMegaBombReleased != null) // Para que no de error si no hay nigún suscriptor.
            {
                throwMegaBombReleased();
            }
        }
    }

}
