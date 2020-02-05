using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField]
    public float plankSpeed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction != null)
        {
            rb.velocity = direction * plankSpeed * Time.deltaTime;
        }
    }
    public void Target(Vector3 givenDirection)
    {
        direction = givenDirection.normalized;
    }
}
