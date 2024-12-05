using JetBrains.Annotations;
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
    public GameObject player;
    [SerializeField] Vector3 offset;
    public GameObject onCollisionText;
    public float delayTimeForText = 3f;
    [SerializeField] bool canSpawn;

    private void Start()
    {
        canSpawn = true;
        UpdateUI();
        if(onCollisionText!=null) onCollisionText.SetActive(false);
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
                if(canSpawn) blueSlot = null;
                break;
            case "Green":
                item = greenSlot;
                if(canSpawn) greenSlot = null;
                break;
            case "Red":
                item = redSlot;
                if(canSpawn) redSlot = null;
                break;
            default:
                Debug.Log("Invalid color.");
                return;
        }

        if (item != null)
        {
            Transform itemTransform = item.transform;
            itemTransform.position = player.transform.position + offset;
            //collision test
            if(!canSpawn)
            {
                if(onCollisionText != null) 
                {
                    onCollisionText.SetActive(true);
                    item.SetActive(false);
                    Invoke("stopText", delayTimeForText);
                }
                else    
                    item.SetActive(true);
            }
            else
            {
                item.SetActive(true);
            }
        }

        UpdateUI();
    }
    void Update()
    {
        float _x = player.GetComponent<Animator>().GetFloat("X");
        float _y = player.GetComponent<Animator>().GetFloat("Y");
        offset = new Vector3(_x ,_y, 0) * 2.0f;
            
        if(Physics2D.Raycast(transform.GetChild(0).position, offset, offset.magnitude)) canSpawn = false;
        else canSpawn = true;
        
    }
    void stopText()
    {
        onCollisionText.SetActive(false);
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