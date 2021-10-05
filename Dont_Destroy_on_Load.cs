using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_on_Load : MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
