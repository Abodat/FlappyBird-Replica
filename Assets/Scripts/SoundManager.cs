using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource jumpSounds,pointSounds,gameOverSounds;
    private static SoundManager instance;

    private void Start()
    {
        instance = this;
    }
    
    public static void PlayJumpSound()
    {
        instance.jumpSounds.Play();
    }
    
    public static void PlayPointSound()
    {
        instance.pointSounds.Play();
    }
    
    public static void PlayGameOverSound()
    {
        instance.gameOverSounds.Play();
    }
}
