using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.0f, gameObject.transform.position.z);
    }
    public IEnumerator day()
    {
        Debug.Log("log");
        while (transform.position.y < 7.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.02f, gameObject.transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public IEnumerator night()
    {
        Debug.Log("log");
        while (transform.position.y > 2.3f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y - 0.02f), gameObject.transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
