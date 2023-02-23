using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] private GameObject craftingTableDialogue;
    [SerializeField] private GameObject craftingTable;
    [SerializeField] private TextMeshProUGUI pageNoTxt;
    [SerializeField] private GameObject[] pageList;
    [SerializeField] private GameObject[] craftingList1, craftingList2;
    private int pageNo, craftingListIndex;
    private bool canOpenCraftingTable;
    // Start is called before the first frame update
    void Start()
    {
        canOpenCraftingTable = false;
        pageNo = 1;
        craftingListIndex = 1;
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

        Crafting();
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

    private void Crafting()
    {
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (craftingTable.activeSelf)
        {
            player.isCrafting = true;
            pageNoTxt.text = pageNo.ToString();

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (pageNo > 1) pageNo--;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (pageNo < 2) pageNo++;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (craftingListIndex > 1) craftingListIndex--;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (craftingListIndex < 5) craftingListIndex++;
            }

            int index = pageNo - 1;
            pageList[index].SetActive(true);
            for(int i=0; i<pageList.Length; i++)
            {
                if (i != index) pageList[i].SetActive(false);
            }

            if (pageNo == 1)
            {
                craftingList1[craftingListIndex-1].GetComponent<Image>().color = new Color(0.8f,0.8f, 0.8f, 1);
                for (int i=0; i<craftingList1.Length; i++)
                {
                    if (i != craftingListIndex - 1) craftingList1[i].GetComponent<Image>().color = Color.white;
                }
            }
            if (pageNo == 2)
            {
                craftingList2[craftingListIndex - 1].GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1);
                for (int i = 0; i < craftingList2.Length; i++)
                {
                    if (i != craftingListIndex - 1) craftingList2[i].GetComponent<Image>().color = Color.white;
                }
            }
        }
        else
        {
            player.isCrafting = false;
        }
    }
}
