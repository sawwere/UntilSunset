using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SpawnerScript : MonoBehaviour
{
    public List<EnemyCharacter> enemies;
    private List<EnemyCharacter> usedEnemies;

    public int spawnCount;//максимум общей стоимости врагов на текущей волне
    public float spawnRate;//счетчик времени спавна врагов
    private int encounter; //номер волны
    private double diffictyRate = 1.2; //множитель увеличения стоимости врагов
    private int currentSpawned;  //общая стоимость заспавненных врагов
    [SerializeField] private float spawnTime; //период спавна врагов
    [SerializeField] private int direction;

    void Start()
    {
        usedEnemies = enemies;
        UpdateSpawn();
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if ((currentSpawned < spawnCount) && (spawnTime <= 0))
        {
            int line = Random.Range(0, 3);
            EnemyCharacter enemyObject = Instantiate(ChooseEnemy(), new Vector3(transform.position.x, transform.position.y+line,transform.position.z), transform.rotation);
            enemyObject.direction = direction;
            spawnTime = spawnRate;
            Debug.Log(currentSpawned);
        }
    }

    private EnemyCharacter ChooseEnemy()
    {
        EnemyCharacter res;
        int limit = 1;
        if (GameStats.Encounter > 2)
            limit++;
        if (GameStats.Encounter > 4)
            limit++;
        while (true)
        {
            int ind = Random.Range(0, limit);
            if (usedEnemies[ind].price > spawnCount - currentSpawned)
            {
                usedEnemies.RemoveAt(ind);
            }
            else
            {
                res = usedEnemies[1];
                currentSpawned += res.price;
                break;
            }
        }
        return res;
    }


    public void UpdateSpawn()
    {
        int e = GameStats.Encounter;
        spawnCount = 10 * (int)Pow(diffictyRate, encounter);
        int nightLen = 60;
        spawnRate = nightLen / spawnCount;
        spawnTime = 0;
        currentSpawned = 0;
    }
}
