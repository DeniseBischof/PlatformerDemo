using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject GameOverUI;
    public GameObject GameTitleUI;

    public bool gameOver = false;

    public int points;
    public Text pointsText;

    GameControllerState GCState;

    AudioSource audioSource;
    public AudioClip title;
    public AudioClip play;
    public AudioClip hurt;


    // Use this for initialization
    void Start () {
        GameOverUI.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        GCState = GameControllerState.Title;
        UpdateGameControllerState();
    }

    public enum GameControllerState
    {
        Title,
        StartGame,
        GamePlay,
        GameOver,
    }

    // Update is called once per frame
    void Update () {

        pointsText.text = ("Points: " + points);

        if (player.transform.position.y < -7)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            Invoke("GameOver", 0.1f);
        }

    }

    void UpdateGameControllerState()
    {
        switch (GCState)
        {

            case GameControllerState.Title:

                Time.timeScale = 0;

                audioSource.clip = title;
                audioSource.Play();

                player.SetActive(false);
                GameTitleUI.SetActive(true);

                Time.timeScale = 0;

                break;

            case GameControllerState.StartGame:

                audioSource.Stop();

                Time.timeScale = 0;

                Invoke("StartGame",0.1f);

                break;

            case GameControllerState.GamePlay:

                GameTitleUI.SetActive(false);
                player.SetActive(true);

                audioSource.clip = play;
                audioSource.Play();


                break; 

            case GameControllerState.GameOver:

                audioSource.Stop();

                audioSource.PlayOneShot(hurt, 0.7F); //Thereza fragen, warum dieser audioclip sich anhört, wie als hätte man das Tor zur Hölle geöffnet

                GameOverUI.SetActive(true);

                Debug.Log("Player has died.");
                points = 0;
                player.SetActive(false);

                gameOver = true;

                break;

        }
    }

    public void SetGameController(GameControllerState state)
    {
        GCState = state;
        UpdateGameControllerState();
    }
    public void StartGameTitle()
    {
        GCState = GameControllerState.Title;
        UpdateGameControllerState();

    }

    public void ResetGameState()
    {

        GCState = GameControllerState.StartGame;
        UpdateGameControllerState();

    }

    public void StartGame()
    {

        GCState = GameControllerState.GamePlay;
        UpdateGameControllerState();

    }

    public void GameOver()
    {

        GCState = GameControllerState.GameOver;
        UpdateGameControllerState();

    }
}
