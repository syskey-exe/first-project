using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var velocity = rb2d.velocity;

        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.5f)
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(KeyCode.S) && transform.position.y > -4.5f)
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0;
        }

        rb2d.velocity = velocity;
    }
}
