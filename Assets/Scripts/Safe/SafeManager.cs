//using System;
using UnityEngine;

public class SafeManager : MonoBehaviour
{
    public int combinationLength = 4;
    public int passcode;

    public int inputPasscode;

    void Awake()
    {
        passcode = 0;
        inputPasscode = 0;
        for (int i = 1; i<=combinationLength; i++){
            passcode = passcode*10 + Random.Range(0, 10); // Generates a digit between 0 and 9
        }
    }
}
