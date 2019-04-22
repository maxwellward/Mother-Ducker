using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private UI uiScript;
    
    [HideInInspector]
    public int score;

    void Start()
    {
        uiScript = FindObjectOfType<UI>();
    }

    public void AddScore()
    {
        score++;
        uiScript.UpdateScore();
    }
}
