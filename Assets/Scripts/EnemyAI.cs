using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private CameraManager cameraManagerScript;
    private UI uiScript;
    private Score scoreScript;
    private Movement movementScript;
    private GameManager managerScript;
    public float speed;
    public float marshSpeed;
    public float waterSpeed;

    Vector3 currentPos;
    Vector3 oldPos;

    void Awake()
    {
        cameraManagerScript = FindObjectOfType<CameraManager>();
        uiScript = FindObjectOfType<UI>();
        scoreScript = FindObjectOfType<Score>();
        movementScript = FindObjectOfType<Movement>();
        managerScript = FindObjectOfType<GameManager>();

        speed = waterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript.gameIsRunning == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, movementScript.player.transform.position, speed * Time.deltaTime);
        }
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Marsh")
        {
            speed = marshSpeed;
        }
        if(obj.gameObject.name == "Katana")
        {
            Destroy(this.gameObject);
            scoreScript.AddScore();
            cameraManagerScript.Shake(0.02f, 0.15f);
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Marsh")
        {
            speed = waterSpeed;
        }
    }
}
