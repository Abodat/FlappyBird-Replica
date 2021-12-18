using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Button buttonImage;
    public Sprite pauseSprite, resumeSprite;
    private Boolean isPaused = false;
    public Text scoreTxt,currentScoreTxt,bestScoreTxt;
    private static GameUIManager instance;
    public Sprite bronzeSprite,silverSprite,goldSprite;
    public Image reward;
    private int bestScore;
    
    private void Start()
    {
        instance = this;
        bestScore = PlayerPrefs.GetInt("score");
    }

    public void ChangeButtonStatue()
    {
        if(GameManager.isGameOver ) return;

        buttonImage.image.sprite = isPaused ? pauseSprite : resumeSprite;
        isPaused = !isPaused;
    }

    public static void Reward(int score)
    {
        if (score <  instance.bestScore )
            instance.reward.sprite = instance.bronzeSprite;
        
        else if(score == instance.bestScore)
            instance.reward.sprite = instance.silverSprite;

        else if (score > instance.bestScore)
            instance.reward.sprite = instance.goldSprite;
        
        if (score > instance.bestScore)
        {
            SaveSystem.SaveBestScore(score);
            instance.bestScore = score;
        }
        
        instance.currentScoreTxt.text = score.ToString();
        instance.bestScoreTxt.text = instance.bestScore.ToString();

    }

    public static void AddScoreText(int scoreValue)
    {
        instance.scoreTxt.text = scoreValue.ToString();
    }
}
