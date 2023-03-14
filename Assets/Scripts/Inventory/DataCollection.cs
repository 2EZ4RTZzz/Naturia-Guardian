using UnityEngine;

/*
 * [System.Serializable]：Indicates that a class or a struct can be serialized.
 * 可以用作把class显示在inspector窗口
 */

//道具详细信息
[System.Serializable]
public class ItemDetails
{
    public int itemID;

    public string name;

    public ItemType itemType;

    public Sprite itemIcon;

    public Sprite itemOnWorldSprite;

    public string itemDescription;

    public int itemUseRadius; //暂时不知道干嘛的

    public bool canPickUp;

    public bool canTrade; //道具可以被交易

    public bool canSynthesize; //道具可以被合成

    public bool canActivate; //buff可以被激活

    public bool canUse;
}

[System.Serializable]
public struct InventoryItem
{
    public int itemID;

    public int itemAmount;
}

[System.Serializable]
public class SkillDetails
{
    public string skillName;
    public Sprite skillIcon;
    public float cd;
    public int mp;
    public float dmgFactor;
    private float dmg;
}
