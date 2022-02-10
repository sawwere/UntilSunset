using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(night());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator night()
    {
        Debug.Log("log");
        while (transform.position.y < 7.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.02f, gameObject.transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(10f);
        StartCoroutine(day());
    }
    public IEnumerator day()
    {
        Debug.Log("log");
        while (transform.position.y > 2.3f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y - 0.02f), gameObject.transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
