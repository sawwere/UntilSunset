using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderBat : MonoBehaviour
{
    public GameObject spawnbat;

    private void Awake()
    {
        if (SpawnBat.instance == null)
            Instantiate(spawnbat);
    }
}
