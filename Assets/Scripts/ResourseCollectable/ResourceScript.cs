using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    private PlayerController pl;
    protected float DTime;
    public float DTimeMax = 0.4f;
    public int resLim;
    private int res;
    public Sprite[] sp;
    public GameObject resInd;
    private ResourceIndicator resIndComponent;
    private SpriteRenderer resSp;
    private AudioSource source;
    public AudioClip collectSound;
    protected Resources resources;

    private void Awake()
    {
        pl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        resIndComponent = resInd.GetComponent<ResourceIndicator>();
        resSp = resInd.GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        resInd.SetActive(false);
    }

    private void Start()
    {
        res = resLim;
        DTime = DTimeMax;
        source.volume = 0.5f;
    }

    protected virtual void Update()
    {
        DTime += Time.deltaTime;

        if (res == 0)
        {
            Invoke(nameof(ObjectDie), 0.5f);
        }
        else if (resIndComponent.isMousePressed && DTime >= DTimeMax)
        {
            CollectItem();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            if (pl.GetIsBat() || pl.GetAtHome())
                resInd.SetActive(false);
            else
                resInd.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            resInd.SetActive(false);
    }

    protected virtual void CollectItem()
    {
        res--;
        int delta = sp.Length - 1;
        resSp.sprite = sp[delta - delta * res / resLim];
        source.PlayOneShot(collectSound, 0.5f);
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
}
