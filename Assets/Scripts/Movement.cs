using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private UI uiScript;
    private GameManager managerScript;

    [HideInInspector]
    public Rigidbody2D player;
    bool facingRight = true;

    float speed;
    public float marshSpeed;
    public float waterSpeed;

    void Awake()
    {
        uiScript = FindObjectOfType<UI>();
        managerScript = FindObjectOfType<GameManager>();

        player = gameObject.GetComponent<Rigidbody2D>();
        speed = waterSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (managerScript.gameIsRunning == true)
            MoveCheck();
    }

    void MoveCheck()
    {   
        // Moving right
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

            if(facingRight == false)
            {
                facingRight = true;
                transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
            } 
        }

        // Moving left
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.World);

            if(facingRight == true)
            {
                facingRight = false;
                transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
            } 
        }
        
        // Moving up and down
        if(Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.up * speed * Time.deltaTime, Space.World);
        if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Marsh")
        {
            speed = marshSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Marsh")
        {
            speed = waterSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag == "Enemy") // When an enemy hits the player
        {
            //Destroy(this.gameObject);
            Time.timeScale = 0;
            managerScript.EndGame();
        }
    }
}
