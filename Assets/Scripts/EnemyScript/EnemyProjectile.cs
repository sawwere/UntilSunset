using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private int line;


    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    public void Launch(float force)
    {
        Debug.Log("launch");
        line = (int)transform.position.y;
        //rigidbody2d.AddForce(direction * force, ForceMode2D.Impulse);  
        rigidbody2d.velocity = new Vector2( 1,1) * force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Wall_1 wall = collision.collider.GetComponent<Wall_1>();
        if ((wall) &&(wall.line==line))
        {
            Debug.Log("hit");
            wall.RecieveDamage(1);
        }
        Destroy(gameObject);
    }

    void Update()
    {
        if (transform.position.magnitude > 1000f)
            Destroy(gameObject);
    }
}
