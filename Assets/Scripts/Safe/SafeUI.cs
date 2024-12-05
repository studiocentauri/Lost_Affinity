using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SafeUI : MonoBehaviour
{
    private int combinationLength;
    public TextMeshProUGUI promptText; //to display the prompt
    public TextMeshProUGUI displayText; //to display the input passcode
    private string passcode; //actual passcode
    private string inputPasscode; //input passcode
    public Sprite[] fingerprintSprites; // Array of sprites to use as hints

    GameObject SafeManager;

    void Start(){
        displayText.text = "Enter Passcode";
        inputPasscode = "";
        SafeManager = FindObjectOfType<SafeManager>().gameObject;
        passcode = SafeManager.GetComponent<SafeManager>().passcode;
        combinationLength = SafeManager.GetComponent<SafeManager>().combinationLength;
        GiveHint(); // Provide hint
    }

    public void TakeInput(int digit){
        inputPasscode += digit.ToString();
        updateDisplay();
    }

    public void Delete(){
        inputPasscode = inputPasscode.Substring(0, inputPasscode.Length - 1);
        updateDisplay();
    }

    public void CheckPasscode(){
        if(inputPasscode == passcode){
            promptText.text = "Safe Unlocked!";
            promptText.gameObject.SetActive(true);
            gameObject.SetActive(false);

            // Do something to unlock the safe

            Destroy(SafeManager);
            Debug.Log("Safe Unlocked");
        }
        else{
            inputPasscode = "";
        }
        updateDisplay();
    }

    void updateDisplay(){
        if(inputPasscode.Length > combinationLength)
            inputPasscode = inputPasscode.Substring(0, combinationLength);
        if(inputPasscode == "")
            displayText.text = "Wrong Passcode!";
        else
            displayText.text = inputPasscode.ToString();
    }

    void GiveHint(){
        foreach(char ch in passcode){
            Button button = GameObject.Find("Button_" + ch).GetComponent<Button>(); // Get the button
            int index = (int)char.GetNumericValue(ch); // Convert character to integer index
            if(index >= 0 && index < fingerprintSprites.Length){
                button.GetComponent<Image>().sprite = fingerprintSprites[index]; // Set the button's image
            }
        }
    }
}