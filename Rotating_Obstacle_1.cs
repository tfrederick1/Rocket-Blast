using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Obstacle_1 : MonoBehaviour
{
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        x = 0f;
        y = 0f;
        z = 20f;
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }
}
