using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int coin;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI ScoreText;

    public int highScore;
    public TextMeshProUGUI highScoreText;



    private void Awake()
    {
        //if (Instance == null)
        //{
            Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

        highScore = PlayerPrefs.GetInt("HighScore");
        UpdateTextHighScore();
        
    }
    private void Start()
    {
        //coin = 2;
        
    }

    public void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.SetText(coin.ToString());
            ScoreText.SetText(coin.ToString());
        }
        
    }

    public void UpdateHighScore()
    {
        //Debug.Log("Highscore befor: " + highScore);
        if(coin > highScore)
        {
            highScore = coin;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            //Debug.Log("Highscore after: " + highScore);
           
        }
    }
    public void UpdateTextHighScore()
    {
        
        if (highScoreText != null)
        {
            
             highScoreText.SetText(highScore.ToString());
        }
    }

}
