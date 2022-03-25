using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikadze : EnemyClose
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        aviableHitMask = base.aviableHitMask | LayerMask.GetMask("NPC");
    }

    void BlowUp()
    {
        List<Collider2D> lst = new List<Collider2D>();
        var cf = new ContactFilter2D(); 
        cf.SetLayerMask(aviableHitMask); 
        cf.useLayerMask = true;
        transform.GetChild(0).GetComponent<BoxCollider2D>().OverlapCollider(cf, lst);
        for (int i = 0; i < lst.Count; ++i)
        {
            var obj = lst[i].GetComponent<IDamage>();
            if (obj != null)
            {
                obj.RecieveDamage(damage);
                Debug.Log(damage);
            }
        }
        EnemyKilled();
    }

    public override void DoDamage(IDamage obj)
    {
        //base.DoDamage(obj);
        BlowUp();
    }
}
