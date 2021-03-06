using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    Animator anim;
    public float timeOffset = 0.25f;
    void Awake()
    {
        anim = GetComponent<Animator>();
        Invoke(nameof(DestroyMe), anim.GetCurrentAnimatorClipInfo(0).Length - timeOffset);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
