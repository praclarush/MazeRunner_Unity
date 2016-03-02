using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public Button PlayButton;
    public Button OptionsButton;
    public Button ScoresButton;
    public Button HelpButton;
    public Button CreditsButton;
    public Button ExitButton;
    
    public AudioClip ButtonEffectAudio;


    void Awake()
    {
        Time.timeScale = 1;
    }

    public void PlayButton_Press()
    {
        StartCoroutine(LoadGameSceneWithAudio());
    }

    public void OptionButton_Press() 
    {
        Debug.Log("Options Menu");
        StartCoroutine( LoadSceneWithAudio("OptionsMenu"));
    }

    public void ScoresButton_Press()
    {
        Debug.Log("Score Screen");
        StartCoroutine(LoadSceneWithAudio("ScoreScreen"));
    }

    public void HelpButton_Press()
    {
        Debug.Log("Help Screen");
        StartCoroutine(LoadSceneWithAudio("HelpScreen"));
    }

    public void CreditsButton_Press()
    {
        Debug.Log("Credits Screen");
        StartCoroutine(LoadSceneWithAudio("CreditsScreen"));
    }

    public void ExitButton_Press()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private IEnumerator LoadGameSceneWithAudio()
    {
        if (ButtonEffectAudio != null)
        {
            AudioSource.PlayClipAtPoint(ButtonEffectAudio, Vector3.zero, Settings.EffectsVolume);
            yield return new WaitForSeconds(ButtonEffectAudio.length);
        }
        else
        {
            Debug.LogError("Could Not Load Button Effect Audio");
        }

        GameWorld.AdvanceLevel();

    }

   private IEnumerator LoadSceneWithAudio(string sceneName)
    {
        if (ButtonEffectAudio != null)
        {            
            AudioSource.PlayClipAtPoint(ButtonEffectAudio, Vector3.zero, Settings.EffectsVolume);
            yield return new WaitForSeconds(ButtonEffectAudio.length);
        }
        else
        {
            Debug.LogError("Could Not Load Button Effect Audio");
        }

        Application.LoadLevel(sceneName);

    }
}
