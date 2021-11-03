using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyCharacter
{
    public Building target;
    public Vector2 targetPoint;

    public GameObject projectilePrefab;

    //Расчет скорости для снаряда
    private float CalcForce(float x0, float x1)
    {
        float dist = System.Math.Abs(x0 - x1) - 0.5f;
        float D = (float)System.Math.Sqrt(0.43 * 0.43 - 4 * 0.173 * (-2.58 - dist));
        return (-0.43f + D) / (2f * 0.173f);
    }

    public void DoDamage(Collider2D collision)
    {
        if (target)
        {
            //Debug.Log(hitTimer);
            if (hitTimer <= 0)
            {

                Debug.Log("ATACKING", target);
                GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
                EnemyProjectile projectile = projectileObject.GetComponent<EnemyProjectile>();

                projectile.Launch(direction * CalcForce(transform.position.x, targetPoint.x), this.damage);
                hitTimer = hitPeriod;
            }
        }
    }

}
