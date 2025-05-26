using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgMusicSorce;
    public AudioSource sfxSource;

    public AudioClip clickSound;
    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip deleteSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  //  Keeps this object across scenes
        }
        else
        {
            Destroy(gameObject);  // Prevent duplicates
        }
    }

    public void PlayClick()
    {
        sfxSource.PlayOneShot(clickSound);
    }
    public void PlayGoodSound()
    {
        sfxSource.PlayOneShot(goodSound);
    }
    public void PlayBadSound()
    {
        sfxSource.PlayOneShot(badSound);
    }
    public void PlayDeleteSound()
    {
        sfxSource.PlayOneShot(deleteSound);
    }
}
