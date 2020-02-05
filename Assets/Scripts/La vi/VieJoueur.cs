using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VieJoueur : MonoBehaviour
{

    public int SanteJoueur = 3;
    public bool DmgJoueur;
    public int invincibility;
    public float countDown;
    public AudioSource damageAudio;
    public float countDownDeath;
    public bool isDying = false;
    public PlayerControler joueur;
    public Animator animator;
    
    void Start()
    {
        DmgJoueur = false;
        invincibility = 1;
        damageAudio = GetComponent<AudioSource>();
        isDying = false;
    }

    
    void Update()
    {
        if (SanteJoueur <= 0 && isDying == false)
        {
            isDying = true;
            
            countDownDeath = Time.time + 1;
        }

        if(isDying == true && countDownDeath <= Time.time)
        {
            SceneManager.LoadScene("DeathScene");
        }

    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie") && Time.time >= countDown)
        {
            DmgJoueur = true;
            damageAudio.Play();
            SanteJoueur--;
            countDown = Time.time + invincibility;
            animator.SetBool("IsHurt", true);
        }
        else
        {
            animator.SetBool("IsHurt", false);
        }
    }
    }



