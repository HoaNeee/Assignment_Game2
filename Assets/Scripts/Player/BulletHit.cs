using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHit : MonoBehaviour
{
    FireBullet fireBullet;
    

    private void Awake()
    {
        fireBullet = GetComponentInParent<FireBullet>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Mons")
        {
            fireBullet.StopBullet();
            Destroy(gameObject);
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mons")
        {
            fireBullet.StopBullet();
            Destroy(gameObject);
        }
    }
}
