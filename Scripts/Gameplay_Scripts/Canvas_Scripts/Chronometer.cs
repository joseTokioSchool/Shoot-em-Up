using TMPro;
using UnityEngine;

public class Chronometer : MonoBehaviour
{
    [SerializeField] TMP_Text chronoText;
    public float chronometer;

    void Start()
    {
        chronometer = 0;
    }
    void Update()
    {
        chronometer += Time.deltaTime;
        chronoText.text = "TIME: " + chronometer.ToString("F3");

        if (PlayerPrefs.GetFloat("Time") <= chronometer)
        {
            PlayerPrefs.SetFloat("Time", chronometer);
        }
    }
}
