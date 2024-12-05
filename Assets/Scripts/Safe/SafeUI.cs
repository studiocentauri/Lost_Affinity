using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using my one and only retarded brain cell, how many do you have?

/*
    This script is to be put on the safe UI canvas
*/
public class SafeUI : MonoBehaviour
{
    private int combinationLength;
    public TextMeshProUGUI promptText; //to display the prompt
    public TextMeshProUGUI displayText; //to display the input passcode
    private string passcode; //actual passcode
    private string inputPasscode; //input passcode
    private Color32 hintColor;

    GameObject SafeManager;

    void Start(){
        displayText.text = "Enter Passcode";
        inputPasscode = "";
        hintColor = new Color32(0xD7, 0xD7, 0xD7, 0xFF);
        SafeManager = FindObjectOfType<SafeManager>().gameObject;
        passcode = SafeManager.GetComponent<SafeManager>().passcode;
        combinationLength = SafeManager.GetComponent<SafeManager>().combinationLength;
        //Debug.Log(passcode);
        GiveHint(); //Hint dede lawde ko
    }
    public void TakeInput(int digit){
        inputPasscode+=digit.ToString();
        updateDisplay();
    }
    public void Delete(){
        inputPasscode=inputPasscode.Substring(0,inputPasscode.Length-1);
        updateDisplay();
    }

    public void CheckPasscode(){
        if(inputPasscode==passcode){
            promptText.text = "Safe Unlocked!";
            promptText.gameObject.SetActive(true);
            gameObject.SetActive(false);


            //do something to unlock the safe and other shit

            Destroy(SafeManager);
            Debug.Log("Safe Unlocked");
        }
        else{
            inputPasscode = "";
        }
        updateDisplay();
    }

    void updateDisplay(){
        if(inputPasscode.Length>combinationLength)
            inputPasscode=inputPasscode.Substring(0,combinationLength);
        if(inputPasscode=="")
            displayText.text = "Wrong Passcode!";
        else
            displayText.text = inputPasscode.ToString();
    }

    void GiveHint(){
        foreach(char ch in passcode){
            Button button = GameObject.Find("Button_"+ch).GetComponent<Button>(); // get the button
            ColorBlock colors = button.colors;
            colors.normalColor = hintColor; //
            button.colors = colors;
        }
            /*ColorBlock colors = button.colors;
            colors.normalColor = normal;
            colors.highlightedColor = highlighted;
            colors.pressedColor = pressed;
            button.colors = colors;
            */
    }
}
