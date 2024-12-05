using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject blueSlot;
    public GameObject greenSlot;
    public GameObject redSlot;

    public Image blueSlotImage;
    public Image greenSlotImage;
    public Image redSlotImage;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        UpdateUI();
    }

    public void AddItem(GameObject item)
    {
        if (item.CompareTag("BlueItem") && blueSlot == null)
        {
            blueSlot = item;
        }
        else if (item.CompareTag("GreenItem") && greenSlot == null)
        {
            greenSlot = item;
        }
        else if (item.CompareTag("RedItem") && redSlot == null)
        {
            redSlot = item;
        }
        else
        {
            Debug.Log("Inventory is full or item does not match any slot.");
            return;
        }

        item.SetActive(false);
        UpdateUI();
    }

    public void RemoveItem(string color, Vector2 position)
    {
        GameObject item = null;

        switch (color)
        {
            case "Blue":
                item = blueSlot;
                blueSlot = null;
                break;
            case "Green":
                item = greenSlot;
                greenSlot = null;
                break;
            case "Red":
                item = redSlot;
                redSlot = null;
                break;
            default:
                Debug.Log("Invalid color.");
                return;
        }

        if (item != null)
        {
            Transform itemTransform = item.transform;
            Transform playerTransform = GameObject.FindWithTag("Player").transform;
            itemTransform.position = playerTransform.position + offset;
            item.SetActive(true);
        }

        UpdateUI();
    }

    public GameObject GetItem(string color)
    {
        switch (color)
        {
            case "Blue":
                return blueSlot;
            case "Green":
                return greenSlot;
            case "Red":
                return redSlot;
            default:
                return null;
        }
    }

    private void UpdateUI()
    {
        UpdateSlotUI(blueSlot, blueSlotImage);
        UpdateSlotUI(greenSlot, greenSlotImage);
        UpdateSlotUI(redSlot, redSlotImage);
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
            color.a = 0.5f; // Transparent
            slotImage.color = color;
        }
    }
}