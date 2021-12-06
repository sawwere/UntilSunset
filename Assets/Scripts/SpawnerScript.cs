using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SpawnerScript : MonoBehaviour
{
    public List<EnemyCharacter> enemies;
    private List<EnemyCharacter> usedEnemies;

    public int spawnCount;//�������� ����� ��������� ������ �� ������� �����
    public float spawnRate;//������� ������� ������ ������
    private double diffictyRate = 1.2; //��������� ���������� ��������� ������
    private int currentSpawned;  //����� ��������� ������������ ������
    [SerializeField] private float spawnTime; //������ ������ ������
    [SerializeField] private int direction; // ������ ����������� ������ ����� ������

    void Start()
    {
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
        }
    }

    private EnemyCharacter ChooseEnemy()
    {
        EnemyCharacter res;
        int limit = 1;
        if (GameStats.Encounter > 1)
            limit++;
        if (GameStats.Encounter > 2)
            limit++;
        while (true)
        {
            int ind = Random.Range(0, Min(limit, usedEnemies.Count));
            if (usedEnemies[ind].price > spawnCount - currentSpawned)
            {
                usedEnemies.RemoveAt(ind);
            }
            else
            {
                res = usedEnemies[ind];
                currentSpawned += res.price;
                break;
            }
        }
        return res;
    }


    public void UpdateSpawn()
    {
        int e = GameStats.Encounter;
        spawnCount = (int)(6 * Pow(diffictyRate, e));
        int nightLen = 60;
        spawnRate = nightLen / spawnCount;
        spawnTime = 0;
        currentSpawned = 0;
        usedEnemies = new List<EnemyCharacter>(enemies); ;
    }
}
