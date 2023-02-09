using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shameless.Inventory
{
    public class ItemPickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Item item = collision.GetComponent<Item>();

            if (item != null)
            {
                if (item.itemDetails.canPickUp)
                {
                    InventoryManager.Instance.AddItem(item, true);
                }
            }
        }
    }
}
