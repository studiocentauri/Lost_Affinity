using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BhaagoDialogueActivation : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> NPCs;
    
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    public TextMeshProUGUI dialogueText;
    [SerializeField]
    public string[] dialogue;
    [SerializeField]
    public float wordSpeed;
    /*[SerializeField]
    private bool playerClose;*/

    public GameObject player;
    private int index;

    private bool escaped = false;
    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startDialogues()
    {
        if (!escaped)
        {
            
            if (dialoguePanel.activeInHierarchy)
            {
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                StartCoroutine(CheckInputs());
            }
        }
        
    }
    public void zeroText()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        index = 0;

        if(dialoguePanel != null) dialoguePanel.SetActive(false);
    }
    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
            StartCoroutine(CheckInputs());
        }
        else
        {
            zeroText();
            foreach(GameObject g in NPCs)
            {
                AutoMoveNPCs x = g.GetComponent<AutoMoveNPCs>();
                x.dialogueCompleted = true;
            }
            escaped = true;
        }
    }
    IEnumerator CheckInputs()
    {
        while (true)
        {
            if (dialogueText.text == dialogue[index])
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    NextLine();
                }
            }
            yield return null;
        }
    }
    IEnumerator Typing()
    {
        //istyping = true;
        int i = index;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            if (i != index)
            {
                break;
            }
        }
        //istyping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerClose = true;
            startDialogues();
            player = collision.gameObject;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            Animator _animator = player.GetComponentInChildren<Animator>();
            _animator.SetBool("isMoving", false);
            PlayerAnimation playerAnimation = player.GetComponentInChildren<PlayerAnimation>();
            playerAnimation.enabled = false;
            playermovement _playermovement = player.GetComponent<playermovement>();
            topDownJump _topDownJump = player.GetComponent<topDownJump>();
            _playermovement.enabled = false;
            _topDownJump.enabled = false;
            

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerClose = false;
            zeroText();
        }
    }
}
