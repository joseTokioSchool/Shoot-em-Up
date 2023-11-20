using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_Text scoreRecord;
    [SerializeField] TMP_Text timeRecord;

    private void Update()
    {
        scoreRecord.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        timeRecord.text = "Time: " + PlayerPrefs.GetFloat("Time").ToString("F3");
    }
    public void ChangeScene(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void ExitGame(int n)
    {
        Application.Quit(n);
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
