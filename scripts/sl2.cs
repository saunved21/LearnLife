using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sl2 : MonoBehaviour
{
    [SerializeField] string loadlevel;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadlevel);
        }
        
    }
}
