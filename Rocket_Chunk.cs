using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Rocket_Chunk : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 Rotate;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        Rotate.x = -Mathf.Sin(Random.Range(0f, 360f));
        Rotate.y = Mathf.Cos(Random.Range(0f, 360f));

        rb.AddForce(Random.Range(300, 500) * Rotate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
