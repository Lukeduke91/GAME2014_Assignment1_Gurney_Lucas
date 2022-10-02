using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
    The
Source file name, Author’s name, Student Number, Date last Modified, Program
description and Revision History
 */

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0.0f, 0.0f);
        float clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(clampedPosition, verticalPosition);
    }
}
