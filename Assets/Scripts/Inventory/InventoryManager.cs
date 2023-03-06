using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shameless.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [Header("Item Data")]
        public ItemDataList_SO itemDataList_SO;
        [Header("Bag Data")]
        public InventoryBag_SO playerBag;
        public BuffState_SO buffState;

        private void Start()
        {
            InitializeGameData();
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }

        public ItemDetails GetItemDetails(int ID)
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == ID);
        }

        public void AddItem(Item item, bool toDestroy)
        {
            var index = GetItemIndexInBag(item.itemID);

            AddItemAtIndex(item.itemID, index, 1);

            if (toDestroy)
            {
                Destroy(item.gameObject);
            }

            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }

        public void ActivateBuff(Item item, bool toDestroy)
        {
            var index = GetBuffIndexInPlayer(item.itemID);

            AddBuffAtIndex(item.itemID, index, 1);

            if (toDestroy)
            {
                Destroy(item.gameObject);
            }
            EventHandler.CallUpdateBuffUI(InventoryLocation.Player, buffState.buffList);
        }

        private int GetItemIndexInBag(int ID)
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == ID)
                    return i;
            }
            return -1;
        }

        private int GetBuffIndexInPlayer(int ID)
        {
            for (int i = 0; i < buffState.buffList.Count; i++)
            {
                if (buffState.buffList[i].itemID == ID)
                    return i++;
            }
            return -1;
        }

        public bool CheckBagCapacity()
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == 0)
                    return true;
            }
            return false;
        }

        private void AddItemAtIndex(int ID, int index, int amount)
        {
            if (index == -1 && CheckBagCapacity())
            {
                var item = new InventoryItem { itemID = ID, itemAmount = amount };
                for (int i = 0; i < playerBag.itemList.Count; i++)
                {
                    if (playerBag.itemList[i].itemID == 0)
                    {
                        playerBag.itemList[i] = item;
                        break;
                    }
                }
            }
            else
            {
                int currentAmount = playerBag.itemList[index].itemAmount + amount;
                var item = new InventoryItem { itemID = ID, itemAmount = currentAmount };

                playerBag.itemList[index] = item;
            }
        }

        //amount可能没有用，但是我怕出错，所以先留着
        private void AddBuffAtIndex(int ID, int index, int amount)
        {
            if (index == -1)
            {
                var item = new InventoryItem { itemID = ID, itemAmount = amount };
                for (int i = 0; i < buffState.buffList.Count; i++)
                {
                    if (buffState.buffList[i].itemID == 0)
                    {
                        buffState.buffList[i] = item;
                        break;
                    }
                }
            }
            else
            {
                int currentAmount = buffState.buffList[index].itemAmount + amount;
                var item = new InventoryItem { itemID = ID, itemAmount = currentAmount };

                buffState.buffList[index] = item;
            }
        }

        private void InitializeGameData()
        {
            var emptyItem = new InventoryItem { itemID = 0, itemAmount = 0 };

            for (int i = 0; i < buffState.buffList.Count; i++)
            {
                buffState.buffList[i] = emptyItem;
            }

            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                playerBag.itemList[i] = emptyItem;
            }
        }
    }
}

