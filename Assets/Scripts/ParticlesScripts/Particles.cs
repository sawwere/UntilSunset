using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        Invoke(nameof(DestroyMe), anim.GetCurrentAnimatorClipInfo(0).Length - 0.25f);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
