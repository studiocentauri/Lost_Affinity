using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private AutoMoveNPCs mover;
    private float moveSpeedX;
    private float moveSpeedY;

    private Vector2 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<AutoMoveNPCs>();
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMovedX = transform.position.x - previousPosition.x;
        //Debug.Log(distanceMovedX);
        float distanceMovedY = transform.position.y - previousPosition.y;
        
        moveSpeedX = distanceMovedX / Time.fixedDeltaTime;
        moveSpeedX /= mover.moveSpeed;
        moveSpeedY = distanceMovedY / Time.fixedDeltaTime;
        moveSpeedY /= mover.moveSpeed;
        
        if (moveSpeedX != 0 || moveSpeedY != 0)
        {
            animator.SetFloat("X", moveSpeedX);
            animator.SetFloat("Y", moveSpeedY);
            //Debug.Log(moveSpeedX);
            //Debug.Log(moveSpeedY);
            ActiveLayer("Walk");
        }
        else
        {
            
            ActiveLayer("Idle");
        }
        previousPosition = transform.position;
    }
    public void ActiveLayer(string LayerName)
    {
        for(int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(LayerName), 1);
    }
}
