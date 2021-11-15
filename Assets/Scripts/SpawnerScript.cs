using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private List<EnemyCharacter> enemies;
    [SerializeField] private List<EnemyCharacter> usedEnemies;


    public int spawnCount;//максимум общей стоимости врагов на текущей волне
    public float spawnRate = 5.0f;//счетчик времени спавна врагов
    private int encounter; //номер волны
    private float diffictyRate = 1.2f; //множитель увеличения стоимости врагов
    private int currentSpawned;  //общая стоимость заспавненных врагов
    private float spawnTime; //период спавна врагов

    void Start()
    {
        usedEnemies = enemies;
        spawnTime = spawnRate;
        currentSpawned = 0;
        spawnCount = 10 * (int)Pow(diffictyRate, encounter);
        GameStats.spawnerList.Add(this);
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if ((currentSpawned < spawnCount) && (spawnTime <= 0))
        {
            System.Random r = new System.Random();
            int line = r.Next(0,3);
            GameObject enemyObject = Instantiate(ChooseEnemy(), new Vector3(transform.position.x, transform.position.y+line,transform.position.z), transform.rotation);
            spawnTime = spawnRate;
            currentSpawned++;
        }
    }

    private GameObject ChooseEnemy()
    {
        System.Random r = new System.Random();
        EnemyCharacter res;
        while (true)
        {
            int ind = r.Next(0, usedEnemies.Count);
            if (usedEnemies[ind].price > spawnCount - currentSpawned)
            {
                usedEnemies.RemoveAt(ind);
            }
            else
            {
                res = usedEnemies[ind];
                currentSpawned -= res.price;
                break;
            }
        }
        return res.gameObject;
    }
}
