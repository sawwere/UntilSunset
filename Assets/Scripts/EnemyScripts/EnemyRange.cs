using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyCharacter
{
    public GameObject target;
    public Vector2 targetPoint;

    public Animator animator;

    public GameObject projectilePrefab;

    //Расчет скорости для снаряда
    private float CalcForce(float x0, float x1)
    {
        float dist = System.Math.Abs(x0 - x1) - 0.5f;
        float D = (float)System.Math.Sqrt(0.43 * 0.43 - 4 * 0.173 * (-2.58 - dist));
        return (-0.43f + D) / (2f * 0.173f);
    }

    protected override void Update()
    {
        base.Update();
        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
        }
    }

    public override void DoDamage(IDamage obj)
    {
        if (target && hitTimer <= 0f)
        {
            animator.Play("Hit");
            speed = 0.0001f;
            Invoke(nameof(DoThrow), 1f);
            hitTimer = hitPeriod;
        }
    }

    public virtual void DoThrow()
    {
        speed = 1f;
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        EnemyProjectile projectile = projectileObject.GetComponent<EnemyProjectile>();
        IMovable b;

        if ((b = target.GetComponent<IMovable>()) != null)
        {
            targetPoint.x = System.Math.Abs(transform.position.x - b.GetPosition().x) < 1 ? b.GetPosition().x : b.GetPosition().x - b.GetSpeed() * 1f;
        }
        projectile.Launch(CalcForce(transform.position.x, targetPoint.x), this.damage, direction, line, this, isFriend);
    }

    public override void ChangeAnimationToWalk()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            animator.Play("Movement");
    }

    public override void ChangeAnimationToIdle()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Movement"))
            animator.Play("Idle");
    }
}
