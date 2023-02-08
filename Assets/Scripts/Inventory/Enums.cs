/*
 * enums：枚举 枚举是一个被命名的整型常数的集合
 * 比如【星期】就是星期一，星期二，星期三，星期四，星期五的枚举
*/

//道具种类
public enum ItemType
{
    //可拾取类道具：种子，宝石
    Seed, Gem,
    //商品道具：buff合成表（种子也可以购买）
    BuffRecipe,
    //角色增强道具：合成buff，特殊强化buff
    SyntheticBuff, SpecialBuff
}

public enum InventoryLocation
{
    Player, Box
}
