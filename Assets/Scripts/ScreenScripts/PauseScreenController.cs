using UnityEngine;
using System.Collections;

public class PauseScreenController : MonoBehaviour {

	public Canvas PauseCanvas;

	void Start () {
	
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideShowPauseScreen();
            
        }
	}

    public void ContinueButton_Press() {
        HideShowPauseScreen();
    }

    public void QuitButton_Press()
    {
        Application.LoadLevel("MainMenu");
    }

    private void HideShowPauseScreen()
    {
        PauseCanvas.enabled = !PauseCanvas.enabled;
        
        Debug.Log("Menu: " + PauseCanvas.enabled);

        if (PauseCanvas.enabled)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
