using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float timer;
    private float maxTimer;
    public GameObject enemy;
   

    public float timerMin = 5f;
    public float timerMax = 12f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        maxTimer = Random.Range(timerMin, timerMax);
        StartCoroutine(SpawnEnemyTimer());
    }

    // Update is called once per frame
    void Update()
    {
    
 
    }

    void SpawnEnemy()
    {
        float y = 1.5f; // changed to x
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 1f), y, 0)); // changed to x
        spawnPoint.z = 0;

        //adjust x-axis position
        float dist = (this.transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0, dist)).y; //changed to y boarder 
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).y;
        Vector3 enemySize = enemy.GetComponent<Renderer>().bounds.size;
        spawnPoint.y = Mathf.Clamp(spawnPoint.y, leftBorder + enemySize.y / 2, rightBorder - enemySize.y / 2); //Changed from x to y

        GameObject.Instantiate(enemy, spawnPoint, new Quaternion(0, 0, 0, 0));
    }


    IEnumerator SpawnEnemyTimer()
    {
        while (true)
        {
            if (timer >= maxTimer)
            {
                //spawn an enemy
                SpawnEnemy();
                timer = 0;
                maxTimer = Random.Range(timerMin, timerMax);

            }

            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
