using System.Collections;
using System.Collections.Generic;
//switch scene
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalToNextRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player")
         && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
         {
            //port to the next room, get current level and increase one to the next.
            // buildIndex in the file->buildSetting
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
         }   
    }
}
