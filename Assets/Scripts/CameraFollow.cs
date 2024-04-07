using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    Vector3 offset;
    public float lowY;
    public float highY;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
        if (transform.position.y > highY)
        {
            transform.position = new Vector3(transform.position.x, highY, transform.position.z);
        }


    }
}
