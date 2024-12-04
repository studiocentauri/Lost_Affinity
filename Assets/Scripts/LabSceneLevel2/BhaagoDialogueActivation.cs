using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BhaagoDialogueActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    public TextMeshProUGUI dialogueText;
    [SerializeField]
    public string[] dialogue;
    [SerializeField]
    public float wordSpeed;
    [SerializeField]
    private bool playerClose;

    private GameObject player;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if (dialogueText.text == dialogue[index])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextLine();
            }
        }

    }

    public void zeroText()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        index = 0;

        dialoguePanel.SetActive(false);
    }
    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
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
            playerClose = true;
            player = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = false;
            zeroText();
        }
    }
}
