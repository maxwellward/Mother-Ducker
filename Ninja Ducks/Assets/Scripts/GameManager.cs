using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Score scoreScript;
    private UI uiScript;
    private GameManager managerScript;
    private EnemySpawner enemySpawnerScript;
    private Intro introScript;

    public GameObject player;

    [HideInInspector]
    public bool gameIsRunning = false;
    // Start is called before the first frame update

    void Start()
    {
        scoreScript = FindObjectOfType<Score>();
        uiScript = FindObjectOfType<UI>();
        managerScript = FindObjectOfType<GameManager>();
        enemySpawnerScript = FindObjectOfType<EnemySpawner>();
        introScript = FindObjectOfType<Intro>();

        gameIsRunning = false;
    }   

    public void EndGame()
    {
        gameIsRunning = false;
        uiScript.ShowGameOver();
        enemySpawnerScript.StopDucks();
    }

    public void StartIntro()
    {
        uiScript.startCanvas.SetActive(false);
        introScript.StartIntro();
    }

    public void StartGame()
    {
        enemySpawnerScript.StartDucks();
    }

    public void RestartGame()
    {
        GameObject [] ninjaDucks = GameObject.FindGameObjectsWithTag("Enemy");

		if(ninjaDucks.Length != 0)
		{
			foreach( GameObject duckToDestroy in ninjaDucks)
			{
				Destroy(duckToDestroy);
			}
		}

        Time.timeScale = 1;
        scoreScript.score = 0;
        uiScript.UpdateScore();
        uiScript.endCanvas.SetActive(false);
        managerScript.gameIsRunning = true;
        enemySpawnerScript.StartDucks();

        player.transform.position = new Vector3(0, 0, 0);
    }

}
