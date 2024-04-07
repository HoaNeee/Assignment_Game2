using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMove : MonoBehaviour
{
    private Rigidbody2D rb; //private Rigidbody2D rb;

    //Khai báo biến tham số
    //Tốc độ di chuyển
    public float moveSpeed;
    //Tốc độ nhảy
    public float do_cao;
    public bool isGround = true;
    int maxJumpCount = 1;
    public int jumpCount = 0;
    

    //nhân vật die
    
    private bool isPlayerDead = false;
    public GameObject vucSau;

    //panel
    public GameObject panelEnd;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        do_cao = 10f;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayerDead && jumpCount < maxJumpCount)
        {
            CharJump(do_cao);
        }

       
    }
    private void FixedUpdate()
    {
        CharRun(moveSpeed);
    }

    void CharJump(float jumpHeight)
    {
        if(Input.GetKeyDown(KeyCode.Space) ) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    void CharRun(float speed)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void CharDie()
    {
        panelEnd.SetActive(true);
        Time.timeScale = 0;
        rb.simulated = false;
        isPlayerDead = true;
    }

    public void RestartGame()
    {
        panelEnd.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        rb.simulated = true;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            jumpCount = 0;
        }
        if (collision.gameObject == vucSau)
        {
            //Debug.Log("Player is dead");
            CharDie();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

}
