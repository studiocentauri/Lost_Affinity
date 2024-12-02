using UnityEngine;
using TMPro;
//using my one and only retarded brain cell, how many do you have?
public class SafeUI : MonoBehaviour
{
    private int combinationLength;
    public TextMeshProUGUI promptText; //to display the prompt
    public TextMeshProUGUI displayText; //to display the input passcode
    private int passcode; //actual passcode
    private int inputPasscode; //input passcode

    void Start(){
        displayText.text = "Enter Passcode";
        inputPasscode = 0;
        GameObject SafeManager = FindObjectOfType<SafeManager>().gameObject;
        passcode = SafeManager.GetComponent<SafeManager>().passcode;
        combinationLength = SafeManager.GetComponent<SafeManager>().combinationLength;
        Debug.Log("Hi: " + passcode);
    }
    public void TakeInput(int digit){
        inputPasscode = inputPasscode*10+digit;
        updateDisplay();
    }
    public void Delete(){
        inputPasscode/=10;
        updateDisplay();
    }

    public void CheckPasscode(){
        if(inputPasscode==passcode){
            promptText.text = "Safe Unlocked!";
            promptText.gameObject.SetActive(true);
            gameObject.SetActive(false);


            //do something to unlock the safe and other shit
        }
        else{
            inputPasscode = 0;
        }
        updateDisplay();
    }

    void updateDisplay(){
        if(inputPasscode>9999)
            inputPasscode/=10;
        if(inputPasscode==0)
            displayText.text = "Wrong Passcode!";
        else
            displayText.text = inputPasscode.ToString();
    }
}
