using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using System.Linq;

public class MapRandom : MonoBehaviour
{
    public List<GameObject> listGround;// mang block ban do
    public List<GameObject> listEnemy;
    public Transform Player;
    public float rangeToDestroyObject = 50f;// Khoảng cách tạo hoặc hủy map
    public List<GameObject> listGroundOld;// mảng chứa các block được tạo ra 

    public List<GameObject> listEnemyOld;

    Vector3 endPos;
    Vector3 nextPos;

    int groundLen;

    //đồng coin
    //public List<GameObject> listCoin;
    //public List<GameObject> listCoinOld;
    //private int score = 0;
    //public TextMeshProUGUI coinText;
    //public TextMeshProUGUI scoreEnd;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(9.0f, 0f, 0.0f);
        generateBlockMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.position, endPos) < rangeToDestroyObject)
        {
            generateBlockMap();
        }


        //xóa obj khi đủ xa


        //GameObject getOneCoin = listCoinOld.FirstOrDefault();
        //if (getOneCoin != null && Vector2.Distance(Player.position, getOneCoin.transform.position) > rangeToDestroyObject)
        //{
        //    listCoinOld.Remove(getOneCoin);
        //    Destroy(getOneCoin);
        //}
        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(Player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }

        //xử lý ăn đồng xu

        //foreach (GameObject coin in listCoinOld.ToList())
        //{
        //    if (coin != null && Vector2.Distance(Player.position, coin.transform.position) < 2f)
        //    {
        //        listCoinOld.Remove(coin);
        //        Destroy(coin);
        //        //score += 1; // Tăng điểm khi ăn được đồng xu
        //        GameManager.Instance.coin++;
        //        scoreEnd.SetText(score.ToString());
        //        //Debug.Log("Score: " + score);

        //    }
        //}

        //coinText.SetText(GameManager.Instance.coin.ToString());
    }

    void generateBlockMap()
    {
        for (int i = 0; i < 5; i++)
        {
            float khoangCach = 0f;// khoảng cách ngẫu nhiên giữa các block
            nextPos = new Vector3(endPos.x + khoangCach, 0f, 0f);

            int groundID = Random.Range(0, listGround.Count);
            int xacsuat = Random.Range(0, 100);


            //tao ra ban do random
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(newGround);// thêm block đất vừa tạo vào mảng

            //test random enemy
            if(xacsuat < 20)
            {
                int enemyID = Random.Range(0, listEnemy.Count);
                GameObject newEnemy = Instantiate(listEnemy[enemyID], newGround.transform.position + new Vector3(-0.5f, 1f,0f),Quaternion.identity, transform);
                listEnemyOld.Add(newEnemy);
            }

            ////tạo đồng coin
            ///
            //if (xacsuat < 40)
            //{
            //    int coinID = Random.Range(0, listCoin.Count);
            //    GameObject newCoin = Instantiate(listCoin[coinID], newGround.transform.position + new Vector3(0f, Random.Range(1f, 4f), 0f), Quaternion.identity, transform);
            //    listCoinOld.Add(newCoin);


            //}

            switch (groundID)
            {
                case 0: groundLen = 5; break;
                case 1: groundLen = 6; break;
                case 2: groundLen = 7; break;
                case 3: groundLen = 9; break;
                case 4: groundLen = 12; break;

            }
            endPos = new Vector3(nextPos.x + groundLen, -2f, 0f);
        }

    }
}
