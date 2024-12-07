using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public Animator animator;
    public activateAutoPlayerMove check;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && check.CanEnd)
        {
                animator.SetBool("GateOpen", true);
                Invoke("SceneChange", 3f);
                collision.GetComponent<playermovement>().enabled = false;
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.GetComponentInChildren<Animator>().enabled = false;
        }
    }

    void SceneChange()
    {
        //To add Ending Cutscene Scene
        SceneManager.LoadScene(0);
    }
}
