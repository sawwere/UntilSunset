using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildHelp : MonoBehaviour
{
    public GameObject resoursePrefab1;

    public GameObject dialogBox1;
    public GameObject dialogBox2;
    public GameObject dialogBox3;

    public EnemyCharacter enemy;

    public Merchant merchant;

    bool flag1;
    bool flag2;
    static bool flag3;
    bool flag4;
    bool flag5;


    public GameObject coffin;
    // Update is called once per frame
    void Update()
    {
        var w1 = GameObject.FindGameObjectsWithTag("Wall1");
        if (GameStats.Wood <= 9 && w1.Length < 3 && !flag1)
        {
            SpawnWood();
            flag1 = true;
        }
        if (w1.Length == 3)
        {
            dialogBox1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Стены также можно улучшать, для этого нужно кликнуть на нужную стены мышкой и нажать соответствующую кнопку. Попробуйте сделать это.";
            
            if (flag1 && GameStats.Wood <= 9 && !flag2)
            {
                SpawnWood();
                flag2 = true;
            }
        }
        var w2 = GameObject.FindGameObjectWithTag("Wall2");
        if (w2 && !flag3)
        {
            dialogBox1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Днем на Вас будут наступать враги. Посмотрите, как это происходит.";
            SpawnEnemies();
            flag3 = true;
            return;
        }
        if (flag3 && GameStats.enemyOnScreen[0].Count == 0 && !flag4)
        {
            dialogBox1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Поврежденные сооружения можно ремонтировать, для этого нужно кликнуть на нужное строение мышкой и нажать соответствующую кнопку.";
            SpawnWood();
            flag4 = true;
            dialogBox2.SetActive(true);
            merchant.dialogBox.transform.GetChild(3).gameObject.SetActive(true);
        }
        var b = GameObject.FindGameObjectWithTag("Minion");
        if (b && !flag5 && flag4)
        {
            coffin.GetComponent<Coffin>().RecieveDamage(4);
            dialogBox3.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "eсли враг все-таки добрался до дома,то дом будет терять здоровье, которое находится" +
                " в правом верхнем углу. Вы можете пополнить здоровье, починив гроб. Для этого нажмите на него и выполните указанное действие.";
            flag5 = true;
           // Debug.Log((int)coffin.GetComponent<Coffin>().maxhealth);

        }
        if (flag5 && coffin.GetComponent<Coffin>().health == 8)// coffin.GetComponent<Coffin>().maxhealth)
            FindObjectOfType<PauseMenu>().Win();
    }

    void Start()
    {
        dialogBox1.SetActive(false);
        dialogBox2.SetActive(false);
        dialogBox3.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogBox1.SetActive(true);
        if (flag4)
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

    public static bool GetFlag3() { 
       return flag3; 
    }
}
