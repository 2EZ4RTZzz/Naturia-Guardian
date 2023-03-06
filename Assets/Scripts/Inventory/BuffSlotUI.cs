using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Shameless.Inventory
{
    public class BuffSlotUI : MonoBehaviour
    {
        [Header("Component Access")]
        [SerializeField] private Image buffImage;
        [SerializeField] private TextMeshProUGUI amountText;
        //public Image slotHighlight;
        //[SerializeField] private Button button;

        [Header("Slot Type")]
        public SlotType slotType;
        public bool isSelected;
        public int slotIndex;
        public ItemDetails itemDetails;
        public int itemAmount;

        private InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

        private void Start()
        {
            isSelected = false;

            if (itemDetails.itemID == 0)
            {
                UpdateEmptySlot();
            }
        }

        public void UpdateSlot(ItemDetails item, int amount)
        {
            itemDetails = item;
            buffImage.sprite = item.itemIcon;
            itemAmount = amount;
            amountText.text = amount.ToString();
            buffImage.enabled = true;
            amountText.enabled = true;
            //button.interactable = true;
        }

        public void UpdateEmptySlot()
        {
            if (isSelected)
            {
                isSelected = false;
            }

            buffImage.enabled = false;
            amountText.enabled = false;
            amountText.text = string.Empty;
            //button.interactable = false;
        }


    }
}
