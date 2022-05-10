using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 20;
    private TowerScript tw;
    public Vector3 direction = Vector3.left;
    public AudioClip CFlight;

    private void Start()
    {
        tw = transform.parent.GetComponent<TowerScript>();
        GameObject.Find("ResSounds").GetComponent<AudioSource>().PlayOneShot(CFlight, 0.55f);
    }

    private void Update()
    {
        float timeSinceLastFrame = Time.deltaTime;
        Vector3 translation = direction * speed * timeSinceLastFrame;
        transform.Translate(
          translation
        );
    }

    public void DoDamage(IDamage obj)
    {
        obj.RecieveDamage(5, DamageType.projectile);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            EnemyCharacter e = col.gameObject.GetComponent<EnemyCharacter>();
            if (e != null)
                DoDamage(e);
            Destroy(gameObject);
        }
    }
}
