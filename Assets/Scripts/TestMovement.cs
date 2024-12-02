using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private GameObject NearbyItem;
    private Rigidbody2D rb;
    public float speed = 5.0f;
    GameObject triggerObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        //float moveY = Input.GetAxisRaw("Vertical");
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
            if (inventoryManager.GetItem("Blue") != null)
            {
                inventoryManager.RemoveItem("Blue", transform.position);

                Debug.Log("Blue item removed from inventory");
            }
            else
            {
                Debug.Log("No blue item to remove.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inventoryManager.GetItem("Green") != null)
            {
                inventoryManager.RemoveItem("Green", transform.position);
                Debug.Log("Green item removed from inventory");
            }
            else
            {
                Debug.Log("No green item to remove.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inventoryManager.GetItem("Red") != null)
            {
                inventoryManager.RemoveItem("Red", transform.position);
                Debug.Log("Red item removed from inventory");
            }
            else
            {
                Debug.Log("No red item to remove.");
            }
        }
    }

    public void SetNearbyItem(GameObject item)
    {
        NearbyItem = item;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueItem") || other.gameObject.CompareTag("GreenItem") || other.gameObject.CompareTag("RedItem"))
        {
            SetNearbyItem(other.gameObject);
            triggerObject = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueItem") || other.gameObject.CompareTag("GreenItem") || other.gameObject.CompareTag("RedItem") && triggerObject == other.gameObject)
        {
            SetNearbyItem(null);
        }
    }
}