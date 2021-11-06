using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    private Vector2 screenBounds;
    
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left*Time.fixedDeltaTime);
        if (transform.position.x < screenBounds.x * -2f)
        {
            Destroy(gameObject);
        }
    }
}
