using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Shameless.Inventory;

public class BuffDetails : MonoBehaviour
{
    private int itemID;
    public ItemDetails itemDetails;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI buffName, buffDescription;
    [SerializeField] private GameObject seedTxt, confirmBtn;
    [SerializeField] private GameObject[] seedList;
    private int numInBag1=0, numInBag2=0, numInBag3=0, numInBag4=0;
    public InventoryBag_SO bag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * 给UpdateDetials传递Buff的ID，以更新Buff的详情页面UI显示
     * 在CraftingTable中的CraftingListHandler中调用
     */
    public void UpdateDetails(int ID)
    {
        itemID = ID;
        itemDetails = InventoryManager.Instance.GetItemDetails(itemID);
        if (itemID != 0)
        {
            icon.sprite = itemDetails.itemIcon;
            buffName.text = itemDetails.name;
            buffDescription.text = itemDetails.itemDescription;

            icon.gameObject.SetActive(true);
            buffDescription.gameObject.SetActive(true);
            seedTxt.SetActive(true);
            confirmBtn.SetActive(true);
        }
        else
        {
            icon.gameObject.SetActive(false);
            buffName.text = "???";
            buffDescription.gameObject.SetActive(false);
            seedTxt.SetActive(false);
            confirmBtn.SetActive(false);
        }
    

        if (itemID == 1002)
        {
            int ID1 = 1000;
            int ID2 = 0;
            int ID3 = 0;
            int ID4 = 0;

            int num1 = 3;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;

            SeedHandler(ID1, ID2, ID3, ID4, num1, num2, num3, num4);
        }
        else if (itemID == 1003)
        {
            int ID1 = 1000;
            int ID2 = 0;
            int ID3 = 0;
            int ID4 = 0;

            int num1 = 2;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;

            SeedHandler(ID1, ID2, ID3, ID4, num1, num2, num3, num4);
        }
        else if (itemID == 1004)
        {
            int ID1 = 1000;
            int ID2 = 0;
            int ID3 = 0;
            int ID4 = 0;

            int num1 = 4;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;

            SeedHandler(ID1, ID2, ID3, ID4, num1, num2, num3, num4);
        }
        else SeedHandler(0, 0, 0, 0, 0, 0, 0, 0);
    }

    /*
     * 显示buff所对应的合成所需的种子数量
     * 八个参数，前四个是种子对应的ID，后四个是合成所需种子的数量
     * 合成一个buff最多需要用到四种种子
     * 当ID = 0的时候，不需要种子
     * 在UpdateDetails里面调用该方法，直接复制上面的代码，然后修改参数
     */
    private void SeedHandler(int ID1, int ID2, int ID3, int ID4, int num1, int num2, int num3, int num4)
    {
        ItemDetails seedDetails1 = InventoryManager.Instance.GetItemDetails(ID1);
        ItemDetails seedDetails2 = InventoryManager.Instance.GetItemDetails(ID2);
        ItemDetails seedDetails3 = InventoryManager.Instance.GetItemDetails(ID3);
        ItemDetails seedDetails4 = InventoryManager.Instance.GetItemDetails(ID4);

        if (ID1 != 0)
        {
            seedList[0].SetActive(true);
            seedList[0].GetComponent<Image>().sprite = seedDetails1.itemIcon;
           
            for (int i=0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i].itemID == ID1)  numInBag1 = bag.itemList[i].itemAmount;
            }
            seedList[0].GetComponentInChildren<TextMeshProUGUI>().text = numInBag1 + "/" + num1;
        }
        else seedList[0].GetComponent<Image>().sprite = null;

        if (ID2 != 0)
        {
            seedList[1].SetActive(true);
            seedList[1].GetComponent<Image>().sprite = seedDetails2.itemIcon;
           
            for (int i = 0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i].itemID == ID2) numInBag2 = bag.itemList[i].itemAmount;
            }
            seedList[1].GetComponentInChildren<TextMeshProUGUI>().text = numInBag2 + "/" + num2;
        }
        else seedList[1].GetComponent<Image>().sprite = null;

        if (ID3 != 0)
        {
            seedList[2].SetActive(true);
            seedList[2].GetComponent<Image>().sprite = seedDetails3.itemIcon;
           
            for (int i = 0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i].itemID == ID3) numInBag3 = bag.itemList[i].itemAmount;
            }
            seedList[2].GetComponentInChildren<TextMeshProUGUI>().text = numInBag3 + "/" + num3;
        }
        else seedList[2].GetComponent<Image>().sprite = null;

        if (ID4 != 0)
        {
            seedList[3].SetActive(true);
            seedList[3].GetComponent<Image>().sprite = seedDetails4.itemIcon;
  
            for (int i = 0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i].itemID == ID4) numInBag4 = bag.itemList[i].itemAmount;
            }
            seedList[3].GetComponentInChildren<TextMeshProUGUI>().text = numInBag4 + "/" + num4;
        }
        else seedList[3].GetComponent<Image>().sprite = null;

        for (int i = 0; i < seedList.Length; i++)
        {
            if (seedList[i].GetComponent<Image>().sprite == null) seedList[i].SetActive(false);
        }
    }
}
