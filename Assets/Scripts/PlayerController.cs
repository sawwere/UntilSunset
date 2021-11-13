using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f; // скорость
    public float timeInvincible = 2.0f; // врем€ неу€звимости

    Rigidbody2D rigidbody2d;
    private float horizontal = 0; //координаты
    private float vertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
