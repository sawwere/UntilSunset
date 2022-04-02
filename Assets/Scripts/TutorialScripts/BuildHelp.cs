using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildHelp : MonoBehaviour
{
    public GameObject resoursePrefab1;
    public GameObject resoursePrefab2;

    public GameObject dialogBox1;
    public GameObject dialogBox2;
    public GameObject dialogBox3;

    public EnemyCharacter enemy;

    //public Merchant merchant;

    bool flag1;
    static bool flag2;
    static bool flag3;
    static bool flag4;
    static bool flag5;
    static bool flag7;

    public GameObject coffin;
    // Update is called once per frame
    void Update()
    {
        var w1 = GameObject.FindGameObjectsWithTag("Wall1");
        if (GameStats.Wood <= 9 && w1.Length < 3 && !flag1)
        {
            //SpawnWood();
            flag1 = true;
        }
        if (w1.Length == 3 && !flag2)
        {
            dialogBox1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Стены также можно улучшать, у них 2 режима улучшения, для этого нужно навести на нужную стены мышкой и нажать соответствующую кнопку. Попробуйте 2 раза их улучшить.";
            
           /* if (flag1 && GameStats.Wood <= 18 && !flag2)
            {
                SpawnWood();
                SpawnWood();
            }*/
            flag2 = true;
        }
        var w2 = GameObject.FindGameObjectWithTag("Wall3");
        if (w2 && !flag3 && flag2)
        {
            dialogBox1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Днем на Вас будут наступать враги. Посмотрите, как это происходит.";
            SpawnEnemies();
            flag3 = true;
            return;
        }
        if (flag3 && !flag4 && GameStats.enemyOnScreen[0].Count == 0)
        {
            dialogBox1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Врагов можно также обращать на свою сторону. Для этого нажмите T,когда враг будет рядом, он пойдет в другую сторону и если будут враги, то будет на них нападать.Это можно сделать только в обличие человека, вернитесь в дом и попробуйте.";
            Coroutine l = StartCoroutine(FriendSpawn());
            flag4 = true;
        }
        GameObject enemy_friend = GameObject.FindGameObjectWithTag("Friend");
        if (flag4 && enemy_friend && !flag5)
        {
            StopAllCoroutines();
            dialogBox1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Поврежденные сооружения можно ремонтировать, для этого нужно навести на нужное строение мышкой и нажать соответствующую кнопку.Также их можно сносить.";
           // SpawnWood();
            flag5 = true;
            dialogBox2.SetActive(true);
            /*if (GameStats.Henchman < 3)
                SpawnBlood();*/
            dialogBox3.SetActive(true);
        }
        var b = GameObject.FindGameObjectWithTag("Minion");
        if (b && !flag7 && flag5)
        {
            coffin.GetComponent<Coffin>().RecieveDamage(4);
            dialogBox3.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "А если враг все-таки добрался до дома,то дом будет терять здоровье, которое находится" +
                " в правом верхнем углу. Вы можете пополнить здоровье, починив гроб. Для этого нажмите на него и выполните указанное действие.\n Также о способностях игрока можно прочитать в меню.";
            flag7 = true;

        }
        if (flag7 && coffin.GetComponent<Coffin>().health == 8)// coffin.GetComponent<Coffin>().maxhealth)
        {
            FindObjectOfType<PauseMenu>().Win();
            foreach (var e in GameObject.FindGameObjectsWithTag("Friend"))
                e.GetComponent<EnemyCharacter>().PauseWalkSound();
        }
    }

    void Start()
    {
        dialogBox1.SetActive(false);
        dialogBox2.SetActive(false);
        dialogBox3.SetActive(false);
        flag1 = false;
        flag2 = false;
        flag3 = false;
        flag4 = false;
        flag5 = false;
        flag7 = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogBox1.SetActive(true);
        if (flag5)
            dialogBox3.SetActive(true);
    }


    void SpawnWood()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(resoursePrefab1, transform.position + new Vector3(-1, 0, 0), transform.rotation);
        }
    }

    void SpawnEnemies()
    {
        for (int line = -1; line < 2; line++)
        {
            EnemyCharacter enemyObject = Instantiate(enemy, new Vector3(32, line, transform.position.z), transform.rotation);
            enemyObject.direction = -1;
        }
    }

    void SpawnBlood()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(resoursePrefab2, transform.position + new Vector3(-1, 0, 0), transform.rotation);
        }
    }
    void SpawnEnemiesForBecomeFriend()
    {
        EnemyCharacter enemyObject = Instantiate(enemy, new Vector3(33, 0, transform.position.z), transform.rotation);
        enemyObject.direction = -1;


    }

    IEnumerator FriendSpawn()
    {
        GameObject enemy_friend = GameObject.FindGameObjectWithTag("Friend");
        while (!enemy_friend)
        {
            if (GameStats.enemyOnScreen[0].Count == 0)
                SpawnEnemiesForBecomeFriend();
            //yield return new WaitWhile(() => !enemy_friend);
            yield return new WaitForSeconds(20);
        }

       // yield return new WaitWhile(()=>!enemy_friend);
    }
    public static bool GetFlag2()
    {
        return flag2;
    }
    public static bool GetFlag5()
    {
        return flag5;
    }
    public static bool GetFlag3()
    {
        return flag3;
    }
    public static bool GetFlag4()
    {
        return flag4;
    }
    public static bool GetFlag7()
    {
        return flag7;
    }
}
