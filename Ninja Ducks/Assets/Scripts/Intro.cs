using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    // Speech bubbles
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;

    public GameObject tutorialCanvas;

    public GameObject chains;

    public GameObject grandmaDuck;

    public GameObject ninja1;
    public GameObject ninja2;
    public float speed;

    bool movingNinjasDown = false;
    bool movingNinjasUp = false;

    private GameManager managerScript;
    private UI uiScript;

    void Awake()
    {
        managerScript = FindObjectOfType<GameManager>();
        uiScript = FindObjectOfType<UI>();
    }

    void Update()
    {
        if (movingNinjasDown == true)
        {
            MoveNinjasDown();
        }
        if (movingNinjasUp == true)
        {
            MoveNinjasUp();
        }
    }

    // Start is called before the first frame update
    public void StartIntro()
    {
        StartCoroutine("Dialogue");
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(2f);
        one.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        one.SetActive(false);
        yield return new WaitForSeconds(1f);
        two.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        two.SetActive(false);
        yield return new WaitForSeconds(2f);
        movingNinjasDown = true;
        yield return new WaitForSeconds(2.1f);
        movingNinjasDown = false;
        yield return new WaitForSeconds(1f);
        grandmaDuck.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(1f);
        grandmaDuck.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.5f);
        chains.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        three.SetActive(true);
        yield return new WaitForSeconds(2f);
        three.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        movingNinjasUp = true;
        yield return new WaitForSeconds(2.3f);
        movingNinjasUp = false;
        yield return new WaitForSeconds(0.5f);
        four.SetActive(true);
        yield return new WaitForSeconds(2f);
        four.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        managerScript.gameIsRunning = true;
        uiScript.scoreCanvas.SetActive(true);
        tutorialCanvas.SetActive(true);

        GameObject [] ninjaDucks = GameObject.FindGameObjectsWithTag("Enemy");

		if(ninjaDucks.Length != 0)
		{
			foreach( GameObject duckToDestroy in ninjaDucks)
			{
				Destroy(duckToDestroy);
			}
		}
        
        managerScript.StartGame();

        yield return new WaitForSeconds(5f);
        tutorialCanvas.SetActive(false);
    }

    void MoveNinjasDown()
    {
        ninja1.transform.Translate(-Vector3.up * speed * Time.deltaTime, Space.World);
        ninja2.transform.Translate(-Vector3.up * speed * Time.deltaTime, Space.World);
    }
    void MoveNinjasUp()
    {
        ninja1.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        ninja2.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        grandmaDuck.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
}
