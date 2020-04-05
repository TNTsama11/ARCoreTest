using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour {

    // Use this for initialization
    public float xRotation = 0F;
    public float yRotation = 0F;
    void Update()
    {
        xRotation += Input.acceleration.x;
        yRotation += Input.acceleration.y;
        transform.eulerAngles = new Vector3(yRotation, xRotation, 0);
        if (xRotation < 25)
            xRotation = 25;
        else if (xRotation > 85)
            xRotation = 85;
        if (yRotation < 2)
            yRotation = 2;
        else if (yRotation > 10)
            yRotation = 10;
    }

}
