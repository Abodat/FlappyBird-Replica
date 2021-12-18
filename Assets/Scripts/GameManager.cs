using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject pipePrefab;
    private float pipeSpawnTimer = 2;
    public static bool isGameOver = false;
    private bool isGamePause = false;
    public GameObject gameOverPanel,gameStartPanel,pauseButton;
    private static GameManager instance;
    private static int score = 0; 
    
    private void Start()
    {
        Time.timeScale = 0;
        instance = this;
    }

    public void StartGame()
    {
        gameStartPanel.SetActive(false);
        Time.timeScale = 1;
        pauseButton.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (pipeSpawnTimer < 0)
        {
            pipeSpawnTimer = 1.5f;
            PipeSpawner();
        }
        else
            pipeSpawnTimer -= Time.fixedDeltaTime;
    }

    public void OnClick()
    {
        PlayerController.Jump();
        SoundManager.PlayJumpSound();
    }
    
    public void PauseButton()
    {
        if (!isGameOver)
        {
            Time.timeScale = (!isGamePause) ? 0 : 1;
            isGamePause = !isGamePause;
        }
    }
    public void RestartGame()
    {
        Application.LoadLevel("SampleScene");
        isGameOver = false;
        score = 0;
        Time.timeScale = 1;
    }

    public static void GameOver()
    {
        instance.gameOverPanel.SetActive(true);
        isGameOver = true;
        SoundManager.PlayGameOverSound();
        GameUIManager.Reward(score);
        Time.timeScale = 0;
    }

    public static void AddScore()
    {
        score++;
        GameUIManager.AddScoreText(score);
        SoundManager.PlayPointSound();
    }

    private void PipeSpawner()
    {
        Instantiate(pipePrefab, new Vector3(PlayerController.playerRigidBody.transform.position.x + 1.8f,Random.Range(-0.20f,0.75f),PlayerController.playerRigidBody.transform.position.z),quaternion.identity);
    }
}
