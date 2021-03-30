using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Score scoreScript;
    private GameManager managerScript;

    public GameObject endCanvas;
    public GameObject startCanvas;

    public GameObject scoreCanvas;
    public Text scoreText;

    // Awake is called before the first frame update & Start()
    void Awake()
    {
        scoreScript = FindObjectOfType<Score>();
        managerScript = FindObjectOfType<GameManager>();
        startCanvas.SetActive(true);
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        scoreText.text = "Ninja Ducks Slain: " + scoreScript.score;
    }

    public void ShowGameOver()
    {
        endCanvas.SetActive(true);
    }
}
