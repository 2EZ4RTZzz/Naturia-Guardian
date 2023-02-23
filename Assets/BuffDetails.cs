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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDetails(int ID)
    {
        itemID = ID;
        itemDetails = InventoryManager.Instance.GetItemDetails(itemID);
        icon.sprite = itemDetails.itemIcon;
        buffName.text = itemDetails.name;
        buffDescription.text = itemDetails.itemDescription;
    }
}
