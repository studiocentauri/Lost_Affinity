using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayer : MonoBehaviour
{
    
    public GameObject player;
    public GameObject BhaagoCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            /*Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;*/
            PlayerAnimation playerAnimation = player.GetComponentInChildren<PlayerAnimation>();
            playerAnimation.enabled = true;
            playermovement _playermovement = player.GetComponent<playermovement>();
            topDownJump _topDownJump = player.GetComponent<topDownJump>();
            _playermovement.enabled = true;
            _topDownJump.enabled = true;
            BhaagoCollider.SetActive(false);
        }
    }
}
