using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rising_Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 1.285)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .3f * Time.deltaTime, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, -2.715f, transform.position.z);
        }
    }
}
