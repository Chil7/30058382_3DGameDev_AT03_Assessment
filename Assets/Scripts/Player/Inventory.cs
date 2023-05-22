using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemType> collectedItems = new List<ItemType>();
    public int taserShots = 0;

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

    public void LoadTaser(int _amount)
    {
        taserShots += _amount;
        Debug.Log(taserShots);
    }
}
