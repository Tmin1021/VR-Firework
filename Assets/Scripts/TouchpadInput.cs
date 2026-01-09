using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchpadInput : MonoBehaviour
{
    [SerializeField] TMP_Text displayText;
    [SerializeField] string correctCode = "1234"; // test only
    bool ifCorrect = false;
    private string inputString = "";
    private SpawnFirework[] spawnFireworks;
    void Awake()
    {
        spawnFireworks = FindObjectsByType<SpawnFirework>(FindObjectsSortMode.None);
    }

    void Start()
    {
        RefreshInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressDigit(int digit)
    {
        if(!displayText) return;
        inputString += digit.ToString();
        displayText.text = inputString;
    }

    public void RefreshInput()
    {
        displayText.text = "Password";
        inputString = "";
        ifCorrect = false;
    }

    public void DeleteDigit()
    {
        if (string.IsNullOrEmpty(inputString)) return;
        inputString = inputString.Remove(inputString.Length - 1); 
        displayText.text = inputString;
    }


    public void Enter()
    {
        float timer = 0f;
        timer += Time.deltaTime;
        if(inputString == correctCode && timer < 3f)
        {
            // displayText.text = "Correct Password";
            // ifCorrect = true;
            // return;

            foreach(var launcher in spawnFireworks)
            {
                launcher.ifLaunch = true;
                launcher.Launch();
            }

            return;
        }
        if(timer < 3f) displayText.text = "Wrong pwd";
        else
        {
            RefreshInput();
            timer = 0f;
        }
    }
}
