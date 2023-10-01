using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
       [SerializeField] float hitpoints=4f;   // %2 ie 10 hitpoint = 5
       
       bool isdead = false; 


    public void TakeDamage(float damage)    
    {
        
        hitpoints -= damage; 
        Debug.Log("enemy too damage = "+damage);
         Debug.Log("health left = "+hitpoints);
         BroadcastMessage("Ondamage");
        if(hitpoints<=0)
        {
           // Destroy(gameObject);    
           die();
        }
    }

    public bool IsDead()
    {
        return isdead;
    }

    
    void die()
    {
        if (isdead) return;
        isdead=true;
        GetComponent<Animator>().SetTrigger("die");
    }

    
}
