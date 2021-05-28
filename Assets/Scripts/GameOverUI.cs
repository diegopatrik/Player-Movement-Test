using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private int score;
    public Text scoreText;
    void Start(){
        score = ScoreData.playerScore;
        Debug.Log("GOver Scene");
        Debug.Log(score);
        scoreText.text += "\nPontuação: " +score;
    }
    public void backToMenu (){
        SceneManager.LoadScene("Menu");
    }
}
