using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject nailPrefab;
    public GameObject plankPrefab;
    public static int maxNailAmmo = 10;
    public static int actualNailAmmo;
    public static int maxPlankAmmo = 6;
    public static int actualPlankAmmo;
    public static bool isReloading = false;
    public float reloadingCooldown;
    public double cooldownNailShooting;
    public double cooldownPlankShooting;  
    public Sprite fullPlank;
    public Sprite halfPlank;
    public Sprite emptyPlank;
    private SpriteRenderer sr;
    public Animator animator;
    


    // Update is called once per frame
    void Start()
    {
        actualPlankAmmo = 6;
        actualNailAmmo = maxNailAmmo;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = halfPlank;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (actualNailAmmo <= 0 && isReloading == false)
        {
            Reload();      

        }

        if (Input.GetButtonDown("R") && isReloading == false && actualNailAmmo != 10)
        {
            Reload();
        }

        if (reloadingCooldown <= Time.time && isReloading == true)
        {
            actualNailAmmo = maxNailAmmo;
            isReloading = false;
        }


        if (Input.GetButtonDown("Fire1") && isReloading == false && cooldownNailShooting <= Time.time)
        {
            //nailSound.Play();
            ShootNail();
            actualNailAmmo = actualNailAmmo - 1;
            cooldownNailShooting = Time.time + 0.3;
            animator.SetBool("IsShooting", true);
        }
        else
        {
            animator.SetBool("IsShooting", false);

        }

        if (Input.GetButtonDown("Fire2") && isReloading == false && cooldownPlankShooting <= Time.time && actualPlankAmmo >0)
        {
            ShootPlank();
            actualPlankAmmo = actualPlankAmmo - 1;
            cooldownPlankShooting = Time.time + 2;
        }

        if (actualPlankAmmo > maxPlankAmmo / 2 && !sr.sprite.Equals(fullPlank))
        {
            sr.sprite = fullPlank;

        }else if (actualPlankAmmo <= maxPlankAmmo / 2 && actualPlankAmmo >0 && !sr.sprite.Equals(halfPlank))
        {
            sr.sprite = halfPlank;
        }
        else if(actualPlankAmmo == 0 && !sr.sprite.Equals(emptyPlank))
        {
            sr.sprite = emptyPlank;
        }




    }

    void Reload()
    {
        isReloading = true;
        reloadingCooldown = Time.time + 2;
    }

    void ShootNail()
    {
        GameObject nail = Instantiate(nailPrefab, firePoint.position, firePoint.rotation);
        nail.GetComponent<Nail>().Target(firePoint.up);


    }

    void ShootPlank()
    {
        GameObject plank = Instantiate(plankPrefab, firePoint.position, firePoint.rotation);
        plank.GetComponent<Plank>().Target(firePoint.up);
    }
    public void RefillPlank()
    {
        actualPlankAmmo = maxPlankAmmo;
    }
}
