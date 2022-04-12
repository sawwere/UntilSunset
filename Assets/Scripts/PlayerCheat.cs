using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheat : MonoBehaviour
{
    private PlayerController player;
    private bool[] cheatStady;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        cheatStady = new bool[9];
    }

    private void Update()
    {
        CheatStudy0();

        if (!cheatStady[0])
            return;

        CheatStudy1();

        if (!cheatStady[1])
            return;

        CheatStudy2();

        if (!cheatStady[2])
            return;

        CheatStudy3();

        if (!cheatStady[3])
            return;

        CheatStudy4();

        if (!cheatStady[4])
            return;

        CheatStudy5();

        if (!cheatStady[5])
            return;

        CheatStudy6();

        if (!cheatStady[6])
            return;

        CheatStudy7();

        if (!cheatStady[7])
            return;

        CheatStudy8();

        if (!cheatStady[8])
            return;

        CheatStudy9();
    }

    private void CheatStudy0()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cheatStady[0] = true;
            Invoke(nameof(NullCheatStudy), 3f);
        }
    }

    private void CheatStudy1()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cheatStady[1] = true;
        }
    }

    private void CheatStudy2()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cheatStady[2] = true;
        }
    }

    private void CheatStudy3()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cheatStady[3] = true;
        }
    }

    private void CheatStudy4()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cheatStady[4] = true;
        }
    }

    private void CheatStudy5()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cheatStady[5] = true;
        }
    }

    private void CheatStudy6()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cheatStady[6] = true;
        }
    }

    private void CheatStudy7()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cheatStady[7] = true;
        }
    }

    private void CheatStudy8()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            cheatStady[8] = true;
        }
    }

    private void CheatStudy9()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            NullCheatStudy();

            if (!player.isGod)
                player.SetGodSettings();
            else player.UnsetGodSettings();
        }
    }

    private void NullCheatStudy()
    {
        for (var i = 0; i < cheatStady.Length; i++)
            cheatStady[i] = false;
    }
}
