using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform map;
    float speed = 6F;
    public bool inTrigger = false;
    
    void LateUpdate()
    {
        if(inTrigger == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, map.rotation, Time.deltaTime * speed);
        }
    }
}