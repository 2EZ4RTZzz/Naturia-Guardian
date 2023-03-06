using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shameless.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("Player Bag UI")]
        [SerializeField] private GameObject bagUI;
        private bool bagOpened;
        private int bagIndex;

        [SerializeField] private SlotUI[] playerSlots;

        [Header("Player Bbuff UI")]
        [SerializeField] private GameObject buffUI;
        [SerializeField] private BuffSlotUI[] playerBuffs;

        private void OnEnable()
        {
            EventHandler.UpdateInventoryUI += OnUpdateInventoryUI;
            EventHandler.UpdateBuffUI += OnUpdateBuffUI;
        }

        private void OnDisable()
        {
            EventHandler.UpdateInventoryUI -= OnUpdateInventoryUI;
            EventHandler.UpdateBuffUI -= OnUpdateBuffUI;
        }

        private void Start()
        {
            bagIndex = 0;

            for (int i = 0; i < playerSlots.Length; i++)
            {
                playerSlots[i].slotIndex = i;
            }
            bagOpened = bagUI.activeInHierarchy;

            for (int i = 0; i < playerBuffs.Length; i++)
            {
                playerBuffs[i].slotIndex = i;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                OpenBagUI();
            }
            if (bagOpened)
            {
                UpdateSlotHighlight();
            }
        }

        private void OnUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
        {
            switch (location)
            {
                case InventoryLocation.Player:
                    for (int i = 0; i < playerSlots.Length; i++)
                    {
                        if (list[i].itemAmount > 0)
                        {
                            var item = InventoryManager.Instance.GetItemDetails(list[i].itemID);
                            playerSlots[i].UpdateSlot(item, list[i].itemAmount);
                        }
                        else
                        {
                            playerSlots[i].UpdateEmptySlot();
                        }
                    }
                    break;
            }
        }

        private void OnUpdateBuffUI(InventoryLocation location, List<InventoryItem> list)
        {
            switch (location)
            {
                case InventoryLocation.Player:
                    for (int i = 0; i < playerBuffs.Length; i++)
                    {
                        if (list[i].itemAmount > 0)
                        {
                            var item = InventoryManager.Instance.GetItemDetails(list[i].itemID);
                            playerBuffs[i].UpdateSlot(item, list[i].itemAmount/2);
                        }
                        else
                        {
                            playerBuffs[i].UpdateEmptySlot();
                        }
                    }
                    break;
            }
        }

        public void OpenBagUI()
        {
            PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            bagOpened = !bagOpened;
            bagUI.SetActive(bagOpened);
            if (bagUI.activeSelf) player.bagOpening = true;
            else player.bagOpening = false;
        }

        private void UpdateSlotHighlight()
        {
            playerSlots[bagIndex].slotHighlight.gameObject.SetActive(true);
            for (int i=0; i<playerSlots.Length; i++)
            {
                if (i != bagIndex) playerSlots[i].slotHighlight.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (bagIndex > 4) bagIndex -= 5;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (bagIndex < 20) bagIndex += 5;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (bagIndex > 0) bagIndex --;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (bagIndex < 24) bagIndex++;
            }
        }
    }
}
