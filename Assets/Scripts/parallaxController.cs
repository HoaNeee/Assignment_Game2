using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class parallaxController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;
    float farthestBack = 0;

    [Range(0.01f, 0.05f)]
    public float parallaxSpeed = 0.03f;

    public Transform player;
    void Start()
    {
        parallaxSpeed = 0.03f;
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        if (mat != null)
        {
            for (int i = 0; i < backCount; i++)
            {
                backgrounds[i] = transform.GetChild(i).gameObject;
                mat[i] = backgrounds[i].GetComponent<Renderer>().material;
            }
            BackSpeedCalculate(backCount);
        }

    }


    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if (backgrounds[i].transform.position.z - cam.position.z > farthestBack)
            {
                if (backgrounds[i].transform.position.z - cam.position.z > farthestBack)
                    farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        //    transform.position = new Vector3(cam.position.x, 0f, 0f);
        //    distance = cam.position.x - camStartPos.x;
        //    if(mat == null) { 
        //        for (int i = 0; i < backgrounds.Length; i++)
        //        {
        //            float speed = backSpeed[i] * parallaxSpeed;
        //            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        //        }
        //    }
        //}
        if (player.position.x != camStartPos.x)
        {
            transform.position = new Vector3(cam.position.x, 0f, 0f);
            distance = cam.position.x - camStartPos.x;

            for (int i = 0; i < backgrounds.Length; i++)
            {
                // Check if mat and backgrounds[i].GetComponent<Renderer>() are not null
                if (mat != null && mat.Length > i && backgrounds[i].GetComponent<Renderer>() != null)
                {
                    float speed = backSpeed[i] * parallaxSpeed;
                    mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
                }
                else
                {
                    Debug.LogWarning("Material or Renderer component is null at index " + i);
                }
            }
        }

    }
}
