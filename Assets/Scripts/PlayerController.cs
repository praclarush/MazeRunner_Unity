using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Animator Animator;
    private AudioSource AudioSource;

    public float MovementSpeed = 2;
    public AudioClip PickupAudioClip;
    public AudioClip VictoryAudioClip;
    public AudioClip LoseAudioClip;

    public Text TimerText;
    public Text ScoreText;
    public Text LevelText;

    public Canvas WinCanvas;
    public Canvas GameOverCanvus;

    private Countdown _countDown;

    void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        Animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();

        _countDown = new Countdown(GameWorld.StartingTime);
        _countDown.Start();
        StartCoroutine(UpdateTimerText());

        if (LevelText != null)
        {
            LevelText.text = String.Format("Level: {0}", GameWorld.CurrentLevel);
        }

        if (ScoreText != null)
        {
            ScoreText.text = String.Format("Coins Remaining: {0}/{1}", GameWorld.CurrentCoins, GameWorld.MaxCoins);
        }
    }

    private IEnumerator UpdateTimerText()
    {
        while (!_countDown.IsStopped)
        {
            if (TimerText != null)
            {
                TimerText.text = _countDown.TextTime;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    void FixedUpdate()
    {
        if (GameWorld.GameOver)
        {
            ShowEndScreen();
        }

        _countDown.Update();

        OutOfTime();

        if (!Input.anyKey)
        {
            Animator.speed = 0;
            //Debug.Log("No Button Pushed");
        }


        if (Input.GetKey(KeyCode.W))
        {
            //up
            Animator.speed = 1;
            Animator.SetInteger("Direction", 2);
            transform.Translate(0, MovementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //down
            Animator.speed = 1;
            Animator.SetInteger("Direction", 0);
            transform.Translate(0, -MovementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //left
            Animator.speed = 1;
            Animator.SetInteger("Direction", 3);
            transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //right
            Animator.speed = 1;
            Animator.SetInteger("Direction", 1);
            transform.Translate(-MovementSpeed * Time.deltaTime, 0, 0);
        }
    }

    void ShowEndScreen()
    {
        if (GameWorld.TypeOfVictory == VictoryType.Lose)
        {
            if (AudioSource != null && LoseAudioClip != null)
            {
                AudioSource.PlayOneShot(LoseAudioClip, Settings.MusicVolume);
            }

            if (GameOverCanvus != null)
            {
                Time.timeScale = 0;
                GameOverCanvus.enabled = true;
            }
            else
            {
                Debug.LogError("Could not find Game Over Canvas");
            }
        }
        else if (GameWorld.TypeOfVictory == VictoryType.Win)
        {
            if (WinCanvas != null)
            {
                Time.timeScale = 0;
                WinCanvas.enabled = true;
            }
            else
            {
                Debug.LogError("Could not find Win Canvas");
            }

        }
        else
        {
            Debug.Log("Something went wrong, the player managed to end the game without hitting a end condition");
        }

    }

    void OutOfTime()
    {
        if (_countDown.TimeLeft <= 0.0f)
        {
            Debug.Log("Game Over");
            GameWorld.GameOver = true;
            GameWorld.TypeOfVictory = VictoryType.Lose;
        }
    }

    void UpdatePoints()
    {
        GameWorld.CurrentCoins += GameWorld.PICKUP_WORTH;
        Debug.Log("Current Coins: " + GameWorld.CurrentCoins);

        if (ScoreText != null)
        {
            ScoreText.text = String.Format("Coins Remaining: {0}/{1}", GameWorld.CurrentCoins, GameWorld.MaxCoins);
        }

        if (GameWorld.CurrentCoins >= GameWorld.MaxCoins)
        {
            Debug.Log("Game Over");
            GameWorld.GameOver = true;
            GameWorld.TypeOfVictory = VictoryType.Win;

            if (AudioSource != null && VictoryAudioClip != null)
            {
                AudioSource.PlayOneShot(VictoryAudioClip, Settings.MusicVolume);
            }
        }
    }

    void OnTriggerEnter(Collider value)
    {
        if (value.tag.Equals("Pickup", StringComparison.CurrentCultureIgnoreCase))
        {
            UpdatePoints();

            if (AudioSource != null && PickupAudioClip != null)
            {
                AudioSource.PlayOneShot(PickupAudioClip, Settings.EffectsVolume);
            }

            Destroy(value.gameObject);
        }

    }
}
