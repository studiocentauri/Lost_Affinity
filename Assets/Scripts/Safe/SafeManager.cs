using UnityEngine;
using TMPro;
public class SafeManager : MonoBehaviour
{
    public int combinationLength = 4;
    public int passcode; //actual passcode
    public TextMeshProUGUI promptText; //set the prompt text
    public GameObject safeCanvas; //to enable or disable the safeInput canvas
    private bool playerInContact; //to check if the player is in contact with the safe
    public int inputPasscode; //the player's input passcode

    void Awake()
    {
        passcode=0;
        inputPasscode=0;
        for(int i=1;i<=combinationLength;i++)
            passcode = passcode*10+Random.Range(0,10); //generate a random passcode
    }
    void Start()
    {
        safeCanvas.SetActive(false);
        playerInContact = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            promptText.text = "You have found a safe! Press P to enter the passcode to unlock it.";
            promptText.gameObject.SetActive(true);
            playerInContact = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            promptText.gameObject.SetActive(false);
            safeCanvas.SetActive(false);
            playerInContact = false;
        }
    }

    void Update(){
        //put other update shit here, cuz safeUI has a return statement



        if(Input.GetKeyDown(KeyCode.P) && playerInContact && !safeCanvas.activeSelf){
            safeCanvas.SetActive(true);
            promptText.gameObject.SetActive(false);
            return;
        }
        if(Input.GetKeyDown(KeyCode.P) && playerInContact && safeCanvas.activeSelf){
            safeCanvas.SetActive(false);
            promptText.gameObject.SetActive(true);
        }

    }
}