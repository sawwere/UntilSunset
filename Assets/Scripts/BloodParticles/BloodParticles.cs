using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticles : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(Die), 0.5f);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
