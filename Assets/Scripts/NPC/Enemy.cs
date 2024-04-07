using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //hp
    public Slider thanhMau;

    private int direction;
    Rigidbody2D rb;
    public float wSpeed;
    float timer;

    bool isFacingRight;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //isFacingRight = true;   
        wSpeed = 5f;
        direction = 1;
        //thanhMau.gameObject.SetActive(false);
    }

    private void Update()

    {
        timer += Time.deltaTime;
        if(timer > 3f)
        {
            
            rb.velocity = new Vector3(wSpeed * direction, 0, 0);
        }
        
    }
    
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barier"))
        {
            direction *= -1;
            rb.gameObject.transform.localScale = new Vector3(rb.gameObject.transform.localScale.x * -1, 1, 1);
            
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            direction *= -1;
            rb.gameObject.transform.localScale = new Vector3(rb.gameObject.transform.localScale.x * -1, 1, 1);
            
        } else if (collision.gameObject.CompareTag("Bullet"))
        {
            thanhMau.value -= 5;
            thanhMau.gameObject.SetActive(true);
            if(thanhMau.value <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(AnThanhMau(2f));
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mons"))
        {
            Destroy(gameObject);
        } else if(collision.CompareTag("Flower"))
        {
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator AnThanhMau(float delay)
    {
        yield return new WaitForSeconds(delay);
        thanhMau.gameObject.SetActive(false);
    }

}
