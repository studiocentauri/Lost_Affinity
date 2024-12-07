using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trapArea : MonoBehaviour
{
    public GameObject drowningPanel,hintpanel;
    public bool hint=false;
    int count=0;
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
                other.gameObject.SetActive(false);
                drowningPanel.SetActive(true);
                count++;
                if(hintpanel!=null && count>=2)hintpanel.SetActive(true);
                // other.GetComponent<playermovement>().enabled =false;
                
                Time.timeScale = 0f;
                Invoke("ChangeScene", 4f);
                Time.timeScale = 1f;
//                Debug.Log("Drowned");
            }
        }
    }

    void ChangeScene()
    {
        //Time.timeScale = 1f;
        // player.GetComponent<playermovement>().enabled =true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
