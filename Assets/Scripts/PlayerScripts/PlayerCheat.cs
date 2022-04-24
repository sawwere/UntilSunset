using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheat : MonoBehaviour
{
    private PlayerController pl;

    private KeyCode[] konamiCode = {
        KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow,
        KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow,
        KeyCode.B, KeyCode.A, KeyCode.Return};

    private Event e;
    private int ind = 0;

    private void Awake()
    {
        pl = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
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
                pl.ActivateCheat();
                ind = 0;
            }
        }
        else
            ind = 0;
    }
}
