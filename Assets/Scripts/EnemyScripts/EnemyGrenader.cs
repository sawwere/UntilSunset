using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyGrenader : EnemyRange
{
    [SerializeField] private int grenadeLimit = 3; //максимальное число гранат
    private int greandeCount;//текущее число гранат
    [SerializeField] private int grenadeDamage = 2;//урон гранаты
    [SerializeField] private int closeCombatDamage = 1;//урон в ближнем бою
    //private bool hasGrenades;//флаг дл€ проверки текущего режима, true - дальний бой

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        greandeCount = grenadeLimit;
        damage = grenadeDamage;
        hasGrenades = greandeCount > 0;
    }

    //protected override void Update()
    //{
    //    base.Update();
    //}

    public override void DoThrow()
    {
        if (hasGrenades)
        {
            base.DoThrow();
            greandeCount--;
            if (greandeCount == 0)
            {
                hasGrenades = false;
                BecomeCloseCombat();
            }
            else
            {
                speed = 0.001f; // если поставить скорость = 0, то застыает на месте и перестает что-либо делать
            }
        }
        else
        {
            Debug.Log("ERROR");
        }
    }

    public override void DoDamage(IDamage obj)
    {
        if (hasGrenades)
            base.DoDamage(obj);
        else
        {
            //вз€то целиком из EnemyClose
            hitTimer -= Time.deltaTime;

            if (obj != null)
            {
                if (hitTimer <= 0)
                {
                    obj.RecieveDamage(damage);
                    hitTimer = hitPeriod;
                }
                else if ((hitTimer <= 2f && (obj is Wall wall)) || hitTimer <= 1f)
                {
                    animator.Play("Hit");
                }
            }
        }
    }

    //переключает хитбокс дальнего бо€ на ближний, мен€ет урон
    void BecomeCloseCombat()
    {
        damage = closeCombatDamage;
        hitTimer = firstHitPeriod;
        var hitBoxR = transform.GetChild(0); //ѕќћ≈Ќя“№ »Ќƒ≈ —  ќ√ƒј ƒќЅј¬»“—я  јЌ¬ј—
        hitBoxR.gameObject.SetActive(false);

        var hitBoxC = transform.GetChild(2);
        hitBoxC.gameObject.SetActive(true);
    }

    protected override void ResetAfterMissedTarget()
    {
        if (!target)
        {
            target = null;
            SpeedRestore();
        }
    }
}
