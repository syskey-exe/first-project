using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    // Variables for the game

    // Variables for the movement speed
    public float xSpeed = 0.01f; // Variable for horizontal speed
    public float ySpeed = 0.01f; // Variable for vertical speed

    // Variables for the direction movement
    private bool xMove = true; // Variable for horizontal direction
    private bool yMove = true; // Variable for vertical direction

    // Variables for the border  
    float xBorder = 6.5f; // Variable for horizontal borders
    float yBorder = 4.5f; // Variable for vertical borders

    int leftPlayerScore;
    int rightPlayerScore;
    public Text scoreTextLP;
    public Text scoreTextRP;

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = 0.05f; // Variable for horizontal speed
        ySpeed = 0.05f; // Variable for vertical speed
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        if (xMove)
        {
            transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - xSpeed, transform.position.y);
        }

        // Check if the ball reaches the horizontal border
        if (transform.position.x >= xBorder)
        {
            // Reverse the horizontal direction

            xMove = false;

            leftPlayerScore ++;
        }
        else if (transform.position.x <= -xBorder)
        {
            // Reverse the horizontal direction
            xMove = true;
            rightPlayerScore ++;
        }

        // Vertical movement
        if (yMove)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + ySpeed);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - ySpeed);
        }

        // Check if the ball reaches the vertical border
        if (transform.position.y >= yBorder)
        {
            // Reverse the vertical direction
            yMove = false;
        }
        else if (transform.position.y <= -yBorder)
        {
            // Reverse the vertical direction
            yMove = true;
        }
        scoreTextLP.text = leftPlayerScore.ToString();
        scoreTextRP.text = rightPlayerScore.ToString();
    }
    
    // OnCollisionEnter2D is called when this collider or rigidbody has begun touching another rigidbody/collider.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("RPaddle") || collision.collider.CompareTag("LPaddle"))
        {
            // Reverse the horizontal direction
            xMove = !xMove;
        }
    }
}