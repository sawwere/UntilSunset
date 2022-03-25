using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour
{
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")// && col.gameObject.GetComponent<AudioSource>().clip != clip)
        {
            //col.gameObject.GetComponent<AudioSource>().clip = clip;
            //col.gameObject.GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<PlayerController>().SetOnTheGrass(false);
        }
    }
    private void OnTriggerExit2D(Collider2D col)//0 2
    {
        if (col.gameObject.tag == "Player")
        {
            double y = col.gameObject.transform.position.y;
            if (y <= 0 || y >= 2.1)
                col.gameObject.GetComponent<PlayerController>().SetOnTheGrass(true);
        }
    }
}
