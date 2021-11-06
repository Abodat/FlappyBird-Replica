using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Button buttonImage;
    public Sprite pauseSprite, resumeSprite;
    public TextMeshProUGUI scoreTxt;
    private static GameUIManager instance = new GameUIManager();
    private void Start()
    {
        instance = this;
    }

    public void ChangeButtonStatue()
    {
        if (buttonImage.image.sprite == resumeSprite)
            buttonImage.image.sprite = pauseSprite;
        else
            buttonImage.image.sprite = resumeSprite;
    }

    public static void AddScoreText(int scoreValue)
    {
        instance.scoreTxt.text = scoreValue.ToString();
    }
}
