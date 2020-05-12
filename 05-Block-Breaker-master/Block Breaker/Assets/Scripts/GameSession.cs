using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour {
    public Text Timer;
    public int count;
    public Text Score;
    private float startTime;
    private bool finished = false;

    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    private void Start()
    {
        scoreText.text = currentScore.ToString();
        Score.text = count.ToString();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (finished) return;
        float t = Time.time - startTime;
        Time.timeScale = gameSpeed;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        Timer.text = minutes + ":" + seconds;

	}

    public void Finish()
    {
        finished = true;
        Timer.color = Color.yellow;

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
        count += 10;
        Score.text = count.ToString();

    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            AddToScore();
            setCountText();

        }

    }

    void setCountText()
    {
        Score.text = "Score: " + count.ToString();
    }
}
