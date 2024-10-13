using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreBoard;
    public Image medal;
    public Sprite[] medals;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.SetActive(false);
    }

    // Update is called once per frame
    public void ShowScoreBoard(int score)
    {
        scoreBoard.SetActive(true);

        scoreText.text = score.ToString("D4");

        var best = PlayerPrefs.GetInt("HighScore", 0);
        if(score > best)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString("D4");
            medal.sprite = medals[0];
        }
        else
        {
            highScoreText.text = best.ToString("D4");
            medal.sprite = medals[1];
        }
    }
}
