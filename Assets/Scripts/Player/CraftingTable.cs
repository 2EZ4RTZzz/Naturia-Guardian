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
    public GameObject[] craftingList1, craftingList2;
    [SerializeField] private GameObject buffDetails;
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
                //buffDetails.GetComponent<BuffDetails>().craftingConfirmed();
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

    /*
     * 合成台列表选取和翻页的键盘操作
     */
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
                CraftingListHandler(craftingList1);
            }
            else if (pageNo == 2)
            {
                CraftingListHandler(craftingList2);
            }
        }
        else
        {
            player.isCrafting = false;
        }
    }

    /*
     * 当玩家键盘输入选取到Buff时，显示其对应的详情数据ß
     */
    private void CraftingListHandler(GameObject[] lst)
    {
        int index = craftingListIndex - 1;
        lst[index].GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1);
        buffDetails.GetComponent<BuffDetails>().UpdateDetails(lst[index].GetComponent<BuffInfo>().itemID);
        for (int i = 0; i < lst.Length; i++)
        {
            if (i != index) lst[i].GetComponent<Image>().color = Color.white;
        }
    }
}
