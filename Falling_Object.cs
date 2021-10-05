using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > -2.715f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - .3f * Time.deltaTime, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, 1.285f, transform.position.z);
        }
    }
}
