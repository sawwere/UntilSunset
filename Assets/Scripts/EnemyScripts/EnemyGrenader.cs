using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyGrenader : EnemyRange
{
    [SerializeField] private int grenadeLimit = 3; //������������ ����� ������
    private int greandeCount;//������� ����� ������
    [SerializeField] private int grenadeDamage = 2;//���� �������
    [SerializeField] private int closeCombatDamage = 1;//���� � ������� ���
    private bool hasGrenades;//���� ��� �������� �������� ������, true - ������� ���

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        greandeCount = grenadeLimit;
        damage = grenadeDamage;
        hasGrenades = true;
    }

    protected override void Update()
    {
        if (hasGrenades)
            base.Update();
        else
        {
            if (immunityTimer > 0)
            {
                immunityTimer -= Time.deltaTime;
            }
        }
    }

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
                else if (hitTimer <= 1.25f)
                {
                    animator.Play("Hit");
                }
                else animator.Play("Idle");
            }
        }
    }

    //����������� ������� �������� ��� �� �������, ������ ����
    void BecomeCloseCombat()
    {
        damage = closeCombatDamage;
        hitTimer = firstHitPeriod;
        var hitBoxR = transform.GetChild(0);
        hitBoxR.gameObject.SetActive(false);

        var hitBoxC = transform.GetChild(2);
        hitBoxC.gameObject.SetActive(true);
    }
}
