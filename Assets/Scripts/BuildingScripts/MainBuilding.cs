using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour
{
    public GameObject facade = null;

    private bool isTriggered;

    SpriteRenderer sprite;

    void Start()
    {
        sprite = facade.GetComponent<SpriteRenderer>();
        Color color = sprite.material.color;
        color.a = 0f;
        sprite.material.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyCharacter enemy = collision.gameObject.GetComponent<EnemyCharacter>();
        if (enemy)
        {
            enemy.EnterMainBuilding();
        }

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            player.EnterMainBuilding();
            isTriggered = true;
            StartCoroutine(nameof(MakeInvisible));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            player.ExitMainBuilding();
            isTriggered = false;
            StartCoroutine(nameof(MakeVisible));
        }
    }

    IEnumerator MakeVisible()
    {
        float f = sprite.material.color.a;
        while (f < 1f && !isTriggered)
        {
            f = System.Math.Min(f + 0.03f, 1f);
            Color color = sprite.material.color;
            color.a = f;
            sprite.material.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator MakeInvisible()
    {
        float f = sprite.material.color.a;
        while (isTriggered && f > 0f)
        {
            f = System.Math.Max(f - 0.03f, 0f);
            Color color = sprite.material.color;
            color.a = f;
            sprite.material.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
