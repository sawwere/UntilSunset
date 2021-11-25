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
    private float DTime = 0.2f;
    public int resLim;

    void Start()
    {
        if (IsStone) tg = "StoneCount";
        else if (IsWood) tg = "WoodCount";

        col = GetComponent<Collider2D>();
        PlayerIsNear = false;
        tcount = GameObject.FindWithTag(tg).GetComponent<TextMeshProUGUI>();
        pl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        tcount.SetText(Convert.ToString(0));
    }

    void Update()
    {
        DTime += Time.deltaTime;
        if (PlayerIsNear && !pl.GetIsBat() && Input.GetKey(KeyCode.F) && DTime >= 0.2 && resLim > 0)
        {
            resLim--;

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

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            PlayerIsNear = false;
    }

}
