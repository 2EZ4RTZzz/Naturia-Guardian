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
        private bool isSelected = false;
        private GameObject[] craftingLst;
        [SerializeField] private GameObject unlockRecipeDisplay;
        public GameObject prefabItem;

        private void Update()
        {
            SelectBuff();
            unlockRecipeDisplay.GetComponent<UnlockCraftingRecipe>().Display();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag != "BuffTree")
            {
                Item item = collision.GetComponent<Item>();

                if (item != null)
                {
                    if (item.itemDetails.canPickUp)
                    {
                        InventoryManager.Instance.AddItem(item, true);
                    }

                    //buff的属性：canActivate
                    //检测当前item是否为buff
                    //如果是，打开buff选择面板
                    if (item.itemDetails.canActivate)
                    {
                        buffInfo.SetActive(true);
                        buffInfo.GetComponent<BuffInfo>().GetBuffID(item.itemDetails.itemID);
                        iconImage.sprite = item.itemDetails.itemIcon;
                        nameText.text = item.itemDetails.name;
                        descriptionText.text = item.itemDetails.itemDescription;
                        
                    }

                    if (item.itemDetails.canUse)
                    {
                        //Debug.Log("000");
                        if (item.itemID == 1020)
                        {
                            UnlockRecipe(1015);
                            UnlockRecipe(1016);
                            UnlockRecipe(1017);
                            UnlockRecipe(1018);
                            UnlockRecipe(1019);
                        }
                        Destroy(item.gameObject);
                    }
                }
            }
            else
            {
                buffInfo.SetActive(true);
                buffInfo.GetComponent<BuffInfo>().GetBuffID(collision.gameObject.GetComponent<BuffTree>().buffID);
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag != "BuffTree")
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
            else
            {
                buffInfo.SetActive(false);
                buffInfo.GetComponent<BuffInfo>().GetBuffID(0);
            }
           
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
                Item item = collision.GetComponent<Item>();
                if (isSelected && item != null)
                {
                    InventoryManager.Instance.ActivateBuff(item, true);
                }

        }

        private void SelectBuff()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                
                isSelected = true;
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                isSelected = false;
            }
        }

        private void UnlockRecipe(int ID)
        {
            for (int i=0; i< 2; i++)
            {
                bool breakLoop = false;
                if (i == 0) craftingLst = GameObject.FindGameObjectWithTag("Player").GetComponent<CraftingTable>().craftingList1;
                else if (i == 1) craftingLst = GameObject.FindGameObjectWithTag("Player").GetComponent<CraftingTable>().craftingList2;

                for (int j = 0; j < craftingLst.Length; j++)
                {
                    if (craftingLst[j].GetComponent<BuffInfo>().itemID == 0)
                    {
                        craftingLst[j].GetComponent<BuffInfo>().itemID = ID;
                        unlockRecipeDisplay.GetComponent<UnlockCraftingRecipe>().displayTimer = 1500;
                        breakLoop = true;
                        break;
                    }
                }

                if (breakLoop) break;
            }
        }
    }
}
