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
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        PlayerIsNear = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        PlayerIsNear = false;
    }

    private void OnMouseDown()
    {
        if (PlayerIsNear && !pl.GetIsBat())
        {
            if(IsStone)
            {
                GameStats.Stone += 1;
                tcount.SetText(GameStats.Stone.ToString());
            }
            else if (IsWood)
            {
                GameStats.Wood += 1;
                tcount.SetText(GameStats.Wood.ToString());
            }
        }
    }
}
