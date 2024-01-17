using UnityEngine;
using UnityEngine.UI;

public class MenuSoundFX : MonoBehaviour
{
    public Slider musicVolume;
    public Slider soundFXVolume;
    private void Start()
    {
        musicVolume.value = AudioManager.Instance.musicSource.volume;
        soundFXVolume.value = AudioManager.Instance.soundFXSource.volume;
    }

    public void PlayButtonSound()
	{
		AudioManager.Instance.PlaySoundFX(AudioManager.Instance.buttonClick);
	}

	public void ChangeMusicVolume(float _volume)
	{
		AudioManager.Instance.musicSource.volume = _volume;
	}

    public void ChangeSoundFxVolume(float _volume)
    {
        AudioManager.Instance.soundFXSource.volume = _volume;
    }

}
