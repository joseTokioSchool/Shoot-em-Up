using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Score") == false)
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        if (PlayerPrefs.HasKey("Time") == false)
        {
            PlayerPrefs.SetFloat("Time", 0);
        }
    }
}
