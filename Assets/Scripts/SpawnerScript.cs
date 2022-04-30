using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SpawnerScript : MonoBehaviour
{
    public List<EnemyCharacter> enemies;
    private List<int> usedEnemies;

    public int spawnCount;//максимум общей стоимости врагов на текущей волне
    public float spawnRate;//счетчик времени спавна врагов
    private int currentSpawned;  //общая стоимость заспавненных врагов
    [SerializeField] private float spawnTime; //период спавна врагов
    [SerializeField] private int direction; // задает направление врагов после спавна


    private List<List<int>> types;
    void Awake()
    {
        types = new List<List<int>>();
        types.Add(new List<int>() { 0, 0, 0, 0, 0, 0 });
        types.Add(new List<int>() { 0, 0, 0, 0, 0, 1, 1 });
        types.Add(new List<int>() { 0, 0, 0, 0, 1, 1, 2, 2 });
        //UpdateSpawn();
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if ((currentSpawned < spawnCount) && (spawnTime <= 0))
        {
            int line = Random.Range(0, 3);
            EnemyCharacter enemyObject = Instantiate(ChooseEnemy(), 
                new Vector3(transform.position.x, transform.position.y+line+0.25f,transform.position.z), transform.rotation);
            enemyObject.direction = direction;
            spawnTime = spawnRate;
        }
    }

    private EnemyCharacter ChooseEnemy()
    {
        EnemyCharacter res;
        
        {
            int ind = Random.Range(0, usedEnemies.Count);
            res = enemies[usedEnemies[ind]];
            usedEnemies.RemoveAt(ind);
            currentSpawned++;
        }
        return res;
    }


    public void UpdateSpawn()
    {
        int e = GameStats.Encounter;
        spawnCount = types[GameStats.Encounter].Count;
        int nightLen = 60;
        spawnRate = nightLen / spawnCount;
        spawnTime = 0;
        currentSpawned = 0;
        usedEnemies = new List<int>(types[e]);
        
    }
}
