using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text gameOverText;
    public Text winnerText;
    public Text restartText;

    public static int gameOverID;
    public static bool isGameOver = false;

    Color redPlayerColor = new Color(0.752f, 0.337f, 0.341f);
    Color bluePlayerColor = new Color(0.333f, 0.345f, 0.658f);

    void Start()
    {
        Score_1.score = 0;
        Score_2.score = 0;

        gameOverText.enabled = false;
        winnerText.enabled = false;
        restartText.enabled = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            ShowGameOverText(gameOverID);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGameOver = false;
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    public void ShowGameOverText(int _gameOverID)
    {
        if (_gameOverID == 1)
        {
            winnerText.text = "BLUE WINS";
            winnerText.color = bluePlayerColor;

            gameOverText.enabled = true;
            winnerText.enabled = true;
            restartText.enabled = true;
        }

        if (_gameOverID == 2)
        {
            winnerText.text = "RED WINS";
            winnerText.color = redPlayerColor;

            gameOverText.enabled = true;
            winnerText.enabled = true;
            restartText.enabled = true;
        }
    }

    public static void ToggleScripts(GameObject obj, bool toggle)
    {
        MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = toggle;
        }
    }
}
