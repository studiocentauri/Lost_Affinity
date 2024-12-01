using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private GameObject slot1;
    private GameObject slot2;
    private GameObject slot3;

    public Image slot1Image;
    public Image slot2Image;
    public Image slot3Image;

    private void Start()
    {
        UpdateUI();
    }

    public void AddItem(GameObject item)
    {
        if (slot1 == null)
        {
            slot1 = item;
        }
        else if (slot2 == null)
        {
            slot2 = item;
        }
        else if (slot3 == null)
        {
            slot3 = item;
        }
        else
        {
            Debug.Log("Inventory is full.");
            return;
        }

        item.SetActive(false);
        UpdateUI();
    }

    public void RemoveItem(int index, Vector2 position)
    {
        GameObject item = null;

        switch (index)
        {
            case 0:
                item = slot1;
                slot1 = null;
                break;
            case 1:
                item = slot2;
                slot2 = null;
                break;
            case 2:
                item = slot3;
                slot3 = null;
                break;
            default:
                Debug.Log("Invalid index.");
                return;
        }

        if (item != null)
        {
            Transform itemTransform = item.transform;
            Transform playerTransform = GameObject.FindWithTag("Player").transform;
            itemTransform.position = playerTransform.position;
            item.SetActive(true);
        }

        UpdateUI();
    }

    public GameObject GetItem(int index)
    {
        switch (index)
        {
            case 0:
                return slot1;
            case 1:
                return slot2;
            case 2:
                return slot3;
            default:
                return null;
        }
    }

    private void UpdateUI()
    {
        UpdateSlotUI(slot1, slot1Image);
        UpdateSlotUI(slot2, slot2Image);
        UpdateSlotUI(slot3, slot3Image);
    }

    private void UpdateSlotUI(GameObject slot, Image slotImage)
    {
        if (slot != null)
        {
            Color color = slotImage.color;
            color.a = 1.0f; // Opaque
            slotImage.color = color;
        }
        else
        {
            Color color = slotImage.color;
            color.a = 0.0f; // Transparent
            slotImage.color = color;
        }
    }
}