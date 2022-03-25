using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall_2 : Wall
{
    public float displayTime = 5.0f;
    private BuildPlace_1 bp;
    private bool upgraded = false;
    public GameObject wall3;
    private Resources resources;
    public GameObject dialogBox;
    public GameObject dialogBox2;
    float timerDisplay;
    private AudioSource source;
    public AudioClip CUpgrade;
    public AudioClip CRecover;

    protected override void Start()
    {
        HideDialog();
        timerDisplay = -1.0f;
        bp = transform.parent.GetComponent<BuildPlace_1>();
        source = GetComponent<AudioSource>();
        dialogBox.SetActive(false);
        dialogBox2.SetActive(false);
        maxHealth = 4;
        base.Start();
    }

    public void OnDestroy()
    {
        if (!upgraded)
        {
            bp.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && (tool == 0))
        {
            DisplayDialog();
        }

        if (tool == 3)
        {
            DestroyStruct();
        }
    }

    public void DestroyStruct()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        GameStats.Wood += 2;
        resources.UpdateWood();
        source.PlayOneShot(CRemove, 0.5f);
        Destroy(gameObject);
    }

    public void Recover()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if ((GameStats.Wood >= 2) && (health < maxHealth))
        {
            health = maxHealth;
            GameStats.Wood -= 2;
            resources.UpdateWood();
            HideDialog();
            source.PlayOneShot(CRecover, 1f);
        }
    }

    public void UpgradeWall()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if (GameStats.Wood >= 3)
        {
            upgraded = true;
            var wall2inst = Instantiate(wall3, transform.position, transform.rotation);
            wall2inst.transform.SetParent(transform.parent.transform);
            GameStats.Wood -= 3;
            resources.UpdateWood();
            HideDialog();
            source.PlayOneShot(CUpgrade, 1f);
            Destroy(gameObject);
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        if (health == maxHealth)
        {
            dialogBox.SetActive(false);
            dialogBox2.SetActive(true);
        }
        else
        {
            dialogBox2.SetActive(false);
            dialogBox.SetActive(true);
        }
    }

    public void HideDialog()
    {
        if (health == maxHealth)
            dialogBox2.SetActive(false);
        else
            dialogBox.SetActive(false);
    }

    private void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
                dialogBox2.SetActive(false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            DoDamage(e);
    }
}
