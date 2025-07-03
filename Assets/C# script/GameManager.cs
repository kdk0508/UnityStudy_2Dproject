using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public GameObject gameOverText;

    private int score;
    private bool gameOver;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("씬에 두 개 이상의 게임매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }
    public void AddScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score;
    }
    public void OnPlayerDead()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
    public bool isGameOver() { return gameOver; }
}
