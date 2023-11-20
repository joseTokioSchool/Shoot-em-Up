using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject panelPause;
    private bool isPaused;
    void Start()
    {
        panelPause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPausePanel();
            UpdateGameState();
        }
    }

    public void UpdateGameState()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            AudioManager.AudioInstance.PauseClip();
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void ShowPausePanel()
    {
        if (!isPaused)
        {
            panelPause.SetActive(true);
        }
        else
        {
            panelPause.SetActive(false);
        }
    }

    public void Continuar()
    {
        panelPause.SetActive(false);
        UpdateGameState();
    }
    public void MainMenu(int n)
    {
        SceneManager.LoadScene(n);
    }
}
