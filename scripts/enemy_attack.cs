using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    player_health[] targets;
    
    [SerializeField] float damage_E = 4f;  

    void Start()
    {   
          targets = FindObjectsOfType<player_health>();
    }

    void attackHitEvent()
    {
        

        if (targets == null || targets.Length == 0) return;  // Check if the array is empty
        foreach (player_health target in targets)
        {
            target.TakeDamage(damage_E);
        }
        Debug.Log("bang");

    }
}
   
