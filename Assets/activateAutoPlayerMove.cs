using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateAutoPlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public InventoryManager inventoryManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(inventoryManager.redSlot != null && inventoryManager.blueSlot != null && inventoryManager.greenSlot != null)
        {
            AutoMovePlayerOnEnd _autoMovePlayerOnEnd = collision.gameObject.GetComponent<AutoMovePlayerOnEnd>();
            _autoMovePlayerOnEnd.enabled = true;
        }
    }
}
