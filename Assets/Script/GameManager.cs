using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject gameCompleteUI;

    void Start()
    {
        gameIsOver = false;
    }

    void Update () {
        if (gameIsOver) return;

		if(PlayerStatus.Lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        gameIsOver = true;
        Debug.Log("Game Over!");

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        gameCompleteUI.SetActive(true);
    }
}
