using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /*--------------------------------------------------- SINGLETONS --------------------------------------------------- */
    public static AudioManager AudioInstance { get; private set; }

    private void Awake()
    {
        if (AudioInstance != null && AudioInstance != this)
        {
            Destroy(this);
        }
        else
        {
            AudioInstance = this;
        }
    }
    /*------------------------------------------------------------------------------------------------------------------ */

    [SerializeField] AudioSource audioSource;

    [Header("Canvas")]
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] AudioClip pauseClip;

    [Header("Player")]
    [SerializeField] AudioClip shootClip;

    [Header("Items")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] AudioClip powerUpClip;

    public void GameOverClip()
    {
        audioSource.PlayOneShot(gameOverClip);
    }
    public void PauseClip()
    {
        audioSource.PlayOneShot(pauseClip);
    }
    public void ShootClip()
    {
        audioSource.PlayOneShot(shootClip);
    }
    public void ExplosionClip()
    {
        audioSource.PlayOneShot(explosionClip);
    }
    public void PowerUpClip()
    {
        audioSource.PlayOneShot(powerUpClip);
    }
}
