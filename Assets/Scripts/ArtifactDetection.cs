using UnityEngine;

public class ArtifactDetection : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private GameObject NearbyItem;
    GameObject triggerObject;

    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();

        if (inventoryManager == null)
        {
            // Try to find InventoryManager on another GameObject
            inventoryManager = FindObjectOfType<InventoryManager>();
        }

        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager component not found.");
        }
    }

    void Update()
    {
        if (NearbyItem != null && Input.GetKeyDown(KeyCode.F))
        {
            inventoryManager.AddItem(NearbyItem);
            NearbyItem = null;
            //Debug.Log("Item added to inventory");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inventoryManager.GetItem("Blue") != null)
            {
                inventoryManager.RemoveItem("Blue", transform.position);

                //    Debug.Log("Blue item removed from inventory");
            }
            else
            {
                //  Debug.Log("No blue item to remove.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inventoryManager.GetItem("Green") != null)
            {
                inventoryManager.RemoveItem("Green", transform.position);
                //    Debug.Log("Green item removed from inventory");
            }
            else
            {
                //    Debug.Log("No green item to remove.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inventoryManager.GetItem("Red") != null)
            {
                inventoryManager.RemoveItem("Red", transform.position);
                //    Debug.Log("Red item removed from inventory");
            }
            else
            {
                //    Debug.Log("No red item to remove.");
            }
        }
    }

    public void SetNearbyItem(GameObject item)
    {
        NearbyItem = item;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueItem") || other.gameObject.CompareTag("GreenItem") || other.gameObject.CompareTag("RedItem"))
        {
            SetNearbyItem(other.gameObject);
            triggerObject = other.gameObject;
        }
        if (other.gameObject.CompareTag("BlueItem"))
        {
            other.gameObject.GetComponent<Scaling_new2>().enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueItem") || other.gameObject.CompareTag("GreenItem") || other.gameObject.CompareTag("RedItem") && triggerObject == other.gameObject)
        {
            SetNearbyItem(null);
        }
        if (other.gameObject.CompareTag("BlueItem"))
        {
            other.gameObject.GetComponent<Scaling_new2>().enabled = false;
        }
    }
}