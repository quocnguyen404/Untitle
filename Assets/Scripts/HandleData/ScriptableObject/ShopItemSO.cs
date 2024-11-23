using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewShopItem", menuName ="Shop/Item")]
public class ShopItemSO : ScriptableObject
{
    public string itemName;
    public int itemPrice;
}
