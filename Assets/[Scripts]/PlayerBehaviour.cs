using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
    PlayerBehaviour.cs
    Lucas Gurney 
    101313633
    October 2 2022 
    This program Helps the player be able to move left and right via Keyboards, or mobile input
 */

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;
    public float verticalSpeed = 10;
    public bool usingMobileInput = false;

    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        usingMobileInput = Application.platform == RuntimePlatform.Android || 
                            Application.platform == RuntimePlatform.IPhonePlayer;
    }
    // Update is called once per frame
    void Update()
    {
        if(usingMobileInput)
        {
            MobileInput();
        }
        else
        {
            ConventionalInput();
        }
        
        Move();
    }

    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * verticalSpeed);
        }
    }

    public void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0.0f, 0.0f);

    }

    public void Move()
    {
        float clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(clampedPosition, verticalPosition);
    }
}
