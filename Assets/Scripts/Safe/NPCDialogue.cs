using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private SafeManager safeManager;

    void Start()
    {
        dialogueText.gameObject.SetActive(false);
        safeManager = FindObjectOfType<SafeManager>();
        if (safeManager != null){
            int combination = safeManager.passcode;
            string text = $"The code to the safe is: {combination}";
            dialogueText.text = text;
            Debug.Log(text);
        }
        else{
            dialogueText.text = "Sorry, I can't seem to remember the code!";
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            dialogueText.gameObject.SetActive(true);
            //Debug.Log(dialogueText.text);
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            dialogueText.gameObject.SetActive(false);
        }
    }
}
