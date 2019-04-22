using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float swingTime;
    public float rotationSpeed;
    bool rotateKatana = false;
    bool cooldown;

    private GameManager managerScript;

    SpriteRenderer katanaRenderer;
    Collider2D katanaCollider;
    // Start is called before the first frame update
    void Awake()
    {
        managerScript = FindObjectOfType<GameManager>();

        katanaRenderer = GetComponent<SpriteRenderer>();
        katanaCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript.gameIsRunning == true)
        {
            if (rotateKatana == true)
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            { 
                if (cooldown == false)
                    StartCoroutine("Swing");
            }
        }
    }

    IEnumerator Swing()
    {
        katanaCollider.enabled = true;
        katanaRenderer.enabled = true;
        rotateKatana = true;
        yield return new WaitForSeconds(swingTime);
        katanaRenderer.enabled = false;
        rotateKatana = false;
        katanaCollider.enabled = false;
        transform.rotation = Quaternion.Euler(0,0,-25);
        cooldown = true;
        yield return new WaitForSeconds(0.3f);
        cooldown = false;
        //transform.Rotate(-Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
