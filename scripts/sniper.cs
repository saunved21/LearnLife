using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniper : MonoBehaviour
{
    public Camera fpscam;
    public float normal = 60f;
    public float scope = 20f;

    bool zoom=false;

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            if(zoom==false)
            {
                zoom = true;
                fpscam.fieldOfView=scope;
            }
        }
        else
        {
            zoom=false;
            fpscam.fieldOfView=normal;
        }
        
    }    
}
