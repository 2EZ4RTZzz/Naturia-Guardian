using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCraftingRecipe : MonoBehaviour
{
    public int displayTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //显示解锁Buff合成的提示
    public void Display()
    {
        if (displayTimer > 0)
        {
            displayTimer--;
            this.gameObject.SetActive(true);
            //Debug.Log(timer);
        }
        if (displayTimer <= 0) this.gameObject.SetActive(false);
    }
}
