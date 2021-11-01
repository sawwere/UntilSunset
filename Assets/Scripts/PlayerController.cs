using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f; // скорость
    public float timeInvincible = 2.0f; // время неуязвимости
    public int maxHealth = 5; // здоровье


    Rigidbody2D rigidbody2d;
    private int currentHealth; // текущее здоровье
    private float horizontal = 0; //координаты
    private float vertical = 0;
    public int Health { get { return currentHealth; } }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed  * horizontal * Time.deltaTime;
        if ((vertical < 0) && (position.y > -1))
            position.y -= 1;
        if ((vertical > 0) && (position.y < 1))
            position.y += 1;
        vertical = 0;
        rigidbody2d.MovePosition(position);
        //Debug.Log(rigidbody2D.position);
        
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.DownArrow))
            vertical = -1;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            vertical = 1;
    }
}
