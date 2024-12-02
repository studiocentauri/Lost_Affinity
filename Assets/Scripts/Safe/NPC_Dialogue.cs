using UnityEngine;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; //to set the NPC dialogue
    private SafeManager safeManager; //to get the passcode from SafeManager

    void Start()
    {
        dialogueText.gameObject.SetActive(false); 
        safeManager = FindObjectOfType<SafeManager>(); //find the SafeManager in the scene
        if (safeManager != null){
            int combination = safeManager.passcode;
            string text = $"The code to the safe is: {combination}"; //set the dialogue text
            dialogueText.text = text;
            //Debug.Log(text);
        }
        else
            dialogueText.text = "Sorry, I can't seem to remember the code!";
    }
    void OnTriggerEnter2D(Collider2D other) //when the player enters the NPC's trigger
    {
        if (other.CompareTag("Player")){
            dialogueText.gameObject.SetActive(true);
            //Debug.Log(dialogueText.text);
        }
    }
    
    void OnTriggerExit2D(Collider2D other) //when the player exits the NPC's trigger
    {
        if (other.CompareTag("Player")){
            dialogueText.gameObject.SetActive(false);
        }
    }
}
