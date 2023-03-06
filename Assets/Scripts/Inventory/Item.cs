using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shameless.Inventory
{
    public class Item : MonoBehaviour
    {
        public int itemID;

        private SpriteRenderer spriteRenderer;

        public ItemDetails itemDetails;

        private BoxCollider2D coll;

        private void Awake()
        {
            if (!CompareTag("BuffTree"))
            {
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
                coll = GetComponent<BoxCollider2D>();
            }
        }

        private void Start()
        {
            if (itemID != 0)
            {
                Init(itemID);
            }
        }

        public void Init(int ID)
        {
            itemID = ID;

            itemDetails = InventoryManager.Instance.GetItemDetails(itemID);

            if (itemDetails != null)
            {
                spriteRenderer.sprite = itemDetails.itemOnWorldSprite != null ? itemDetails.itemOnWorldSprite : itemDetails.itemIcon;

                Vector2 newSize = new(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y);
                coll.size = newSize;
                coll.offset = new Vector2(0, spriteRenderer.sprite.bounds.center.y);
            }
        }
    }
}
