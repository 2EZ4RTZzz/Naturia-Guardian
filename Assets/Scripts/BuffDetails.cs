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
    private bool seedReady1 = false, seedReady2 = false, seedReady3 = false, seedReady4 = false;
    private bool seedConsumed1 = false, seedConsumed2 = false, seedConsumed3 = false, seedConsumed4 = false;
    private bool emptySeed1 = true, emptySeed2 = true, emptySeed3 = true, emptySeed4 = true;
    public InventoryBag_SO bag;
    public bool buffTreeGenerating = false;
    //public GameObject buffTree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        craftingConfirmed();
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
    

        if (itemID == 1010)
        {
            int ID1 = 1001;
            int ID2 = 1002;
            int ID3 = 0;
            int ID4 = 0;

            int num1 = 2;
            int num2 = 1;
            int num3 = 0;
            int num4 = 0;

            SeedHandler(ID1, ID2, ID3, ID4, num1, num2, num3, num4);
        }
        else if (itemID == 1011)
        {
            int ID1 = 1001;
            int ID2 = 0;
            int ID3 = 0;
            int ID4 = 0;

            int num1 = 3;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;

            SeedHandler(ID1, ID2, ID3, ID4, num1, num2, num3, num4);
        }
        else if (itemID == 1012)
        {
            int ID1 = 1003;
            int ID2 = 0;
            int ID3 = 0;
            int ID4 = 0;

            int num1 = 3;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;

            SeedHandler(ID1, ID2, ID3, ID4, num1, num2, num3, num4);
        }
        else if (itemID == 1013)
        {
            int ID1 = 1002;
            int ID2 = 1003;
            int ID3 = 0;
            int ID4 = 0;

            int num1 = 1;
            int num2 = 2;
            int num3 = 0;
            int num4 = 0;

            SeedHandler(ID1, ID2, ID3, ID4, num1, num2, num3, num4);
        }
        else if (itemID == 1014)
        {
            int ID1 = 1002;
            int ID2 = 0;
            int ID3 = 0;
            int ID4 = 0;

            int num1 = 3;
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
            emptySeed1 = false;
            seedList[0].SetActive(true);
            seedList[0].GetComponent<Image>().sprite = seedDetails1.itemIcon;

            for (int i = 0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i].itemID == ID1) numInBag1 = bag.itemList[i].itemAmount;
                if (seedConsumed1)
                {
                    int currentNum = bag.itemList[i].itemAmount - num1;
                    var item = new InventoryItem { itemID = ID1, itemAmount = currentNum };
                    bag.itemList[i] = item;
                    seedConsumed1 = false;
                }
            }
            seedList[0].GetComponentInChildren<TextMeshProUGUI>().text = numInBag1 + "/" + num1;
            if (numInBag1 >= num1) seedReady1 = true;
            else seedReady1 = false;
        }
        else
        {
            emptySeed1 = true;
            seedReady1 = true;
            seedList[0].GetComponent<Image>().sprite = null;
        }

        if (ID2 != 0)
        {
            emptySeed2 = false;
            seedList[1].SetActive(true);
            seedList[1].GetComponent<Image>().sprite = seedDetails2.itemIcon;

            for (int i = 0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i].itemID == ID2) numInBag2 = bag.itemList[i].itemAmount;
                if (seedConsumed2)
                {
                    int currentNum = bag.itemList[i].itemAmount - num2;
                    var item = new InventoryItem { itemID = ID2, itemAmount = currentNum };
                    bag.itemList[i] = item;
                    seedConsumed2 = false;
                }
            }
            seedList[1].GetComponentInChildren<TextMeshProUGUI>().text = numInBag2 + "/" + num2;
            if (numInBag2 >= num2) seedReady2 = true;
            else seedReady2 = false;
        }
        else
        {
            emptySeed2 = true;
            seedReady2 = true;
            seedList[1].GetComponent<Image>().sprite = null;
        }

        if (ID3 != 0)
        {
            emptySeed3 = false;
            seedList[2].SetActive(true);
            seedList[2].GetComponent<Image>().sprite = seedDetails3.itemIcon;

            for (int i = 0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i].itemID == ID3) numInBag3 = bag.itemList[i].itemAmount;
                if (seedConsumed3)
                {
                    int currentNum = bag.itemList[i].itemAmount - num3;
                    var item = new InventoryItem { itemID = ID3, itemAmount = currentNum };
                    bag.itemList[i] = item;
                    seedConsumed3 = false;
                }
            }
            seedList[2].GetComponentInChildren<TextMeshProUGUI>().text = numInBag3 + "/" + num3;
            if (numInBag3 >= num3) seedReady3 = true;
            else seedReady3 = false;
        }
        else
        {
            emptySeed3 = true;
            seedReady3 = true;
            seedList[2].GetComponent<Image>().sprite = null;
        }

        if (ID4 != 0)
        {
            emptySeed4 = false;
            seedList[3].SetActive(true);
            seedList[3].GetComponent<Image>().sprite = seedDetails4.itemIcon;

            for (int i = 0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i].itemID == ID4) numInBag4 = bag.itemList[i].itemAmount;
                if (seedConsumed4)
                {
                    int currentNum = bag.itemList[i].itemAmount - num4;
                    var item = new InventoryItem { itemID = ID4, itemAmount = currentNum };
                    bag.itemList[i] = item;
                    seedConsumed4 = false;
                }
            }
            seedList[3].GetComponentInChildren<TextMeshProUGUI>().text = numInBag4 + "/" + num4;
            if (numInBag4 >= num4) seedReady4 = true;
            else seedReady4 = false;
        }
        else
        {
            emptySeed4 = true;
            seedReady4 = true;
            seedList[3].GetComponent<Image>().sprite = null;
        }

        for (int i = 0; i < seedList.Length; i++)
        {
            if (seedList[i].GetComponent<Image>().sprite == null) seedList[i].SetActive(false);
        }
    }

    public void craftingConfirmed()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (seedReady4 && seedReady3 && seedReady2 && seedReady1 &&
                (!emptySeed4 || !emptySeed3 || !emptySeed2 || !emptySeed1))
            {
                seedConsumed1 = true;
                seedConsumed2 = true;
                seedConsumed3 = true;
                seedConsumed4 = true;
                buffTreeGenerating = true;
                Debug.Log("done");
            }
            else
            {
                Debug.Log("not enough");
            }
        }
    }

    public int SetBuffID()
    {
        return itemID;
    }
}
