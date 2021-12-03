using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCycle : MonoBehaviour
{
    public Light lght;
    int DayLenght = 5000;
    int NightLenght = 5000;
    public GameObject spawner;
    public Text TimeTXT;
    public GameObject newwave;
    public newwave nw;
    int GameTime = 0;
    bool isDay = true;
    bool fpd = true;
    int lightintensity;
    public GameObject sky1;
    public GameObject sky2;
    public float cloudSpeed;

    private PlayerController player;
    //music
    public GameObject DaymusObj;
    public GameObject NightmusObj;
    public AudioSource DayM;
    public AudioSource NightM;
    public float vol = 0.2f;
    //////////////


    // Start is called before the first frame update
    void Start()
    {
        //spawner.SetActive(false);
        //newwave.SetActive(false);
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        NightM.volume = 0;
        DayM.volume = vol;
    }

    void FixedUpdate()
    {

        GameTime += 1;
        TimeTXT.text = GameTime.ToString();

        if (isDay)
        {

            if (GameTime > DayLenght)
            {
                isDay = false;
                GameTime = 0;
                spawner.SetActive(false);
                fpd = true;
                StartCoroutine(SetNight());
            }
            if (fpd)
            {
                lght.intensity = 2 * ((float)GameTime / (float)DayLenght);
                if (GameTime > (DayLenght / 2))
                {
                    fpd = false;

                }
            }
            if (!fpd)
            {
                lght.intensity = 2 - 2 * ((float)GameTime / (float)DayLenght);
            }
        }
        else
        {
            if (GameTime > (NightLenght - (NightLenght / 10)))
            {
                nw.time = 200;
                newwave.SetActive(true);


            }
            if (GameTime > NightLenght)
            {
                if (!player.GetIsBat() && !player.GetAtHome())
                {
                    player.TurnIntoBat();
                }

                isDay = true;
                GameTime = 0;
                spawner.SetActive(true);
                StartCoroutine(SetDay());
            }
        }

        sky1.transform.position = new Vector3(sky1.transform.position.x + cloudSpeed, sky1.transform.position.y, sky1.transform.position.z);
        if (sky2.transform.position.x <= 0)
        {
            sky1.transform.position = new Vector3(0, sky1.transform.position.y, sky1.transform.position.z);
        }
    }

    public bool GetIsDay()
    {
        return isDay;
    }
    private IEnumerator SetNight()
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
    }

    private IEnumerator SetDay()
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
    }

}
