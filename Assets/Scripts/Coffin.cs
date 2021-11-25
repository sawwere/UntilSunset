using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : Building
{
    protected override void Start()
    {
        maxHealth = 3;
        base.Start();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyCharacter e = other.gameObject.GetComponent<EnemyCharacter>();
        if (e)
        {
            Debug.Log("base under attack");
            RecieveDamage(e.damage);
            UIHealthBar.instance.SetValue(health / (float)maxHealth); // устанавливает новое значение для полоски здоровья
            Destroy(e.gameObject);
        }
    }
}
