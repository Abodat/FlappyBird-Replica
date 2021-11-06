using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public static Rigidbody2D playerRigidBody;
    private Vector2 screenBounds;
    private Boolean isTriggered = false;
    private float timer = 1.5f;
        
    
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        playerRigidBody.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(playerRigidBody.velocity.y * 30, -45, 45));
    }

    public static void Jump()
    {
        playerRigidBody.AddForce(new Vector2(0f, 100f));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "GameOver")
        {
            GameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered)
        {
            
            return;
        }

        if (other.tag == "Point")
            GameManager.AddScore();
        
        //isTriggered = true;
    }

    
    
}
