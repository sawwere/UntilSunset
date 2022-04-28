using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResourse : MonoBehaviour
{
    private Resources Res;

    // Start is called before the first frame update
    public void Start()
    {
        Res = GameObject.Find("CoinsText").GetComponent<Resources>();
   
    }

    public void Click()
    {
        if (GameStats.Wood < 700)
        {
            GameStats.Wood += 10;
            GameStats.Stone += 10;
            GameStats.Henchman += 10;
            Res.UpdateAll();
        }
    }

}
