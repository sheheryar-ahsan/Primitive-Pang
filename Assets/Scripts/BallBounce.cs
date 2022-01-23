using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    public bool gameStopCheck = false;
    private float speed = 300;
    private float inBound = 3.5f;
    private float topBound = 3.2f;
    private int randomAngle;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BallBound();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && gameStopCheck == false) // On the collision with the Gorund, Up force is being added
        {
            randomAngle = Random.Range(-10, 11);
            ballRigidbody.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse); // Adding force in ball in up direction with a speed
            ballRigidbody.AddForce(Vector3.right * randomAngle * Time.deltaTime, ForceMode.Impulse); // Adding force in ball in left or right direction depending the random number
        }
        else if (collision.gameObject.CompareTag("Player")) // On the collsion of ball with player, game is over by making time scale to zero
        {
            gameStopCheck = true;
            Time.timeScale = 0;
            Debug.Log("Game Over!");
        }
    }

    void BallBound() // To bound the players for moving away from the screen
    {
        if (transform.position.x > inBound)
        {
            ballRigidbody.AddForce(Vector3.right * -5 * Time.deltaTime, ForceMode.Impulse); // On the collision with the left boundary wall ball is add a negative force to puch it away
        }
        else if (transform.position.x < -inBound)
        {
            ballRigidbody.AddForce(Vector3.right * 5 * Time.deltaTime, ForceMode.Impulse); // On the collision with the right boundary wall ball is add a positive force to puch it away
        }
        else if (transform.position.y > topBound) // For bounding the ball no to go away in height
        {
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
        }
    }
}
