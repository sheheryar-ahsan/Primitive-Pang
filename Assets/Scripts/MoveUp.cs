using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    private float speed = 10f;
    private float topBound = 1.1f;

    void Update()
    {
        MovementSpeed();
        MovementStop();
    }

    void MovementSpeed()  // For moving the rods up with a speed
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    void MovementStop()  // For making the the rods stop at a certain position by making speed zero
    {
        if (transform.position.y > topBound)
        {
            speed = 0;
        }
    }
}
