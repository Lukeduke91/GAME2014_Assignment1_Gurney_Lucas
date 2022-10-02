using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    EnemyBehaviour.cs
    Lucas Gurney 
    101313633
    October 2 2022 
    This program Creates a Enemy behaviour that moves left and right 
 */
public class EnemyBehaviour : MonoBehaviour
{
    public Boundary horizontalBoundary;
    public Boundary verticalBoundary;
    public Boundary horizontalSpeedRange;
    public float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        var RandomXPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
        var RandomYPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
        horizontalSpeedRange.min = Random.Range(0.5f, 2.0f);
        horizontalSpeedRange.max = Random.Range(2.0f, 6.0f);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        transform.position = new Vector3(RandomXPosition, RandomYPosition, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalLength = horizontalBoundary.max - horizontalBoundary.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max, 
            transform.position.y, transform.position.z);
    }
}
