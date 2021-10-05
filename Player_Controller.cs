using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// To Do:
// Update it so that the boundaries are calculated using collision boxes instead of x/y values
// Fix the animations!!!!!

// Ideas:
// Only allow for roation using arrow keys if rocket is firing
// Have the left/right arrow keys control turning and thrust, use both left and right at the same time to boost straight
// Add a maximum speed to make the rocket more controllable?
// Add an arrow to show direction of goal

// Finished:
// The rocket moves as expected
// The proper animations play most of the time
// The rocket now interacts with the goal
// The player now loses when the box_collider comes into contact with a border
// The rocket now no longer leaves the level area
// Rocket explodes when it hits a barrier


public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb; // The rocket itself
    Vector2 rotate;
    Animator animator;
    Scene scene;
    public GameObject rocket_chunk;

    // The win and loss booleans (Kinda obvious but I like comments)
    public bool win;
    public bool loss;
    bool explode;
    bool chunks; // Used to check if the rocket chunks have already been created

    // Various animation states
    const int STATE_Idle = 0;
    const int STATE_Startup = 1;
    const int STATE_Fire = 2;
    const int STATE_Explode = 3;

    // Used to check if the startup animation is finished
    int count;
    bool firing;
    int current_animation;

    // Used to see how long the rocket has been in the goal area
    float time;
    float time_w;
    bool winning;

    // UI stuff
    GameObject menu;
    GameObject next;
    GameObject restart;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        loss = false;
        explode = false;
        chunks = false;

        count = 0;
        firing = false;
        current_animation = 0;

        time = 0f;
        time_w = 0f;
        winning = false;

        animator = this.GetComponent<Animator>();
        rotate = new Vector2(transform.rotation.z, transform.rotation.z);
        scene = SceneManager.GetActiveScene();
        rb = gameObject.GetComponent<Rigidbody2D>();

        menu = GameObject.Find("Canvas");
        next = menu.transform.Find("Play_Button").gameObject;
        restart = menu.transform.Find("Restart_Button").gameObject;

        if (scene.buildIndex == 1)
        {
            rb.gravityScale = 0;
            next.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Turning the sprite invisible if the explosion animation finshes
        if (explode)
        {
            if (!chunks && time > .25)
            {
                Instantiate(rocket_chunk, new Vector3(transform.position.x + .01f, transform.position.y, -0.5f), Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(rocket_chunk, new Vector3(transform.position.x + .02f, transform.position.y, -0.5f), Quaternion.Euler(new Vector3(0, 0, 45)));
                Instantiate(rocket_chunk, new Vector3(transform.position.x - .01f, transform.position.y, -0.5f), Quaternion.Euler(new Vector3(0, 0, 130)));
                Instantiate(rocket_chunk, new Vector3(transform.position.x - .02f, transform.position.y, -0.5f), Quaternion.Euler(new Vector3(0, 0, 195)));
                Instantiate(rocket_chunk, new Vector3(transform.position.x, transform.position.y + .02f, -0.5f), Quaternion.Euler(new Vector3(0, 0, 260)));

                chunks = true;
            }

            time = time + Time.deltaTime;

            if (time > 1)
            {
                gameObject.SetActive(false);
                // Destroy(gameObject);
                restart.SetActive(true);
            }
        }

        else if(!explode)
        {
            // Changing the rotate vector based on the z Euler Angle
            rotate.x = -Mathf.Sin(transform.localEulerAngles.z * Mathf.Deg2Rad);
            rotate.y = Mathf.Cos(transform.localEulerAngles.z * Mathf.Deg2Rad);


            // FIXED: Somehow the win/loss thing messed up the animations so they don't play anymore? Whack!
            if (!win && !loss) // Once you win or lose you can't move the rocket anymore
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    firing = true;

                    // Changing the states of the animation
                    if (current_animation == 0)
                    {
                        Change_State(STATE_Startup);
                    }

                    else if (count > 35 && current_animation != 2)
                    {
                        Change_State(STATE_Fire);
                    }

                    else if (current_animation == 1)
                    {
                        Change_State(STATE_Startup);
                        count = count + 1;
                    }

                    // Applying a force in the direction the rocket is facing
                    rb.AddForce(rotate * 50 * Time.deltaTime);
                }

                else
                {
                    count = 0;
                    firing = false;
                }


                // Rotating the rocket
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.AddTorque(-.5f * Time.deltaTime);
                }

                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.AddTorque(.5f * Time.deltaTime);
                }
            }

            // Changing to idling animation if not moving
            if (!firing && current_animation != 0)
            {
                Change_State(STATE_Idle);
            }
        }


        // Checking to see if the rocket is within the goal area
        if (winning)
        {
            time_w += Time.deltaTime;

            if (time_w >= 5 && !loss)
            {
                win = true;
                next.SetActive(true);
            }
        }
    }


    void OnLevelWasLoaded(int level)
    {
        menu = GameObject.Find("Canvas");
        next = menu.transform.Find("Play_Button").gameObject;
        restart = menu.transform.Find("Restart_Button").gameObject;

        if (level != 1)
        {
            next.SetActive(false);
            restart.SetActive(false);
        }
    }

    // Changing through the animation states
    void Change_State(int state)
    {
        if(state == current_animation)
        {
            return;
        }

        else
        {
            switch (state)
            {
                case STATE_Idle:
                    animator.SetInteger("States", STATE_Idle);
                    break;

                case STATE_Startup:
                    animator.SetInteger("States", STATE_Startup);
                    break;

                case STATE_Fire:
                    animator.SetInteger("States", STATE_Fire);
                    break;

                case STATE_Explode:
                    animator.SetInteger("States", STATE_Explode);
                    break;
            }
        }

        current_animation = state;
    }


    // Interacting with the goal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            winning = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            time = 0f;
            winning = false;
        }
    }


    // Interacting with the boundary and the borders
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherCollider.name == "Box_Collider_Child")
        {
            if(!win)
            {
                explode = true;
                loss = true;
                Change_State(STATE_Explode);
            }
        }
    }
}
