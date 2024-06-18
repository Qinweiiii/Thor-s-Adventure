using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip sniperRifle;
    public static AudioClip clickButton;
    public static AudioClip collectItems;
    public static AudioClip footsteps;
    public static AudioClip grenade;
    public static AudioClip carpetBomb;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        sniperRifle = Resources.Load<AudioClip>("SniperRifle");
        clickButton = Resources.Load<AudioClip>("ClickButton");
        collectItems = Resources.Load<AudioClip>("CollectItems");
        footsteps = Resources.Load<AudioClip>("Footsteps");
        grenade = Resources.Load<AudioClip>("Grenade");
        carpetBomb = Resources.Load<AudioClip>("CarpetBomb");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySniperRifle()
    {
        audioSrc.PlayOneShot(sniperRifle);
    }

    public static void PlayClickButton()
    {
        audioSrc.PlayOneShot(clickButton);
    }

    public static void PlayCollectItems()
    {
        audioSrc.PlayOneShot(collectItems);
    }

    public static void PlayFootsteps()
    {
        audioSrc.PlayOneShot(footsteps);
    }

    public static void PlayGrenade()
    {
        audioSrc.PlayOneShot(grenade);
    }

    public static void PlayCarpetBomb()
    {
        audioSrc.PlayOneShot(carpetBomb);
    }
}
