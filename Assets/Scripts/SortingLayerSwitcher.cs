using UnityEngine;

public class SortingLayerSwitcher : MonoBehaviour
{
    //Switch player's sprite renderer order in layer from 2 to 5 on crossing the box collider from one value to other and vice versa
    public int sortingOrder1;
    public int sortingOrder2;
    SpriteRenderer spriteRenderer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer = other.GetComponent<SpriteRenderer>();
            if(spriteRenderer.sortingOrder==sortingOrder1)
                spriteRenderer.sortingOrder = sortingOrder2;
            else
                spriteRenderer.sortingOrder = sortingOrder1;
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
