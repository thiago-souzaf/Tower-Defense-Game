using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Singleton Setup
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion
    [Header("----- Audio Sources -----")]
    public AudioSource musicSource;
    public AudioSource soundFXSource;

    [Header("----- Audio Clips -----")]
    [Header("Music")]
    public AudioClip musicClip;

    [Header("Sound FX")]
    public AudioClip togglePause;
    public AudioClip startRound;
    public AudioClip selectTurret;
    public AudioClip placeTurret;
    public AudioClip upgradeTurret;
    public AudioClip sellTurret;
    public AudioClip hitEnemy;
    public AudioClip collectCoin;
    public AudioClip enemyEndPath;

    public AudioClip winLevel;
    public AudioClip loseLevel;




    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySoundFX(AudioClip clip)
    {
        soundFXSource.PlayOneShot(clip);
    }
    
}
