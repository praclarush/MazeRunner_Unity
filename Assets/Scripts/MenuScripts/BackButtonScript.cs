using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackButtonScript : MonoBehaviour {

    public Button BackButton;
    public AudioClip ButtonEffectAudio;
    
	void Start () {
        
	}
	
    public void BackButton_Press() {
        StartCoroutine(LoadSceneWithAudio("MainMenu"));
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
