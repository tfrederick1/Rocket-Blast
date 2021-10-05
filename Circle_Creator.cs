using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Creator : MonoBehaviour
{
    public GameObject prefab;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        while(true)
        {
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y - .5f, -0.6f), Quaternion.identity);
            
            yield return new WaitForSeconds(2f);
        }
    }
}
