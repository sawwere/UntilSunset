using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newwave : MonoBehaviour
{
    public int time = 400;
    private Vector4 Color;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Color = new Vector4(255.0f,255.0f, 255.0f, (float)time/400);
        gameObject.GetComponent<Image> ().color = Color;
        time -= 1;
        if (time <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
