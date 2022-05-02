using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDropCollectable : MonoBehaviour
{
    private Resources resources;
    SpriteRenderer sprite;

    public double borderLeft = -14.5;
    public double borderRight = 14.5;

    private BoxCollider2D col;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        resources = GameObject.Find("HenchmenText").GetComponent<Resources>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
#if UNITY_ANDROID
        SetPESize(); // for Pocket Edition
#endif
        StartCoroutine(nameof(DissapearEffect));

        Invoke(nameof(Dissapear), 47.5f);
    }

    private void Dissapear()
    {
        Destroy(gameObject);
    }

    IEnumerator DissapearEffect()
    {
        float f = sprite.material.color.a;
        while (f > 0f)
        {
            f = System.Math.Max(f - 0.01f, 0f);
            Color color = sprite.material.color;
            color.a = f;
            sprite.material.color = color;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x > borderRight)
            transform.Translate(-0.01f, 0, 0);

        if (transform.position.x < borderLeft)
            transform.Translate(0.01f, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            GameStats.Henchman += 1;
            resources.UpdateHenchman();
            Destroy(gameObject);
        }
    }
    
    private void SetPESize()
    {
        col.size *= 2.3f; 
    }
}
