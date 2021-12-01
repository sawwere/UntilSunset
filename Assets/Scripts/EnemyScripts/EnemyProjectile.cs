using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private int damage;
    private int line;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    public void Launch(float force, int damage)
    {
        Debug.Log("launch");
        line = (int)transform.position.y;
        rigidbody2d.rotation = 45;
        //rigidbody2d.AddForce(direction * force, ForceMode2D.Impulse);  
        rigidbody2d.velocity = new Vector2( 1,1) * force;
        rigidbody2d.angularVelocity = - 90;
        this.damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(1);
        Building b = collision.collider.GetComponent<Building>();
        if ((b) &&(b.line==line))
        {
            Debug.Log("hit");
            b.RecieveDamage(damage);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rigidbody2d.rotation)); 
        if (transform.position.magnitude > 1000f)
            Destroy(gameObject);
    }
}
