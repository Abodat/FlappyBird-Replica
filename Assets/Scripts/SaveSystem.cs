using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
   private int score;

   void Start()
   {
      if (PlayerPrefs.HasKey("score"))
      {
         score = PlayerPrefs.GetInt("score");
         
      }

      else
      {
         PlayerPrefs.SetInt("score",0);
         
      }
   }

   public static void SaveBestScore(int score)
   {
      PlayerPrefs.SetInt("score",score);
   }
}
