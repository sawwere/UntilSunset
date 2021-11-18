using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // 
    protected int _line;
    protected int maxHealth;

    private int currentHealth;

    public int health
    {
        get { return currentHealth; }
        protected set { currentHealth = value; }
    }

    public int line
    {
        get { return _line; }
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        _line = (int)transform.position.y;
    }

    public void RecieveDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log(name + " has been destoyed");
        }
    }
}
