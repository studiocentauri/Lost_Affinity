using UnityEngine;
using TMPro;
using System.Linq;
//using my brain in this goddamn PS, cuz I have no life to live

/*
    This script is to be put on the safe or the thing which requires the code.
    The trigger volume needs to be adjusted accordingly
*/
public class SafeManager : MonoBehaviour
{
    public int combinationLength = 4;
    public string passcode; //actual passcode
    public TextMeshProUGUI promptText; //set the prompt text
    public GameObject safeCanvas; //to enable or disable the safeInput canvas
    private bool playerInContact;
    public GameObject panel1;
    
    void Awake()
    {
        // Generate a random string of length 4 with distinct digits
        passcode = "";
        var random = new System.Random();
        passcode = string.Concat(Enumerable.Range(0, 10).OrderBy(_ => random.Next()).Take(4));
        /*List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int i = 0; i < combinationLength; i++)
        {
            int index = Random.Range(0, digits.Count);
            passcode += digits[index].ToString();
            digits.RemoveAt(index);
        }*/
        Debug.Log("The safe passcode is: "+passcode);
    }
    void Start()
    {
        safeCanvas.SetActive(false);
        playerInContact = false;
        panel1.SetActive(false);
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            promptText.text = "You found the lab \nPress E to enter the passcode to unlock it.";
            promptText.gameObject.SetActive(true);
            panel1.SetActive(true);
            playerInContact = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            promptText.gameObject.SetActive(false);
            panel1.SetActive(false);
            safeCanvas.SetActive(false);
            playerInContact = false;
        }
    }

    void Update(){
        //put other update shit here, cuz safeUI has a return statement



        if(Input.GetKeyDown(KeyCode.E) && playerInContact && !safeCanvas.activeSelf){
            safeCanvas.SetActive(true);
            panel1.SetActive(false);
            
            promptText.gameObject.SetActive(false);
            return;
        }
        if(Input.GetKeyDown(KeyCode.E) && playerInContact && safeCanvas.activeSelf){
            safeCanvas.SetActive(false);
            panel1.SetActive(true);
            
            promptText.gameObject.SetActive(true);
        }

    }
}