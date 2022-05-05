using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllObstacles : MonoBehaviour
{
    Obstacle[] obstacles;

    void OnEnable()
    {
        obstacles = FindObjectsOfType<Obstacle>();
    }

    public void Stop() {
        for (var i = 0; i < obstacles.Length; i++) {
            obstacles[i].GetComponent<Rigidbody2D>().velocity = Vector2.up * 0;
        }
    }
}
