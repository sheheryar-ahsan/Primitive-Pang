using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    public float spawnTimeValue = 5f; // 5s lifetime of rod
    private float spawnTimeLimit = 0;


    void Update()
    {
        DestroyingRod();
    }

    void DestroyingRod()  // After a cetain time rod is being destroyed
    {
        spawnTimeValue -= Time.deltaTime; // Coundown Counter

        if (spawnTimeValue < spawnTimeLimit)
        {
            Destroy(gameObject);
        }
    }
}
