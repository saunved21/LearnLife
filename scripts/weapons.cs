using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour
{
    public Camera fp_camera;
    public ParticleSystem muzzleflash;
   public GameObject h_e;
    
    [SerializeField] int range=10;
    [SerializeField]  int damage_W=1; //30 ig idk how 

    
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
             shoot();
            Debug.Log("weapon damage = "+damage_W);
        }
    }

    void shoot()
    {   
        playflash();
        RaycastHit hit;  
    
        if(Physics.Raycast(fp_camera.transform.position, fp_camera.transform.forward, out hit, range))
        {
            hiteffect(hit);
            enemy_health target = hit.transform.GetComponent<enemy_health>();
            if (target==null) return; 
            target.TakeDamage(damage_W);
            //Debug.Log("weapon damage = "+damage_W);
        }
        
        
       
    }

    void playflash()
    {
        muzzleflash.Play();

    }

    void hiteffect(RaycastHit hit)
    {   
       GameObject impact =  Instantiate(h_e, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact,1);
    }

}
