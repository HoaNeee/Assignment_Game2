using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CoinRandom : MonoBehaviour
{
    public Transform player;
    public GameObject coinPrefab;
    private float khoangCach;

    //ve theo ham sin
    private float do_rong_Sin;
    private float chieu_cao_Sin;
    private float chieu_cao;
    private float chieu_cao_toi_thieu;

    //ve theo parabol
    private Vector3 nextPos;

    private float nextPosX;
    private float nextPosY;

    private int soLuongCoin;
    private float thoiGian;
    private float timer;

    private Vector3 lastPosition;
    public bool isPlayerIdle;
    
    private void Start()
    {
        khoangCach = 20f;
        chieu_cao_toi_thieu = 1f;
        thoiGian = 5f;
        soLuongCoin = 13;
        timer = 0;
        lastPosition = player.position;

        SpawnCoinParabol();
        
    }
    private void Update()
    {
        //test random 
        if(lastPosition == player.position)
        {
            isPlayerIdle = true;
            timer = 2f;
        }
        else
        {
            isPlayerIdle=false;
            lastPosition = player.position;

        }

        if (!isPlayerIdle)
        {
            int xacSuat = Random.Range(0, 100);
            timer += Time.deltaTime;
            if (xacSuat < 5)
            {
                if (timer > thoiGian)
                {

                    //SpawnCoin();
                    SpawnCoinParabol();
                    timer = 0;

                }
            }
        }
    }

    private void SpawnCoin()
    {
        chieu_cao = Random.Range(2f, 4f) + chieu_cao_toi_thieu;
        nextPosX = player.position.x + khoangCach;

        chieu_cao_Sin = 3.5f;
        do_rong_Sin = 3.5f;

        for (int i = 1; i < soLuongCoin; i++)
        {
            //hình sin
            nextPosY = Mathf.Abs(chieu_cao_Sin * Mathf.Sin(nextPosX / do_rong_Sin)) + chieu_cao;
            Instantiate(coinPrefab, new Vector3(nextPosX, nextPosY, 0f), Quaternion.identity, transform);
            nextPosX++;

        }
    }

    private void SpawnCoinParabol()
    {
        nextPos = player.position + new Vector3(khoangCach,0f, 0f);
        int soLuongCoin2 = Random.Range(2, 7);

        for(int i = -1*soLuongCoin2; i<=soLuongCoin2; i++)
        {
            Vector3 toaDo = nextPos + new Vector3(i + soLuongCoin2, -1 * 0.2f * i * i + 0.2f * soLuongCoin2 * soLuongCoin2 + 0.5f, 0f);
            Instantiate(coinPrefab, toaDo, Quaternion.identity, transform);
        }


        
    }
}

  
