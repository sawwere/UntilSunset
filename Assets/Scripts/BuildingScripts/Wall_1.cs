using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wall_1 : Wall
{
    public float displayTime = 5.0f;
    private bool upgraded = false;
    public GameObject dialogBox;
    public GameObject dialogBox2;
    public GameObject wall2;
    private Resources resources;
    private BuildPlace_1 bp;
    private AudioSource source;
    public AudioClip CUpgrade;
    public AudioClip CRecover;

    float timerDisplay;

    protected override void Start()
    {
        bp = transform.parent.GetComponent<BuildPlace_1>();
        source = GetComponent<AudioSource>();
        bp.GetComponent<BoxCollider2D>().enabled = false;
        timerDisplay = -1.0f;
        dialogBox.SetActive(false);
        dialogBox2.SetActive(false);
        maxHealth = 2;
        base.Start();
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
        GameStats.Wood += 1;
        resources.UpdateWood();
        source.PlayOneShot(CRemove, 0.5f);
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        if (!upgraded)
        {
            bp.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void Recover()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if ((GameStats.Wood >= 1) && (health < maxHealth))
        {
            source.PlayOneShot(CRecover, 0.5f);
            GameStats.Wood -= 1;
            resources.UpdateWood();
            HideDialog();
            health = maxHealth;
        }
    }

    public void UpgradeWall()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        if (GameStats.Wood >= 3)
        {
            source.PlayOneShot(CUpgrade, 1);
            upgraded = true;
            var wall2inst = Instantiate(wall2, transform.position, transform.rotation);
            wall2inst.transform.SetParent(transform.parent.transform);
            GameStats.Wood -= 3;
            resources.UpdateWood();
            HideDialog();
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e != null)
            DoDamage(e);
    }

}
