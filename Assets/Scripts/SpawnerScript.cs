using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public int spawnCount;//максимум врагов на текущей волне
    public float spawnRate = 5.0f;//счетчик времени спавна врагов
    private int currentSpawned;  //заспанено врагов на текущей волне
    private float spawnTime; //период спавна врагов

    void Start()
    {
        spawnTime = spawnRate;
        currentSpawned = 0;

        spawnCount = 32;
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if ((currentSpawned < spawnCount) && (spawnTime <= 0))
        {
            System.Random r = new System.Random();
            int line = r.Next(0,3);
            GameObject enemyObject = Instantiate(enemy, new Vector3(transform.position.x, transform.position.y+line,transform.position.z), transform.rotation);
            spawnTime = spawnRate;
            currentSpawned++;
        }

    }
}
