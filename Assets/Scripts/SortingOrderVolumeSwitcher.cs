using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrderVolumeSwitcher : MonoBehaviour
{
    public int originalSortingOrder;
    public int insideSortingOrder;

    SpriteRenderer spriteRenderer;
void OnTriggerEnter2D(Collider2D other) //Changes order of the layers
{
    if (other.CompareTag("Player"))
    {
        spriteRenderer = other.GetComponent<SpriteRenderer>();
            originalSortingOrder = spriteRenderer.sortingOrder;
            spriteRenderer.sortingOrder = insideSortingOrder;

        if (other.transform.childCount > 0)
        {
            SpriteRenderer childSpriteRenderer = other.transform.GetChild(0).GetComponent<SpriteRenderer>();
            childSpriteRenderer.sortingOrder = insideSortingOrder;
        }
    }
}
void OnTriggerExit2D(Collider2D other) //Reverts order of the layers
{
    if (other.CompareTag("Player"))
    {
        spriteRenderer = other.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = originalSortingOrder;

        if (other.transform.childCount > 0)
        {
            SpriteRenderer childSpriteRenderer = other.transform.GetChild(0).GetComponent<SpriteRenderer>();
            childSpriteRenderer.sortingOrder = originalSortingOrder;
        }
    }
}
}
