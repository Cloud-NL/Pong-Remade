using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI score1, score2;
    [Header("Ints")]
    [HideInInspector] public int scorePlayer1 = 0;
    [HideInInspector] public int scorePlayer2 = 0;

    public void AddScore(bool player)
    {
        if(player) // true == player1
        {
            score1.text = string.Format("Score: {0}", scorePlayer1);
        } else // false == player2
        {
            score2.text = string.Format("Score: {0}", scorePlayer2);
        }
    }
}
