using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildPlace_1 : MonoBehaviour
{

    public float displayTime = 5.0f;
    public int direction;
    public GameObject dialogBox;
    public GameObject wall;
    public GameObject brstakes;
    public static GameObject obj_struct;
    public static GameObject obj_ghost;
    private static GameObject wallg;
    public static int obj_price_wood;
    public static int obj_price_stone;
    private bool ghostexist;
    float timerDisplay;
    private Resources resources;
    private bool EnemyIsNear;
    private AudioSource source;
    public AudioClip CDestroy;
    public AudioClip CBuild;
    private Wall_1 w1;
    private Wall_2 w2;
    private Wall_3 w3;
    private StakesScript s;
    private TowerScript t;
    private bool IsWalled;

    void Start()
    {
        IsWalled = false;
        EnemyIsNear = false;
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        source = gameObject.AddComponent<AudioSource>();
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
        w1 = GetComponentInChildren<Wall_1>();
        w2 = GetComponentInChildren<Wall_2>();
        w3 = GetComponentInChildren<Wall_3>();
        s = GetComponentInChildren<StakesScript>();
        t = GetComponentInChildren<TowerScript>();

        if (IsWalled && w1 == null && w2 == null && w3 == null && s == null && t == null)
        {
            source.PlayOneShot(CDestroy, 0.9f);
            IsWalled = false;
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1) && (obj_struct != null) && ghostexist)
        {
            obj_ghost = null;
            obj_struct = null;
            Destroy(wallg);
            ghostexist = false;
            resources.ClearPriceOrRefund();
            resources.UpdateAll();
        }
    }
    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && (obj_struct != null))
        {
            resources.SetPrice(obj_price_wood, obj_price_stone);
            resources.UpdateAll();
            wallg = Instantiate(obj_ghost, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
            wallg.transform.SetParent(this.transform);
            ghostexist = true;
        }
    }

    private void OnMouseExit()
    {
        if ((obj_struct != null) && ghostexist)
        {
            Destroy(wallg);
            ghostexist = false;
            resources.ClearPriceOrRefund();
            resources.UpdateAll();
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
        if ((GameStats.Wood >= obj_price_wood) && (!EnemyIsNear) && (GameStats.Stone >= obj_price_stone))
        {
            IsWalled = true;
            var structinst = Instantiate(obj_struct, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
            structinst.transform.SetParent(this.transform);
            GameStats.Wood -= obj_price_wood;
            GameStats.Stone -= obj_price_stone;
            resources.UpdateWood();
            resources.UpdateStones();
            source.PlayOneShot(CBuild, 0.2f);
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
        }
    }

    public void BrokenStakes()
    {
        var bstakesinst = Instantiate(brstakes, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
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
}
