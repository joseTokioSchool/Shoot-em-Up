using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*--------------------------------------------------- SINGLETONS --------------------------------------------------- */
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    /*------------------------------------------------------------------------------------------------------------------ */

    /*---------------------------------- VARIABLES ----------------------------------*/
    [SerializeField] public TMP_Text playerScoreText;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] ParticleSystem explosion;

    public int playerScored;

    /*---------------------------------- Para aumentar la puntuación del jugador.----------------------------------*/
    public void PlayerScored()
    {
        playerScored++;
        playerScoreText.text = "SCORE: " + playerScored.ToString();

        if (PlayerPrefs.GetInt("Score") <= playerScored)
        {
            PlayerPrefs.SetInt("Score", playerScored);
        }

        //Debug.Log("El record es: " + PlayerPrefs.GetInt("Score"));
    }
    public void ExplosionController(Vector3 obstacle)
    {
        explosion.transform.position = obstacle;
        explosion.Play();
    }

    /*---------------------------------- Para acabar la partida.----------------------------------*/
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameoverPanel.SetActive(true);
    }

    /*---------------------------------- Para reiniciar la partida.----------------------------------*/
    public void RestartGame()
    {
        playerScored = 0;
        playerScoreText.text = playerScored.ToString();

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*---------------------------------- Para ir al Menú Principal.----------------------------------*/
    public void MainMenu(int n)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(n);
    }
}
