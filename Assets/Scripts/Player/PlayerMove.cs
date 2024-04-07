using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float move;
    public float rSpeed = 5f;
    private Rigidbody2D rb;
    bool facingRight;
   
    private float delayRun;

    public int do_cao = 12;
    
    public bool isGround = true;

    public Transform muiSung;
    public GameObject bullet;
    float fireTime = 0f;
    float nextFire = 0.1f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        //dieu khien phim 
        //move = rSpeed;
        //Movement(move);

        CharJump(); 
        CharFlip();
        CheckAnimation();

        if(Input.GetKeyDown(KeyCode.I) && GameManager.Instance.coin > 0)
        {
            CharFire();
            GameManager.Instance.coin--;
            GameManager.Instance.UpdateCoinText();
            anim.SetTrigger("Attack");
        }

    }
    private void FixedUpdate()
    {
        //move = Input.GetAxisRaw("Horizontal");
        //chay lien tuc
        delayRun += Time.deltaTime;
        
        if (delayRun > 3f)
        {
            move = 1;
            Movement(rSpeed);
            
        }

    }

    void Movement (float speed) {

        //move = Input.GetAxisRaw("Horizontal");
        //move = 1;
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        
    }

    void CharJump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGround)
        {
            rb.AddForce(Vector2.up * do_cao, ForceMode2D.Impulse);
            isGround = false;
            anim.SetBool("isJump", !isGround);
        }
    }

    void CharFlip()
    {
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void CharFire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireTime;

            if (facingRight)
            {
                Instantiate(bullet, muiSung.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            } else if (!facingRight)
            {
                Instantiate(bullet, muiSung.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
    void CheckAnimation()
    {
        anim.SetFloat("Move", Mathf.Abs(move));
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("isJump", !isGround);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("isJump", !isGround);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
