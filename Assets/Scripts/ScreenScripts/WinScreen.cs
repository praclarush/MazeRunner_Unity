using UnityEngine;
using System.Collections;

public class GameoverScreen : MonoBehaviour {


    public void QuitButton_Press()
    {
        //TODO(Nathan): Save Score stuff somewhere.
        Application.LoadLevel("MainMenu");
    }

    public void ContinueButton_Press()
    {
        GameWorld.AdvanceLevel();
    }

}
