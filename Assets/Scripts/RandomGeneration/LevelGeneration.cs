using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] spots;

    public GameObject stone;
    public int stonesAmount;

    public GameObject tree;
    public int treesAmount;

    private void Start()
    {
        /*foreach (GameObject spot in spots)
        {
            Instantiate(stone, spot.transform.position, Quaternion.identity);
        }*/

        int i = 0;
        var randomShuffle = Shuffle(stonesAmount + treesAmount, spots.Length);

        foreach (int randInd in randomShuffle)
        {
            if (i < treesAmount)
                Instantiate(tree, CalculateTreePosition(spots[randInd]), Quaternion.identity);
            else
                Instantiate(stone, CalculateStonePosition(spots[randInd]), Quaternion.identity);

            i++;
        }
    }

    public Vector3 CalculateTreePosition(GameObject ob)
    {
        return new Vector3(ob.transform.position.x, ob.transform.position.y + 1f, ob.transform.position.z);
    }

    public Vector3 CalculateStonePosition(GameObject ob)
    {
        return ob.transform.position;
    }

    public HashSet<int> Shuffle(int need, int have)
    {
        HashSet<int> result = new HashSet<int>();

        while (result.Count < need)
            result.Add(Random.Range(0, have));

        return result;
    }
}
