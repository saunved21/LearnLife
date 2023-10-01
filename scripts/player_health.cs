 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
       [SerializeField]  float health = 2f;
       

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            // GetComponent<death_handler>().handle_death();
            FindObjectOfType<switch_weap>().enabled=false;
            FindObjectOfType<weapons>().enabled=false;
           
        }
    }

    
    
}
