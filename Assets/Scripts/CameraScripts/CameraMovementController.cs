using UnityEngine;
using System.Collections;

public class CameraMovementController : MonoBehaviour {

    public Transform Target;
    public float Distance = -5;
	void Start () {
        //Target = GameObject.Find("Player").transform;
	}
	
	void Update () {
        if (Target == null)
        {
            Debug.LogError("Unable to find transformable Target");
            Application.Quit();
            return;
        }


        transform.position = Target.position + new Vector3(0, 0, Distance);
        
	}
}
