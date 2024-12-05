using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Glitch : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level-2")
        {
            Player.GetComponent<playermovement>().enabled = false;
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.GetComponentInChildren<PlayerAnimation>().enabled = false;
            Animator anim = Player.GetComponentInChildren<Animator>();
            anim.SetBool("Glitch", true);
            Invoke("GlitchOff", 1.25f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playermovement>().enabled = false;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponentInChildren<PlayerAnimation>().enabled = false;
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool("Glitch", true);
            Invoke("Level2", 1.25f);
        }
    }

    void GlitchOff()
    {
        Player.GetComponent<playermovement>().enabled = true;
        Player.GetComponentInChildren<PlayerAnimation>().enabled = true;
        Animator anim = Player.GetComponentInChildren<Animator>();
        anim.SetBool("Glitch", false);
        Destroy(gameObject);
    }

    void Level2()
    {
        // Load level 2
        SceneManager.LoadScene("Level-2");
    }
}
