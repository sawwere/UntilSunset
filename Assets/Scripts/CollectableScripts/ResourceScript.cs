using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResourceScript : MonoBehaviour
{
    public bool IsStone;
    public bool IsWood;
    public TextMeshProUGUI tcount;
    private string tg;
    private PlayerController pl;
    private Collider2D col;
    private bool PlayerIsNear;
    private float DTime;
    private const float DTimeMax = 0.4f;
    public float resLim;
    private float res;
    public Sprite[] sp = new Sprite[11];
    public GameObject resInd;
    private SpriteRenderer resSp;
    private bool isRestored;
    private TimeCycle timeCycle;
    private AudioSource source;


    void Start()
    {
        isRestored = true;
        res = resLim;
        DTime = DTimeMax;
        resInd.SetActive(false);
        if (IsStone) tg = "StoneCount";
        else if (IsWood) tg = "WoodCount";
        col = GetComponent<Collider2D>();
        PlayerIsNear = false;
        tcount = GameObject.FindWithTag(tg).GetComponent<TextMeshProUGUI>();
        pl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        resSp = resInd.GetComponent<SpriteRenderer>();
        tcount.SetText(Convert.ToString(0));
        timeCycle = GameObject.Find("GameStatsObject").GetComponent<TimeCycle>();
        source = GetComponent<AudioSource>();
    }

   

    void Update()
    {
        if (IsWood && !isRestored && !timeCycle.GetIsDay())
        {
            res = resLim;
            resSp.sprite = sp[0];
            isRestored = true;
        }
        else if (timeCycle.GetIsDay())
            isRestored = false;

        DTime += Time.deltaTime;
        if (PlayerIsNear && !pl.GetIsBat() && Input.GetKey(KeyCode.F) && DTime >= DTimeMax && res > 0)
        {
            res--;
            if (res != 0)
                resSp.sprite = sp[Math.Min(9, Convert.ToInt32(10 - Math.Floor(res / resLim * 10)))];
            else
                resSp.sprite = sp[10];

            source.PlayOneShot(source.clip, 0.2f);

            if (IsStone)
            {
                DTime = 0.0f;
                GameStats.Stone += 1;
                tcount.SetText(GameStats.Stone.ToString());
            }
            else if (IsWood)
            {
                DTime = 0.0f;
                GameStats.Wood += 1;
                tcount.SetText(GameStats.Wood.ToString());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            PlayerIsNear = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !pl.GetIsBat())
        {
            resInd.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            resInd.SetActive(false);
            PlayerIsNear = false;
        }
    }

}
