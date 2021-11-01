using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace_1 : MonoBehaviour
{

    public float displayTime = 10.0f;
    public GameObject dialogBox;
    public GameObject wall;
    float timerDisplay;


    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;         
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p != null)
        {
            //DisplayDialog();
            Instantiate(wall, transform.position, transform.rotation);
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
