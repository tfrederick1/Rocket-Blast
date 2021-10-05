using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Script_3 : MonoBehaviour
{
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = .05f;
    }

    // Update is called once per frame
    void Update()
    {
        // If the cloud has reached the edge of the screen, move it to the left side of the screen
        if (transform.position.x >= 10.6)
        {
            Vector3 wot = new Vector3(-11, transform.position.y, -.2f);
            transform.position = wot;
        }

        else
        {
            transform.position = transform.position + Vector3.right * velocity * Time.deltaTime;
        }
    }
}
