using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    public Transform hoverObject;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = hoverObject.position;
        pos.x+= speed * Time.deltaTime;
        hoverObject.position = pos;
    }
}
