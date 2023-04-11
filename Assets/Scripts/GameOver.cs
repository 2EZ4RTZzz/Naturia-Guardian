using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {

        overPlane = GameObject.Find("MainCanvas").transform.GetChild(5).gameObject;
      
        yield return new WaitForSeconds(3f);
          GameOverTimer();
    }


  public GameObject overPlane;
  
    public void GameOverTimer()
    {


        Time.timeScale = 0;
        overPlane.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
