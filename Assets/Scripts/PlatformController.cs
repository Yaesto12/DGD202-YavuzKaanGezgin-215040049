using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed;
    public float upperLimit;
    public float lowerLimit;
    public bool isGoingUp;


    // Update is called once per frame
    void Update()
    {
        if(isGoingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if(transform.position.y >= upperLimit)
            {
                isGoingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if(transform.position.y <= lowerLimit)
            {
                isGoingUp = true;
            }
        }
    }
}
