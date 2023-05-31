using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemType> collectedItems = new List<ItemType>();
    public bool plankObtained = false;
    public bool swordObtained = false;

    public bool PickUp(ItemType type)
    {
        if (collectedItems.Contains(type) == false)
        {
            collectedItems.Add(type);
            return true;
        }

        return false;
    }

    public bool CheckItems(ItemType _items)
    {
        foreach(ItemType item in collectedItems)
        {
            if (item == _items)
            {
                return true;
            }
        }

        return false;
    }
}
