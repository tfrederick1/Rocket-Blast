using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    GameObject Rocket;
    Vector3 offset;

    void Start()
    {
        Rocket = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - Rocket.transform.position; // Offset should be zero, but you can adjust it if you want
    }

    void LateUpdate()
    {
        float newXPosition;
        float newYPosition;

        // I don't know if here is a better way to find the boundaries of the level, this was found through trial and error
        if(Rocket.transform.position.x < -5.53)
        {
            newXPosition = -5.53f;
        }

        else if(Rocket.transform.position.x > 5.53)
        {
            newXPosition = 5.53f;
        }

        else
        {
            newXPosition = Rocket.transform.position.x - offset.x; // Subtracting the offset doesn't do anything bc the offset is 0, but it could do something if I wanted it to
        }

        if(Rocket.transform.position.y < -2.6)
        {
            newYPosition = -2.6f;
        }

        else if (Rocket.transform.position.y > 17.95)
        {
            newYPosition = 17.95f;
        }

        else
        {
            newYPosition = Rocket.transform.position.y - offset.y; // Subtracting the offset doesn't do anything bc the offset is 0, but it could do something if I wanted it to
        }


        transform.position = new Vector3(newXPosition, newYPosition, -4.125f);
    }
}
