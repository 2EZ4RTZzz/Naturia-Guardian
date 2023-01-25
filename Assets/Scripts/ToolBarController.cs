using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarController : MonoBehaviour
{
    public GameObject playerBag;
    private bool openBag;
    // Start is called before the first frame update
    void Start()
    {
        openBag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            OpenBag();

        if (openBag)
            playerBag.SetActive(true);
        else
            playerBag.SetActive(false);

    }

    void OpenBag()
    {
        if (openBag)
            openBag = false;
        else
            openBag = true;
    }
}
