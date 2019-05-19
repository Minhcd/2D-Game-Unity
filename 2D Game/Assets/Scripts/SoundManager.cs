using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins, swords, destroy;
    public AudioSource adisrc;
    // Start is called before the first frame update
    void Start()
    {
        coins = Resources.Load<AudioClip>("Game coin");
        swords = Resources.Load<AudioClip>("Sword");
        destroy = Resources.Load<AudioClip>("Rock Crash");
        adisrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;

            case "swords":
                adisrc.clip = swords;
                adisrc.PlayOneShot(swords, 0.6f);
                break;

            case "destroy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 0.6f);
                break;
        }
    }
}
