using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikadze : EnemyClose
{
    public AudioClip CDeath;

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
        transform.GetChild(1).GetComponent<BoxCollider2D>().OverlapCollider(cf, lst);
        for (int i = 0; i < lst.Count; ++i)
        {
            var obj = lst[i].GetComponent<IDamage>();
            if (obj != null && lst[i] != gameObject.GetComponent<Collider2D>())
            {
                obj.RecieveDamage(damage);
            }
        }
        
        GameObject.Find("ResSounds").GetComponent<AudioSource>().PlayOneShot(CDeath, 1f);
        
        EnemyKilled();
    }

    public override void DoDamage(IDamage obj)
    {
        BlowUp();
    }
}
