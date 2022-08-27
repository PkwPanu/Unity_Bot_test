using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<item> items = new List<item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;
    public InventoryItemController[] Inventory
    private void Awake()
    {
        Instance = this;
    }

    public void Add(item item)
    {
        items.Add(item);
    }

    public void Remove(item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        
        //Clean content before open
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
       

        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("itemname").GetComponent<Text>();
            var itemIcon = obj.transform.Find("otemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }

    public void EnablesItemRemoves()
    {
        if (EnableRemove.isOn)
        {
            
            foreach (Transform item in ItemContent)
            {
                item.Find("remove").gameObject.SetActive(true);
            }
        }
        else
        {
            
            foreach (Transform item in ItemContent)
            {
                item.Find("remove").gameObject.SetActive(false);
            }
        }
    }
}
