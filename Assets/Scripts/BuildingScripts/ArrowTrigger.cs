using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    private TowerScript tw;
    public int type;

    private void Start()
    {
        tw = transform.parent.GetComponent<TowerScript>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (type == 1)
            {
                tw.et = true;
            }

            if (type == -1)
            {
                tw.etback = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (type == 1)
            {
                tw.et = false;
            }

            if (type == -1)
            {
                tw.etback = false;
            }
        }
    }
}