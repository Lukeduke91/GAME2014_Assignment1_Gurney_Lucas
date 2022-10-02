using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    BackgroundBehaviour.cs
    Lucas Gurney 
    101313633
    October 2 2022 
    This program Makes the background move down and pop back up continuously 
 */
public class BackgroundBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public Boundary boundary;
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed * Time.deltaTime);
    }

    public void CheckBounds()
    {
        if (transform.position.y < boundary.min)
        {
            ResetStars();
        }
    }

    public void ResetStars()
    {
        transform.position = new Vector2(0.0f, boundary.max);
    }
}
