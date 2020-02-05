using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyProjectiles : MonoBehaviour
{
    private Collider2D wallCollider;
    [SerializeField]
    private Collider2D nailCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Clou" || collision.gameObject.tag == "Plank")
        {
            Destroy(collision.gameObject);
        }
    }


}
