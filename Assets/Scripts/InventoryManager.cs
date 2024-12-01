using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<GameObject> inventory = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        inventory.Add(item);
        item.SetActive(false);
    }

    public void RemoveItem(int index,Vector2 position)
    {
        if(index>=0 && index<inventory.Count){

            GameObject item = inventory[index];
            inventory.RemoveAt(index);
            Transform itemTransform = item.transform;
            Transform playerTransform = GameObject.FindWithTag("Player").transform;
            itemTransform.position = playerTransform.position;
            item.SetActive(true);

        }
        

    }
}
