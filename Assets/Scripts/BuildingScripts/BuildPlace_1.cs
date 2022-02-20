using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildPlace_1 : MonoBehaviour
{

    public float displayTime = 5.0f;
    public GameObject dialogBox;
    public GameObject wall;
    public static GameObject obj_struct;
    public static GameObject obj_ghost;
    public static int obj_price;
    private bool ghostexist;
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

    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && (obj_struct != null))
        {
            var wallg = Instantiate(obj_ghost, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
            wallg.transform.SetParent(this.transform);
            ghostexist = true;
        }
    }

    private void OnMouseExit()
    {
        if ((obj_struct != null) && ghostexist)
        {
            Destroy(this.transform.GetChild(2).gameObject);
            ghostexist = false;
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && (obj_struct != null))
        {
            BuildStruct();
        }
    }

    public void BuildStruct()
    {
        if ((GameStats.Wood >= obj_price) && (!EnemyIsNear))
        {
            var structinst = Instantiate(obj_struct, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
            structinst.transform.SetParent(this.transform);
            GameStats.Wood -= obj_price;
            resources.UpdateWood();
            HideDialog();
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
