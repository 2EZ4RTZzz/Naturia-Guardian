using System.Collections;
using System.Collections.Generic;
//switch scene
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalToNextRoom : MonoBehaviour
{
    public SavePlayerAttr attr;
    private PlayerAttributes player;

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
            Debug.Log("123");
            //port to the next room, get current level and increase one to the next.
            // buildIndex in the file->buildSetting
            SaveAttr();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
         }   
    }

    public void SaveAttr()
    {
        player = GameObject.Find("Players").GetComponent<PlayerAttributes>();
        attr.maxHP = player.maxHP;
        attr.maxMP = player.maxMP;
        attr.atk = player.atk;
        attr.def = player.def;
        attr.crit = player.crit;
        attr.critDmg = player.critDmg;
        attr.doge = player.doge;
        attr.currentHP = player.currentHP;
        attr.currentMP = player.currentMP;
        attr.pass = true;
    }
}
