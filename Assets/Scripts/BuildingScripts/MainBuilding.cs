using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : Building
{
    
    protected override void Start()
    {
        maxHealth = 3;
        base.Start();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e)
        {
            e.EnterMainBuilding();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        EnemyCharacter e = collision.gameObject.GetComponent<EnemyCharacter>();
        if (e)
        {
            Debug.Log("base under attack");
            RecieveDamage(e.damage);
            UIHealthBar.instance.SetValue(health / (float)maxHealth); // ������������� ����� �������� ��� ������� ��������
        }
    }
}
