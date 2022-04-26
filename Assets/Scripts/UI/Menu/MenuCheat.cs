using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCheat : MonoBehaviour
{

    private KeyCode[] konamiCode = {
        KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow,
        KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow,
        KeyCode.B, KeyCode.A, KeyCode.Return};

    private Event e;
    private int ind = 0;
    public MenuControls MC;

    private bool isUsed;

    private void Awake()
    {
        isUsed = PlayerPrefs.GetInt("Level") == 999;
    }

    private void OnGUI()
    {
        e = Event.current;
        if (e.isKey && Input.anyKeyDown && e.keyCode != KeyCode.None)
            KeyPressed(e.keyCode);
    }

    private void KeyPressed(KeyCode key)
    {
        if (konamiCode[ind] == key)
        {
            ind++;

            if (ind == konamiCode.Length)
            {
                PlayerPrefs.SetInt("Level", isUsed? 0 : 999);
                isUsed = !isUsed;
                Debug.Log("cheats");
                MC.PlayPressed();
                ind = 0;
            }
        }
        else
            ind = 0;
    }
}
