using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * CreateAssetMenu: Mark a ScriptableObject-derived type to be automatically listed in the Assets/Create submenu, so that instances of the type can be easily created and stored in the project as ".asset" files.
 * 可以在Assets窗口里右键添加一个按钮并快速创建一个ScriptableObject类型 (被我建在Assets/GameData里面的）
 * ScriptableObject: A ScriptableObject is a data container that you can use to save large amounts of data, independent of class instances.
 */

[CreateAssetMenu(fileName = "ItemDataList_SO", menuName = "Inventory/ItemDataList")]

//道具信息列表
public class ItemDataList_SO : ScriptableObject
{
    public List<ItemDetails> itemDetailsList;
}
