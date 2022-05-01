using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(transform.parent.GetComponent<Coffin>().playerisnear);
        if (col.gameObject.tag == "Player")
            transform.parent.GetComponent<Coffin>().playerisnear = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(transform.parent.GetComponent<Coffin>().playerisnear);
            transform.parent.GetComponent<Coffin>().playerisnear = false;
            transform.parent.GetComponent<Coffin>().HideDialog();
        }    
    }
}
