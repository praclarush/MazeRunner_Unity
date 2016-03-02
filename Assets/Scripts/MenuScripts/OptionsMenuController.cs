using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour {

    public AudioClip ButtonEffectAudio;

    private float _musicVolume = 0.6f;
    private float _effectsVolume = 0.9f;
    private GameObject _effectsLabel;
    private GameObject _musicLabel;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();
        _effectsLabel = GameObject.Find("EAudioLevelLabel");
        _musicLabel = GameObject.Find("BAudioLevelLabel");
        InitSettings();
    }

    private void InitSettings()
    {
        _musicVolume = Settings.MusicVolume;
        _effectsVolume = Settings.EffectsVolume;

    }

    private void SaveSettings()
    {
        Settings.MusicVolume = _musicVolume;
        Settings.EffectsVolume = _effectsVolume;
    }

    public void DecreaseMusic()
    {
        if (_musicVolume.ToString("#.##") != ".01")
        {
            _musicVolume -= .01f;
            AudioSource.PlayClipAtPoint(ButtonEffectAudio, Vector3.zero, _effectsVolume);
            UpdateAudio();
        }
    }

    public void IncreaseMusic()
    {
        if (_musicVolume.ToString("#.##") != "1")
        {
            _musicVolume += .01f;
            AudioSource.PlayClipAtPoint(ButtonEffectAudio, Vector3.zero, _effectsVolume);
            UpdateAudio();
        }
    }

    public void DecreaseEffects()
    {
        if (_effectsVolume.ToString("#.##") != ".01")
        {
            _effectsVolume -= .01f;
            AudioSource.PlayClipAtPoint(ButtonEffectAudio, Vector3.zero, _effectsVolume);
        }
    }

    public void IncreaseEffects()
    {
        if (_effectsVolume.ToString("#.##") != "1")
        {
            _effectsVolume += .01f;
            AudioSource.PlayClipAtPoint(ButtonEffectAudio, Vector3.zero, _effectsVolume);
        }
    }

    private void UpdateAudio()
    {
        if (_audioSource != null)
        {
            _audioSource.GetComponent<MenuMusicController>().SetVolume(_musicVolume);        
        }
        else
        {
            Debug.LogError("Could Not Find Audio Source");
        }
        
    }


    public void BackButton_Press()
    {
        StartCoroutine(LoadSceneWithAudio("MainMenu"));
    }

    public void ApplyButton_Press()
    {        
        SaveSettings();
        StartCoroutine(LoadSceneWithAudio("MainMenu"));
    }


    private IEnumerator LoadSceneWithAudio(string sceneName)
    {
        if (ButtonEffectAudio != null)
        {            
            AudioSource.PlayClipAtPoint(ButtonEffectAudio, Vector3.zero, _effectsVolume);
            yield return new WaitForSeconds(ButtonEffectAudio.length);
        }
        else
        {
            Debug.LogError("Could Not Load Button Effect Audio");
        }

        Application.LoadLevel(sceneName);

    }
    
	void Update () {
        _effectsLabel.GetComponent<Text>().text = string.Format("{0:##}%", _effectsVolume * 100);
        _musicLabel.GetComponent<Text>().text = string.Format("{0:##}%", _musicVolume * 100);
	}
}
