using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ThunderZone : MonoBehaviour
{
    static List<EnemyCharacter> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<EnemyCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyCharacter>();
        if (enemy)
        {
            enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyCharacter>();
        if (enemy)
            enemies.Remove(enemy);
    }

    public static void Clear()
    {
        enemies.Clear();
    }

    public static int Count()
    {
        return enemies.Count();
    }

    public static void BeatEnemy(EnemyCharacter enemy)
    {
        /*if (enemies.Count == 0)
            return;*/
        //var enemy = enemies.OrderBy(x=>System.Math.Abs(x.GetPosition().x)).First();
        enemy.BecomeFriend();
        enemies.Remove(enemy);
    }
}
