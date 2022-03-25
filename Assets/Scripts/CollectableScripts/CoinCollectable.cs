using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour
{
    private Resources resources;
    private AudioSource source;
    public AudioClip sound;

    private void Start()
    {
        resources = GameObject.Find("CoinsText").GetComponent<Resources>();
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        
        if (controller != null)
        {
            GameStats.Coins += 1;
            resources.UpdateCoins();
            source.PlayOneShot(sound, 1f);
            Destroy(gameObject);
        }
    }


}
