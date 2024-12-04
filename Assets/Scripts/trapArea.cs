using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trapArea : MonoBehaviour
{
    public GameObject drowningPanel;

    void Start()
    {
        drowningPanel.SetActive(false);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!other.gameObject.GetComponent<playermovement>().isAttachedToPlatform && !other.gameObject.GetComponent<topDownJump>().isJumping)
            {
                drowningPanel.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Debug.Log("Drowned");
            }
        }
    }
}
