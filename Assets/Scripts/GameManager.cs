using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public TextMeshProUGUI ScoreText;
    public GameObject gameOverUI;
    public TextMeshProUGUI endScore;
    public int scorePts;

    // Start is called before the first frame update
    void Start()
    {
        scorePts = 0;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("ScoreInc", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == true)
        {
            GameOver(scorePts);
        }
    }

    public void GameOver(int value)
    {
        gameOverUI.SetActive(true);
        endScore.text = value.ToString() + " POINTS";

        // Stop the score from increasing
        CancelInvoke("ScoreInc");
    }

    public void ScoreInc()
    {
        scorePts++;
        ScoreText.text = scorePts.ToString();
    }
}
