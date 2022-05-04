using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycleTutorial : TimeCycle
{
    //music
    //////////////

    public bool en = false;

    void Awake()
    {
        lght.intensity = 0;
    }
    // Start is called before the first frame update
    void Start()
    {


        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        //NightM.volume = vol;
        //DayM.volume = 0;
        isDay = false;
    }

    void FixedUpdate()
    {
        if (en)
        {
            GameTime++;
            isDay = true;
        }
        if (isDay && en)
        {
            if (fpd)
            {
                lght.intensity = 2 * ((float)GameTime / (float)DayLenght);
                if (GameTime > (DayLenght / 2))
                {
                    fpd = false;

                }
            }
            if (!player.GetIsBat() && !player.GetAtHome())
                player.StartCoroutine(nameof(player.TurnIntoBat));

            
            //StartCoroutine(SetDay());
            if (GameTime >= DayLenght)
            {
                en = false;
                //Debug.Log(en);
            }
        }

        //sky1.transform.position = new Vector3(sky1.transform.position.x + cloudSpeed, sky1.transform.position.y, sky1.transform.position.z);
        //if (sky2.transform.position.x <= 0)
        //{
        //    sky1.transform.position = new Vector3(0, sky1.transform.position.y, sky1.transform.position.z);
        //}
    }

    /*private IEnumerator SetNight()
    {
        DayM.volume = vol;
        while (DayM.volume > 0.01f)
        {
            DayM.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
        DayM.volume = 0.0f;
        NightM.volume = 0.0f;
        while (NightM.volume < vol)
        {
            NightM.volume += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }*/

    /*private IEnumerator SetDay()
    {
        NightM.volume = vol;
        while (NightM.volume > 0.01f)
        {
            NightM.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
        NightM.volume = 0.0f;
        DayM.volume = 0.0f;
        while (DayM.volume < vol)
        {
            DayM.volume += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }*/
}
