using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyGrenader : EnemyRange
{
    [SerializeField] private int grenadeLimit = 3; //������������ ����� ������
    private int greandeCount;//������� ����� ������
    [SerializeField] private int grenadeDamage = 20;//���� �������
    [SerializeField] private int closeCombatDamage = 10;//���� � ������� ���
    //private bool hasGrenades;//���� ��� �������� �������� ������, true - ������� ���

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        greandeCount = grenadeLimit;
        damage = grenadeDamage;
        hasGrenades = greandeCount > 0;
        hitAnim = "Throw";
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
                SpeedResetToZero(); 
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
            //����� ������� �� EnemyClose
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
                    animator.Play(hitAnim);
                }
            }
        }
    }

    //����������� ������� �������� ��� �� �������, ������ ����
    void BecomeCloseCombat()
    {
        hitAnim = "Hit";
        damage = closeCombatDamage;
        hitTimer = firstHitPeriod;
        var hitBoxR = transform.GetChild(1);
        hitBoxR.gameObject.SetActive(false);

        var hitBoxC = transform.GetChild(3);
        hitBoxC.gameObject.SetActive(true);
        hitBoxC.gameObject.layer = gameObject.layer;

        SpeedRestore();
    }

    protected override void ResetAfterMissedTarget()
    {
        if (!target && hasGrenades)
        {
            target = null;
            SpeedRestore();
        }
    }
}
