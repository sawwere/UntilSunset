using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResourceScript : MonoBehaviour
{
    private PlayerController pl;
    protected bool PlayerIsNear;
    protected float DTime;
    public float DTimeMax = 0.4f;
    public float resLim;
    private float res;
    public Sprite[] sp;
    public GameObject resInd;
    private SpriteRenderer resSp;
    private AudioSource source;
    public AudioClip CColect;
    public AudioClip CNo;

    protected virtual void Start()
    {
        res = resLim;
        DTime = DTimeMax;
        resInd.SetActive(false);
        PlayerIsNear = false;
        pl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        resSp = resInd.GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        source.volume = 0.5f;
    }

    protected virtual void Update()
    {
        /*if (IsWood && !isRestored && !timeCycle.GetIsDay())
        {
            res = resLim;
            resSp.sprite = sp[0];
            source.volume = 0.5f;
            isRestored = true;
        }
        else if (timeCycle.GetIsDay())
            isRestored = false;*/ // Восстановление дерева

        /*if (PlayerIsNear && Input.GetKeyDown(KeyCode.F) && res == 0)
            source.PlayOneShot(CNo, 0.3f);*/  // Проигрывание последнего звука

        DTime += Time.deltaTime;
        if (PlayerIsNear && !pl.GetIsBat() && resInd.GetComponent<ResourceIndicator>().mousepressed && DTime >= DTimeMax && res > 0)
        {
            CollectItem();

            /*if (IsStone) // stone.CollectItem
            {
                DTime = 0.0f;
                GameStats.Stone += 1;
                tcount.SetText(GameStats.Stone.ToString());
            }
            else if (IsWood) // wood.CollectItem
            {
                DTime = 0.0f;
                GameStats.Wood += 1;
                tcount.SetText(GameStats.Wood.ToString());
            }*/
        }

        if (res == 0)
        {
            Invoke(nameof(ObjectDie), 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerIsNear = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            if (pl.GetIsBat() || pl.GetAtHome())
            {
                resInd.SetActive(false);
            }
            else
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

    protected virtual void CollectItem()
    {
        res--;
        if (res != 0)
            resSp.sprite = sp[Math.Min(9, Convert.ToInt32(10 - Math.Floor(res / resLim * 10)))];
        else
        {
            resSp.sprite = sp[10];
            source.volume = 1f;
        }

        source.PlayOneShot(CColect, 0.5f);
    }

    protected virtual void ObjectDie()
    {
        Destroy(gameObject);
    }

    protected void RenewResource()
    {
        res = resLim;
        resSp.sprite = sp[0];
    }

    protected void UnrelatePLayer()
    {
        pl.isRelatedToResource = false;
    }
}
