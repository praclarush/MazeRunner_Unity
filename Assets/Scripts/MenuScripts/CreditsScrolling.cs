using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CreditsScrolling : MonoBehaviour {

    public float ScrollSpeed = 25.0f;
    public bool EnableCrawling = false;
    public TextAsset TextFile;
    private Text _textComponent;
    private GameObject _message;

    void Start () {
        _message = GameObject.Find("Message");

        if (_message != null)
        {
            _message.SetActive(false);
        }
        else 
        {
            Debug.LogError("Cannot find Message Object");
        }

        _textComponent = GetComponent<Text>();

        if (TextFile != null)
        {
            _textComponent.text = TextFile.text;
        }
        else
        {
            _textComponent.text = "Credits:";
            Debug.LogError("Invalid TextAsset");
        }
	}
	
	
	void Update () {
        if (!EnableCrawling)
        {
            return;
        }

        transform.Translate(Vector3.up * Time.deltaTime * ScrollSpeed);
        
        if (gameObject.transform.position.y >1670)
        {
            
            if (_message != null)
            {
                _message.SetActive(true);
            }
            else
            {
                Debug.LogError("Cannot find Message Object");
            }

            EnableCrawling = false;

        }
	}
}
