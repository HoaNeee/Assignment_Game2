using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBullet : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5f,rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        } else if(collision.gameObject.tag == "Mons")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Flower")
        {
            Destroy(collision.gameObject);
        }
    }
}
