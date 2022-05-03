using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AndroidScript : MonoBehaviour
{
    public GameObject dialogBox2;
    public GameObject dialogBox3;
    public GameObject dialogBox4;
    public GameObject dialogBox5;
    void Start()
    {
#if (UNITY_ANDROID || UNITY_EDITOR)
        dialogBox2.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "»спользуйте джойстик дл€ передвижени€.";
        dialogBox3.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "„тобы посмотреть карту или, например, где наход€тс€ враги, ¬ы можете отдалить или приблизить камеру.";
        dialogBox4.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "¬ы можете превратитьс€ в летучую мышь и обратно, нажав самую правую нижнюю кнопку.ѕрин€в данный облик ¬ы передвигаетесь намного быстрее, однако тер€ете возможность выполн€ть некоторые действи€, например, добывать ресурсы.";
        dialogBox5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "—тоимость мыши 3 капли крови, они отображаютс€ в левом верхнем углу. „тобы выставить мышь на линию, где сейчас стоит вампир, нужно нажать кнопку с летучей мышью. " +
            "ћожно выставл€ть только по одной мыши на каждую линию. ћышь сама ищет врагов на своей линии и атакует их, при их отсутсвии она возвращаетс€ в дом." +
            " Ќочью выставленные мыши возвращаютс€ в дом и проинос€т 1 каплю кров";
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
