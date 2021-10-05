using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Button_Script : MonoBehaviour
{
    private SpriteRenderer SR;
    GameObject Rocket;
    Player_Controller script;
    BoxCollider2D box;
    Scene scene;
    
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
        Rocket = GameObject.FindGameObjectWithTag("Player");
        script = Rocket.GetComponent<Player_Controller>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        scene = SceneManager.GetActiveScene();

        SR.enabled = false;
        box.enabled = false;

        x = 0f;
        y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(scene.buildIndex != 1)
        {
            x = Rocket.transform.position.x;
            y = Rocket.transform.position.y;
        }

        if (script.loss == true)
        {
            
            transform.position = new Vector3(x, y + 1, -2.1f);
            

            SR.enabled = true;
            box.enabled = true;
        }

    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(scene.buildIndex);
    }
}
