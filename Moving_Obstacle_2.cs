using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Obstacle_2 : MonoBehaviour
{
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = -.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 0)
        {
            transform.position = new Vector3(transform.position.x + .3f * Time.deltaTime, y, z);
        }
    }
}
