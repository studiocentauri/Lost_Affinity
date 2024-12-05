using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Glitch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playermovement>().enabled = false;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponentInChildren<PlayerAnimation>().enabled = false;
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool("Glitch", true);
            Invoke("Level2", 2f);
        }
    }

    void Level2()
    {
        // Load level 2
        SceneManager.LoadScene("Level-2");
    }
}
