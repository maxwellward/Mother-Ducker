using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject ninjaDuck;
    public float minWait;
    public float maxWait;
    int side;


    float xMinT = -9f;
    float xMaxT = 9f;
    float yTop = 5.5f;
    float xMinB = -9f;
    float xMaxB = 9f;
    float yBottom = -5.5f;
    float yMinRTop = 1f;
    float yMaxRTop = 5f;
    float xRightTop = 9.4f;
    float yMinRBottom = -5f;
    float yMaxRBottom = -2.1f;
    float xRightBottom = 9.4f;
    float yMinL = -5f;
    float yMaxL = 1.1f;
    float xLeft = -9.4f;

    public void StopDucks()
    {
        StopCoroutine("SpawnDuckTimer");
    }

    public void StartDucks()
    {
        StartCoroutine("SpawnDuckTimer");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SpawnDuck();
        }
    }

    IEnumerator SpawnDuckTimer() 
    {
        yield return new WaitForSeconds(0.5f); // Wait half a second
        SpawnDuck(); // Spawn an inital enemy before and then move to the wait time

        while (true) // While (true) will run forever, because true is always true.
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait)); // Wait for a random time between the maximum wait and minimum wait.
            SpawnDuck(); // Run the function to spawn an enemy
        }
    }

    void SpawnDuck()
    {
        side = Random.Range(1, 6); // Pick a random side

        if(side == 1){
            Vector2 spawnPointTop = new Vector2(Random.Range(xMinT, xMaxT), yTop);
            Instantiate(ninjaDuck, spawnPointTop, transform.rotation);
        }
        if(side == 2){
            Vector2 spawnPointBottom = new Vector2(Random.Range(xMinB, xMaxB), yBottom);
            Instantiate(ninjaDuck, spawnPointBottom, transform.rotation);
        }
        if(side == 3){
            Vector2 spawnPointRightTop = new Vector2(xRightTop, Random.Range(yMinRTop, yMaxRTop));
            Instantiate(ninjaDuck, spawnPointRightTop, transform.rotation);
        }
        if(side == 4){
            Vector2 spawnPointRightBottom = new Vector2(xRightBottom, Random.Range(yMinRBottom, yMaxRBottom));
            Instantiate(ninjaDuck, spawnPointRightBottom, transform.rotation);
        }
        if(side == 5){
            Vector2 spawnPointLeft = new Vector2(xLeft, Random.Range(yMinL, yMaxL));
            Instantiate(ninjaDuck, spawnPointLeft, transform.rotation);
        }
    }
}
