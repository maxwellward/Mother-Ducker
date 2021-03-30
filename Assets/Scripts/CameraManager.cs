using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;

    Vector3 offset;

    void Awake()
    {
        offset = new Vector3(0, 0, -5);

        if (mainCam == null)
            mainCam = Camera.main;
    }

    float shakeAmount = 0;
    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        Vector3 camPos = mainCam.transform.position;
        float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
        float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
        camPos.x += offsetX;
        camPos.y += offsetY;
        mainCam.transform.position = camPos;
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = Vector3.zero;
    }

}
