using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foliage : MonoBehaviour
{
    private bool isTriggered;

    SpriteRenderer sprite;

    private Color color;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.material.color;
        color.a = 1f;
        sprite.material.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            isTriggered = true;
            StartCoroutine(nameof(MakeInvisible));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            isTriggered = false;
            if (isActiveAndEnabled)
                StartCoroutine(nameof(MakeVisible));
            else MakeVisibleFoliage();
        }
    }

    IEnumerator MakeVisible()
    {
        float f = sprite.material.color.a;
        while (f < 1f && !isTriggered)
        {
            f = System.Math.Min(f + 0.03f, 1f);
            color.a = f;
            sprite.material.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator MakeInvisible()
    {
        float f = sprite.material.color.a;
        while (isTriggered && f > 0.5f)
        {
            f = System.Math.Max(f - 0.03f, 0.5f);
            color.a = f;
            sprite.material.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void MakeVisibleFoliage()
    {
        color.a = 1f;
        sprite.material.color = color;
    }
}
