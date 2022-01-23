using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public int newScore = 0;
    public int ballCount = 3;
    public int startBallCount = 0;
    public Vector3 spawnLocation0;
    public Vector3 spawnLocation1;
    public Vector3 spawnLocation2;

    void Update()
    {
        if (Time.realtimeSinceStartup >= 3f) // Adding 3 sec's waiting to start spawing the big balls
        {
            SpawnCount();
        }
    }

    void SpawnCount() // For spawing atleast 3 balls at start at random location, Numbers of spawn will increase by the destroy of previous balls(Check DestroyBall Line:38,39)
    {
        for (; startBallCount < ballCount; startBallCount++)
        {
            SpawingBall();
        }
    }

    void SpawingBall() // Spawing the big balls
    {
        spawnLocation0 = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(2.4f, 3.2f), transform.position.z);
        Instantiate(ballPrefabs[0], spawnLocation0, ballPrefabs[0].transform.rotation);
    }

    public void SpawingMediumBall() // Spawing the medium balls
    {
        Instantiate(ballPrefabs[1], spawnLocation1, ballPrefabs[1].transform.rotation);
        Instantiate(ballPrefabs[1], spawnLocation2, ballPrefabs[1].transform.rotation);
    }

    public void SpawingSmallBall() // Spawing the small balls
    {
        Instantiate(ballPrefabs[2], spawnLocation1, ballPrefabs[2].transform.rotation);
        Instantiate(ballPrefabs[2], spawnLocation2, ballPrefabs[2].transform.rotation);
    }
}
