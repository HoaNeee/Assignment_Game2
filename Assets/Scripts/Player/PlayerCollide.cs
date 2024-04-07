using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCollide : MonoBehaviour
{
    public GameObject vucSau;
    public Transform reSpawnPoint;
    public GameObject panelEnd;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void CharDie()
    {
        if (panelEnd != null && !panelEnd.activeSelf)
        {
            panelEnd.SetActive(true);
            Time.timeScale = 0;
            rb.simulated = false;
        }
        //isPlayerDead = true;
    }

    public void RestartGame()
    {
        panelEnd.SetActive(false);
        //GameManager.Instance.UpdateHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        //transform.position = reSpawnPoint.position;
        //GameManager.Instance.UpdateTextHighScore();
        Time.timeScale = 1f;
        rb.simulated = true;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameManager.Instance.coin++;
            GameManager.Instance.UpdateCoinText();
            GameManager.Instance.UpdateHighScore();
            GameManager.Instance.UpdateTextHighScore();
            Destroy(collision.gameObject);
        } 
        else if (collision.gameObject == vucSau)
        {
            GameManager.Instance.UpdateHighScore();
            GameManager.Instance.UpdateTextHighScore();
            CharDie();
        } 
        else if (collision.gameObject.CompareTag("FlowerBullet"))
        {
            GameManager.Instance.UpdateHighScore();
            GameManager.Instance.UpdateTextHighScore();
            CharDie();
            Destroy(collision.gameObject);
        } 
        else if(collision.gameObject.CompareTag("Mons") || collision.gameObject.CompareTag("Flower"))
        {
            CharDie();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mons") || collision.gameObject.CompareTag("Flower"))
        {
            CharDie();
        }
    }
}
