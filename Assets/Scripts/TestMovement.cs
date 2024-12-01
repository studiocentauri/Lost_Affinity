using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    public InventoryManager inventoryManager;
    private GameObject NearbyItem;
    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX=0.0f;
        if(Input.GetKey(KeyCode.A)){
            moveX=-1.0f;
        }
        if(Input.GetKey(KeyCode.D)){
            moveX=1.0f;
        }
        rb.velocity = new Vector2(moveX*speed, rb.velocity.y);
    }

    void Update(){
        if(NearbyItem!=null && Input.GetKeyDown(KeyCode.I)){
            inventoryManager.AddItem(NearbyItem);
            NearbyItem = null;
            Debug.Log("Item added to inventory");
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            inventoryManager.RemoveItem(0,transform.position);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            inventoryManager.RemoveItem(1,transform.position);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            inventoryManager.RemoveItem(2,transform.position);
        }
    }
    public void SetNearbyItem(GameObject item){
        NearbyItem = item;
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "item"){
            SetNearbyItem(other.gameObject);
        }
    }
    public void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag == "item"){
            SetNearbyItem(null);
        }
    }
}

