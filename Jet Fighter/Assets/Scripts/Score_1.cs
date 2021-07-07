using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_1 : MonoBehaviour
{
    public Text scoreText;

    public static int score = 0;

    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
