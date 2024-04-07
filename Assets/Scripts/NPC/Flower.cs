using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject flowerBulletPrefab;
    public Transform viTriBan;
    public float timer;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3f )
        {
            anim.SetTrigger("atk");
            timer = 0f;
        }
    }
    public void FlowerFire()
    {
        Instantiate(flowerBulletPrefab, viTriBan.position, Quaternion.identity);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mons"))
        {
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
