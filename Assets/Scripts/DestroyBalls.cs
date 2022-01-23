using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalls : MonoBehaviour
{
    private SpawnManager spawnManager;

    void Update()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        spawnManager.newScore++;
        Debug.Log("Score: " + spawnManager.newScore);
        if (collision.gameObject.CompareTag("Ball") == true) // On the rod collsion with big ball
        {
            // Setting the location for the medium ball by getting the big balls destroy location
            spawnManager.spawnLocation1 = new Vector3(collision.gameObject.transform.position.x + 0.4f, collision.gameObject.transform.position.y + 0.2f, collision.gameObject.transform.position.z);
            spawnManager.spawnLocation2 = new Vector3(collision.gameObject.transform.position.x + -0.4f, collision.gameObject.transform.position.y + -0.2f, collision.gameObject.transform.position.z);
            spawnManager.SpawingMediumBall(); // Instantiating medium balls
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("MediumBall") == true) // On the rod collsion with medium ball
        {
            // Setting the location for the small ball by getting the medium balls destroy location
            spawnManager.spawnLocation1 = new Vector3(collision.gameObject.transform.position.x + 0.18f, collision.gameObject.transform.position.y + 0.1f, collision.gameObject.transform.position.z);
            spawnManager.spawnLocation2 = new Vector3(collision.gameObject.transform.position.x + -0.18f, collision.gameObject.transform.position.y + -0.1f, collision.gameObject.transform.position.z);
            spawnManager.SpawingSmallBall(); // Instantiating small balls
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SmallBall") == true) // On the rod collsion with small ball
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            //spawnManager.ballCount++;       // adding more balls limit for spawing more balls to make game difficulty more
            //spawnManager.startBallCount--;  // adding more start balls value for spawing more balls to make game difficulty more
        }
    }
}
