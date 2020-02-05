using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField]
    public float nailSpeed;
    public Rigidbody2D rb;
    public AudioSource nailGun;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nailGun = GetComponent<AudioSource>();
        nailGun.Play();
    }

    void Update()
    {
        if(direction != null)
        {
            rb.velocity = direction * nailSpeed * Time.deltaTime;
        }
    }

    public void Target(Vector3 givenDirection)
    {
        direction = givenDirection.normalized;
    }
}
