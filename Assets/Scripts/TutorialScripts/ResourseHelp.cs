using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseHelp : MonoBehaviour
{

    public GameObject dialogBox1;
    public GameObject dialogBox2;

    public GameObject resoursePrefab1;

    public GameObject resoursePrefab2;

    bool flag = false;

    void Start()
    {
        dialogBox1.SetActive(false);
        dialogBox2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogBox1.SetActive(true);
    }

    private void Update()
    {
        if (GameStats.Wood >= 1 && GameStats.Stone >= 1 )
        {
            dialogBox2.SetActive(true);
            if (!flag)
            {
                for (int i = 0; i < 10; i++)
                {
                    Instantiate(resoursePrefab1, transform.position + new Vector3(13, -4, 0), transform.rotation);
                    Instantiate(resoursePrefab2, transform.position + new Vector3(13, -6, 0), transform.rotation);
                }
                flag = true;
            }
        }
        
    }
}
