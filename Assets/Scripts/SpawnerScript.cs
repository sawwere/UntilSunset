using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class SpawnerScript : MonoBehaviour
{
    public List<EnemyCharacter> enemies;
    private List<EnemyCharacter> usedEnemies;

    public int spawnCount;//�������� ����� ��������� ������ �� ������� �����
    public float spawnRate = 5.0f;//������� ������� ������ ������
    private int encounter; //����� �����
    private double diffictyRate = 1.2; //��������� ���������� ��������� ������
    private int currentSpawned;  //����� ��������� ������������ ������
    [SerializeField] private float spawnTime; //������ ������ ������
    [SerializeField] private int direction;

    void Start()
    {
        usedEnemies = enemies;
        spawnTime = spawnRate;
        currentSpawned = 0;
        spawnCount = 10 * (int)Pow(diffictyRate, encounter);
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if ((currentSpawned < spawnCount) && (spawnTime <= 0))
        {
            System.Random r = new System.Random();
            int line = r.Next(0,3);
            EnemyCharacter enemyObject = Instantiate(ChooseEnemy(), new Vector3(transform.position.x, transform.position.y+line,transform.position.z), transform.rotation);
            enemyObject.direction = direction;
            spawnTime = spawnRate;
            currentSpawned++;
        }
    }

    private EnemyCharacter ChooseEnemy()
    {
        System.Random r = new System.Random();
        EnemyCharacter res;
        int limit = 0;
        if (GameStats.Encounter > 4)
            limit++;
        if (GameStats.Encounter > 10)
            limit++;
        while (true)
        {
            int ind = r.Next(0, limit);
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
        return res;
    }
}
