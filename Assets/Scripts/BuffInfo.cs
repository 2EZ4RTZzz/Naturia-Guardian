using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Shameless.Inventory;

public class BuffInfo : MonoBehaviour
{
    public int itemID;
    public ItemDetails itemDetails;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI buffName;
    [SerializeField] private TextMeshProUGUI buffDescription;
    // Start is called before the first frame update
    void Start()
    {
        icon.gameObject.SetActive(false);
        buffName.text = "???"; 
    }

    // Update is called once per frame
    void Update()
    {
        if (itemID != 0)
        {
            icon.gameObject.SetActive(true);
            itemDetails = InventoryManager.Instance.GetItemDetails(itemID);
            icon.sprite = itemDetails.itemIcon;
            buffName.text = itemDetails.name;
            if (gameObject.CompareTag("BuffInfoPanel"))
            {
                buffDescription.text = itemDetails.itemDescription;
            }
        }    
    }

    public void GetBuffID(int ID)
    {
        itemID = ID;
    }
}
