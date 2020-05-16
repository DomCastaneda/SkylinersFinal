using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float timerBullet;
    private float maxTimerBullet;
    public GameObject bullet;

    public float timerMin = 5f;
    public float timerMax = 25f;
    public bool canFireBullets = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);

        timerBullet = 0;
        maxTimerBullet = Random.Range(timerMin, timerMax);

        if (canFireBullets)
            StartCoroutine("FireBullet");
    }

    // Update is called once per frame
    void Update()
    {

        if (Camera.main.WorldToViewportPoint(transform.position).x < 0) //change to x position 
            Destroy(this.gameObject);
    }

    void SpawnBullet()
    {
        Vector3 spawnPoint = transform.position;
        spawnPoint.x -= (bullet.GetComponent<Renderer>().bounds.size.x / 2) * (GetComponent<Renderer>().bounds.size.x / 2); //bullet moving to x position 
        GameObject.Instantiate(bullet, spawnPoint, transform.rotation);
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            if (timerBullet >= maxTimerBullet)
            {
                //spawn an enemy
                SpawnBullet();
                timerBullet = 0;
                maxTimerBullet = Random.Range(timerMin, timerMax);

            }

            timerBullet += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
