using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Behavior : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    public void Next_Button()
    {
        Debug.Log("Click");

        int scene = SceneManager.GetActiveScene().buildIndex + 1;
        if(scene < 11)
        {
            SceneManager.LoadScene(scene);
        }
    }


    public void Restart_Button()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
