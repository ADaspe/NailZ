using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundReload : MonoBehaviour
{
    public AudioSource reload;
    public bool krikric;
    private float cooldown;

    void Start()
    {
        reload = GetComponent<AudioSource>();
        krikric = Shooting.isReloading;
        cooldown = 0;
        
    }

    
    void Update()
    {
        krikric = Shooting.isReloading;
        if (krikric == true && cooldown <= Time.time)
        {
            reload.Play();
            cooldown = Time.time + 3;
        }
    }
}
