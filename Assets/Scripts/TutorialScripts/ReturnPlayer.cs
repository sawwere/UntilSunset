using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlayer : MonoBehaviour
{

    public int direction = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player")
        {
            var obj = collision.gameObject.GetComponent<PlayerTutorial>();

            if (direction == 1)
                obj.ReturnRight();
            else obj.ReturnLeft();
          
        }
    }
 
}