using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Shameless.Inventory
{
    public class ItemPickUp : MonoBehaviour
    {
        public GameObject buffInfo;
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI descriptionText;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Item item = collision.GetComponent<Item>();

            if (item != null)
            {
                if (item.itemDetails.canPickUp)
                {
                    InventoryManager.Instance.AddItem(item, true);
                }

                if (item.itemDetails.canActivate)
                {
                    iconImage.sprite = item.itemDetails.itemIcon;
                    nameText.text = item.itemDetails.name;
                    descriptionText.text = item.itemDetails.itemDescription;
                    buffInfo.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Item item = collision.GetComponent<Item>();

            if (item != null)
            {
                if (item.itemDetails.canActivate)
                {
                    buffInfo.SetActive(false);
                }
            }
        }
    }
}
