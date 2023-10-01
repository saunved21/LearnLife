using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_weap : MonoBehaviour
{
    
    [SerializeField] int cw = 0;

    void Start()
    {   
        SetWeaponActive();
    }

    void Update() 
    {
        int prev_weap= cw;
        PrcoessKeyInput();
        ProcessScrollInput();

        if(prev_weap!=cw)
        {
            SetWeaponActive();
        }

    }

    void ProcessScrollInput()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(cw>= transform.childCount-1)
            {
                cw=0;
            }
            else
            {
                cw++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            if(cw>= transform.childCount-1)
            {
                cw=0;
            }
            else
            {
                cw++;
            }
        }
    }


    void PrcoessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cw=0;
        }
         if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cw=1;
        }
    }

    void SetWeaponActive()
    {
        int weap_index=0;
        
        foreach (Transform weapon in transform)
        {   
            if(weap_index==cw)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weap_index++;
        } 
    } 
}


