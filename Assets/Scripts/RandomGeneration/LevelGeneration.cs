using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class LevelGeneration : MonoBehaviour
{
    public SpawnSpot[] spots;

    public GameObject stone;
    public int stonesAmount;

    public GameObject tree;
    public int treesAmount;

    public GameObject bush;
    public int bushAmount;

    private void Start()
    {
        /*foreach (SpawnSpot spot in spots)
        {
            Instantiate(bush, spot.points[Random.Range(0, 4)].transform.position, Quaternion.identity);
        }*/

        int i = 0;
        var randomShuffle = Shuffle(stonesAmount + treesAmount + bushAmount, spots.Length);

        foreach (int randInd in randomShuffle)
        {
            if (i < treesAmount)
                SpawnTree(randInd);
            else if (i < treesAmount + stonesAmount)
                SpawnStone(randInd);
            else
                SpawnBush(randInd);

            i++;
        }
    }

    private Vector3 CalculateTreePosition(GameObject ob)
    {
        return new Vector3(ob.transform.position.x, ob.transform.position.y + 1f, ob.transform.position.z);
    }

    private void SpawnTree(int seed)
    {
        Instantiate(tree, CalculateTreePosition(spots[seed].points[Random.Range(0, 4)]), Quaternion.identity);
    }

    private Vector3 CalculateStonePosition(GameObject ob)
    {
        return ob.transform.position;
    }

    private void SpawnStone(int seed)
    {
        Instantiate(stone, CalculateStonePosition(spots[seed].points[Random.Range(0, 4)]), Quaternion.identity);
    }

    private Vector3 CalculateBushPosition(GameObject ob)
    {
        return new Vector3(ob.transform.position.x, ob.transform.position.y, ob.transform.position.z);
    }

    private void SpawnBush(int seed)
    {
        Instantiate(bush, CalculateBushPosition(spots[seed].points[Random.Range(0, 4)]), Quaternion.identity);
    }

    private HashSet<int> Shuffle(int need, int have)
    {
        need = Min(need, have); // проверка на то, что заявлено меньше, либо равное кол-во объект, в сравнении с теми что есть, иначе юнити умрёт

        HashSet<int> result = new HashSet<int>();

        while (result.Count < need)
            result.Add(Random.Range(0, have));

        return result;
    }
}
