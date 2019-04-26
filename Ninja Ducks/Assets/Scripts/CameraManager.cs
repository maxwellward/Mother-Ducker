using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    private Movement movementScript;

    float shakeAmount = 0;
    bool shaking = false;

    Vector3 offset;

    void Awake()
    {
        offset = new Vector3(0, 0, -5);

        movementScript = FindObjectOfType<Movement>();

        if (mainCam == null)
            mainCam = Camera.main;
    }

    void FixedUpdate()
    {
        if(shaking == false)
        {
            mainCam.transform.position = movementScript.player.transform.position + offset;
        }
    }

    public void StartShake()
    {
        shaking = true;
        Shake(0.02f, 0.2f);
    }

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        if(shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;
            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = Vector3.zero;
        shaking = false; 
    }

}
