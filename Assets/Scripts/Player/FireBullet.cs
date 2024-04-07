using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;

    public float aliveTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            rb.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        } else 
        {
            rb.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopBullet()
    {
        rb.velocity = new Vector2 (0, 0);
    }
}
