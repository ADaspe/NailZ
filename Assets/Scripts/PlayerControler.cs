using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    private Vector2 mousePos;
    float angle;
    public Animator animator; 

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 movement = new Vector2(moveInput.x, moveInput.y);

        if (movement != Vector2.zero)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

    }

    private void FixedUpdate()
    {
        rigidBody.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
        Vector2 lookDir = mousePos - rigidBody.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rigidBody.rotation = angle;
    }
}
