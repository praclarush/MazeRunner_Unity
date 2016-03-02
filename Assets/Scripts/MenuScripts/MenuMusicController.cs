using UnityEngine;

public class MenuMusicController : MonoBehaviour {

    private static bool _audioBegin = false;
    private static AudioSource source;


    public void SetVolume(float level)
    {
        if (source != null)
        {
            source.volume = level;
        }
        else
        {
            Debug.LogError("No Audio Source was Found");
        }
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.volume = Settings.MusicVolume;

        if (!_audioBegin)
        {
            source.Play();
            DontDestroyOnLoad(gameObject);
            _audioBegin = true;
        }
    }

    // Update is called once per frame
	void Update () {
        if (Application.loadedLevelName == "GameScreen")
        {
            source.Stop();
            _audioBegin = false;
        }
	}
}
