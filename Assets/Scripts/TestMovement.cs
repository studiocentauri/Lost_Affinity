using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private GameObject NearbyItem;
    private Rigidbody2D rb;
    public float speed = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventoryManager = GetComponent<InventoryManager>();

        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }

        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager component not found.");
        }
    }

    void FixedUpdate()
    {
        float moveX = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1.0f;
        }
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    void Update()
    {
        if (NearbyItem != null && Input.GetKeyDown(KeyCode.I))
        {
            inventoryManager.AddItem(NearbyItem);
            NearbyItem = null;
            Debug.Log("Item added to inventory");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inventoryManager.GetItem(0) != null)
            {
                inventoryManager.RemoveItem(0, transform.position);
                Debug.Log("Item removed from inventory");
            }
            else
            {
                Debug.Log("No item at index 0 to remove.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inventoryManager.GetItem(1) != null)
            {
                inventoryManager.RemoveItem(1, transform.position);
                Debug.Log("Item removed from inventory");
            }
            else
            {
                Debug.Log("No item at index 1 to remove.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inventoryManager.GetItem(2) != null)
            {
                inventoryManager.RemoveItem(2, transform.position);
                Debug.Log("Item removed from inventory");
            }
            else
            {
                Debug.Log("No item at index 2 to remove.");
            }
        }
    }

    public void SetNearbyItem(GameObject item)
    {
        NearbyItem = item;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "item")
        {
            SetNearbyItem(other.gameObject);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "item")
        {
            SetNearbyItem(null);
        }
    }
}