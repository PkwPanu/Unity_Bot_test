using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    item item;
    public Button Removetton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
    }
}
