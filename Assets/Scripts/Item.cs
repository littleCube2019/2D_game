using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        food,
        bucket,
    }
    public Item(itemAttribute ItemAttribute)
    {
        itemType = ItemAttribute.itemType;
        itemSprite = ItemAttribute.itemSprite;
        amount = ItemAttribute.amount;
        stackable = ItemAttribute.stackable;
    }

    public ItemType itemType;
    public Sprite itemSprite;
    public int amount;
    public bool stackable;
}