using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int lifePoint;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 direction;
    float angle;
    GameObject player;
    public AudioSource damageAudio;
    public bool isDead;
    private Animation anim;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        damageAudio = GetComponent<AudioSource>();
        isDead = false;
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            Chase();
        }
    }

    public void Chase()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        Vector2 lookDir = (Vector2)player.transform.position - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
        if (transform.position != Vector3.zero)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Clou")
        {
            StartCoroutine (DestroyZombie(collision));
            ScoreScript.scoreKills = ScoreScript.scoreKills + 150;
        }
    }

    IEnumerator DestroyZombie(Collision2D collision)
    {
        damageAudio.Play();
        Destroy(collision.gameObject);
        animator.SetBool("IsHurt", true);
        GetComponent<PolygonCollider2D>().enabled = false;
        rb.velocity = Vector2.zero;
        isDead = true;
        yield return new WaitWhile(() => damageAudio.isPlaying);
        Destroy(gameObject);
    }
}
