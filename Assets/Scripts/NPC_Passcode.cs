using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Passcode : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    public TextMeshProUGUI dialogueText;
    [SerializeField]
    public string[] dialogue;
    public Texture[] speakerImage;
    public string[] speaker;
    [SerializeField]
    public float wordSpeed;
    [SerializeField]
    private bool playerClose;
    public int passcodeIndexInDialogue=2;
    public RawImage rawImage;
    public TMP_Text speakerName;

    private SafeManager safeManager;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);
        SetPasscodeDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerClose && Input.GetKeyDown(KeyCode.Return))
        {
            if(dialoguePanel.activeInHierarchy)
            {
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index])
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //NextLine();
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
        if(index < dialogue.Length - 1)
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
        rawImage.texture = speakerImage[index];
        speakerName.text = speaker[index];
        int i = index;
        foreach ( char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            if(i != index)
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
            promptText.text = "Press Enter to eavesdrop";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = false;
            promptText.text = "";
            zeroText();
        }
    }

    private void SetPasscodeDialogue()
    {
        safeManager = FindObjectOfType<SafeManager>(); //find the SafeManager in the scene
        if (safeManager != null){
            string combination = safeManager.passcode;
            combination = combination.Substring(0,combination.Length-2);
            string text = $"The code to the safe is: {combination}_ _"; //set the dialogue text
            Debug.Log(combination);
            dialogue[passcodeIndexInDialogue] = text;

        }
        else
            dialogueText.text = "Sorry, I can't seem to remember the code!";
    }
}
