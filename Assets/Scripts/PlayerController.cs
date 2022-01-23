using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject rodProjectile;
    public float speed = 10f; // Speed of horizontal input
    private float inBound = 3.5f; // Horizontal axis bound of the player
    public float horizontalInput; // Horizontal Input Value
    private Vector3 rodPosition; // For assign position to the rod
    public int spawnCount = 0; // Projectile Spawn times
    private float spawnCurrentTime = 0; // For the spawn time of the projectile
    private float spawnTimeLimit = 1f; // Limit for the next spawn

    void Update()
    {
        PlayerMovment();
        PlayerBound();
        SpawningRod();
    }

    void PlayerMovment() // For the player horizontal movement
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * -speed * Time.deltaTime);
    }

    void PlayerBound() // To bound the players for moving away from the screen
    {
        if (transform.position.x > inBound)  // Bounding the player on + horizontal axis value
        {
            transform.position = new Vector3(inBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -inBound) // Bounding the player on - horizontal axis value
        {
            transform.position = new Vector3(-inBound, transform.position.y, transform.position.z);
        }
    }
    void SpawningRod()  // For spawing the projectile rods with time restriction and binding it with player's location
    {
        rodPosition = new Vector3(this.transform.position.x, -0.8f, this.transform.position.z); // initial spawn location of the projectile rod
        spawnCurrentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && spawnCurrentTime > spawnTimeLimit) // Limiting the rods spawn times, after 1 sec each rod can be allowed to spawn
        {
            Instantiate(rodProjectile, rodPosition, rodProjectile.transform.rotation);
            spawnCurrentTime = 0;  // Resetting time for the next spawn
        }
    }
}
