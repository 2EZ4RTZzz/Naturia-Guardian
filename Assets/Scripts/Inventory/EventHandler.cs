using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler
{
    public static event Action<InventoryLocation, List<InventoryItem>> UpdateInventoryUI;
    public static event Action<InventoryLocation, List<InventoryItem>> UpdateBuffUI;

    public static void CallUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
    {
        UpdateInventoryUI?.Invoke(location, list);
    }

    public static void CallUpdateBuffUI(InventoryLocation location, List<InventoryItem> list)
    {
        UpdateBuffUI?.Invoke(location, list);
    }
}
