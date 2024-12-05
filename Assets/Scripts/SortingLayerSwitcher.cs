using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    //switch player's sprite renderer order in layer from 2 to 5 on crossing the box collider from one value to other and vice versa
    SpriteRenderer spriteRenderer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer = other.GetComponent<SpriteRenderer>();
            if(spriteRenderer.sortingOrder==2)
                spriteRenderer.sortingOrder = 5;
            else
                spriteRenderer.sortingOrder = 2;
        if (other.transform.childCount > 0)
        {
            SpriteRenderer childSpriteRenderer = other.transform.GetChild(0).GetComponent<SpriteRenderer>();
            if (childSpriteRenderer != null)
            {
                childSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder;
            }
        }
        }
    }
}
