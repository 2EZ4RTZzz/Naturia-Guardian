using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] private GameObject craftingTableDialogue;
    [SerializeField] private GameObject craftingTable;
    private bool canOpenCraftingTable;
    // Start is called before the first frame update
    void Start()
    {
        canOpenCraftingTable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpenCraftingTable)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                craftingTable.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                craftingTable.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CraftingTable")
        {
            craftingTableDialogue.SetActive(true);
            canOpenCraftingTable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CraftingTable")
        {
            craftingTableDialogue.SetActive(false);
            canOpenCraftingTable = false;
        }
    }
}
