using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> itemList;


    public int size(){
        return itemList.Count;
    }
    public Inventory()
    {
        itemList = new List<Item>();
      
    }
    public void addItem(Item item)
    {
        if (!item.stackable)
        {
            itemList.Add(item);
        }
        else
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (item.itemType == itemList[i].itemType)
                {
                    itemList[i].amount += item.amount;
                    return;
                }
            }
            itemList.Add(item);
        }
    }

    public void useItem(int number ){
        if (number >= size())
        {
            return;
        }
        itemList[number].amount -= 1;
        /*
        觸發item的效果
        */
        if (itemList[number].amount <= 0)
        {
            itemList.RemoveAt(number);
        }
    }

    public List<Item> getInventory()
    {
        return itemList;
    }
}
