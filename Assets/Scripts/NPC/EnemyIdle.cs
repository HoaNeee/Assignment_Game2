using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIdle : MonoBehaviour
{
    public Slider thanhMau;
    public GameObject enemyGO;
    public bool isFacingRight;
    float facingTime;
    float nextFlip;
    
    // Start is called before the first frame update
    void Start()
    {
        
        facingTime = 4f;
        nextFlip = 0f;
        isFacingRight = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            Flip();
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 vector3 = enemyGO.transform.localScale;
        vector3.x *= -1;
        enemyGO.transform.localScale = vector3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            thanhMau.value -= 5;
            thanhMau.gameObject.SetActive(true);
            if (thanhMau.value <= 0)
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

    private IEnumerator AnThanhMau(float delay)
    {
        yield return new WaitForSeconds(delay);
        thanhMau.gameObject.SetActive(false);
    }

}
