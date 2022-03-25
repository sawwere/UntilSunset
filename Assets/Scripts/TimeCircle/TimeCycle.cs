using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCycle : MonoBehaviour
{
    public Light lght;
    [SerializeField] protected static int DayLenght = 3000;
    [SerializeField] protected static int NightLenght = 3000;
    public List<GameObject> spawners;
    public Text TimeTXT;
    public GameObject newwave;
    public NewWave nw;
    protected int GameTime = 0;  
    protected bool isDay = false;
    protected bool fpd = true;
    int lightintensity;
    public GameObject sky1;
    public GameObject sky2;
    public float cloudSpeed;

    protected PlayerController player;
    
    //music
    public GameObject DaymusObj;
    public GameObject NightmusObj;
    public AudioSource DayM;
    public AudioSource NightM;
    public float vol = 0.2f;
    //////////////
    public GameObject Moon;
    float xrange = 14.0f / DayLenght;
    float yrange = 10.0f / DayLenght;
    Animator Moonanimator;

    void Awake()
    {
        Moonanimator = Moon.GetComponent<Animator>();
        lght.intensity = 0;
        newwave.SetActive(false);
        foreach (var spawner in spawners)
            spawner.SetActive(false);
        foreach (var line in GameStats.enemyOnScreen)
            foreach (var enemy in line)
                enemy.ReturnToBase();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        NightM.volume = vol;
        DayM.volume = 0;
    }

    void FixedUpdate()
    {

        GameTime += 1;
        TimeTXT.text = GameTime.ToString();

        if (isDay)
        {

            if (GameTime > DayLenght)
            {
                Moonanimator.SetInteger("IsDayInt", 0);
                isDay = false;
                GameTime = 0;

                foreach (var spawner in spawners)
                    spawner.SetActive(false);
                foreach (var line in GameStats.enemyOnScreen)
                    foreach (var enemy in line)
                        enemy.ReturnToBase();
                Debug.Log("night");

                fpd = true;
                StartCoroutine(SetNight());
                //StartCoroutine(moon.night());
            }
            if (fpd)
            {
                lght.intensity = 2 * ((float)GameTime / (float)DayLenght);
                if (GameTime > (DayLenght / 2))
                {
                    fpd = false;
                    //StartCoroutine(sun.night());
                    
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
                Moonanimator.SetInteger("IsDayInt", 1);
                Debug.Log("day");
                GameTime = 0;
                GameStats.Encounter++;
                //StartCoroutine(sun.day());
                
                foreach (var spawner in spawners)
                {
                    spawner.SetActive(true);
                    spawner.GetComponent<SpawnerScript>().UpdateSpawn();
                }
                StartCoroutine(SetDay());
            }
        }

        sky1.transform.position = new Vector3(sky1.transform.position.x + cloudSpeed, sky1.transform.position.y, sky1.transform.position.z);
        if (sky2.transform.position.x <= 0)
        {
            sky1.transform.position = new Vector3(0, sky1.transform.position.y, sky1.transform.position.z);
        }



        //Moon and Sun Control
        //Debug.Log(xrange);
        Moon.transform.position = new Vector3((float)(-7 + xrange * GameTime), (float)(10.0f*Mathf.Sin((Mathf.PI/3000)*(GameTime))), 0);
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
