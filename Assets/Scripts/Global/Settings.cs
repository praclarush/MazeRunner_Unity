using UnityEngine;

public static class Settings {

    private static float _audioDefault = 0.6f;

    public static float MusicVolume
    {
        get 
        {
            return PlayerPrefs.GetFloat("MusicVolume", _audioDefault);
        }
        set 
        {
            PlayerPrefs.SetFloat("MusicVolume", value);
        }
    }

    public static float EffectsVolume
    {
        get
        {
            return PlayerPrefs.GetFloat("EffectsVolume", _audioDefault);
        }
        set
        {
            PlayerPrefs.SetFloat("EffectsVolume", value);
        }
    }
}
