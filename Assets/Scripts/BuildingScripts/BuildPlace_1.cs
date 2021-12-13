using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildPlace_1 : MonoBehaviour
{

    public float displayTime = 5.0f;
    public GameObject dialogBox;
    public GameObject wall;
    float timerDisplay;
    private Resources resources;
    private bool EnemyIsNear;

    void Start()
    {
        EnemyIsNear = false;
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;         
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            DisplayDialog();
        }
    }

    public void BuildWall()
    {
        if ((GameStats.Wood >= 3) && (!EnemyIsNear))
        {
            var wallinst = Instantiate(wall, new Vector3 (transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
            wallinst.transform.SetParent(this.transform);
            GameStats.Wood -= 3;
            resources.UpdateWood();
            HideDialog();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy")
            EnemyIsNear = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
            EnemyIsNear = false;
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
    }
}
