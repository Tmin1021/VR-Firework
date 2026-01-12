using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class TouchpadInput : MonoBehaviour
{
    [SerializeField] TMP_Text displayText;
    [SerializeField] string correctCode = "1234"; // test only
    [SerializeField] string offCode = "0000"; // test only
    private string inputString = "";
    private SpawnFirework[] spawnFireworks;
    private float messageTime = 0f;
    private bool launched = false;
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
        if(messageTime > 0f && Time.time >= messageTime)
        {
            RefreshInput();
            messageTime = 0f;
        }
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
        // launched = false;
    }

    public void DeleteDigit()
    {
        if (string.IsNullOrEmpty(inputString)) return;
        inputString = inputString.Remove(inputString.Length - 1); 
        displayText.text = inputString;
    }


    public void Enter()
    {
        if(inputString == correctCode)
        {
            // displayText.text = "Correct Pwd";
            // messageTime = Time.time + 1f;
            if(launched == false)
            {
                foreach(var launcher in spawnFireworks)
                {
                    launcher.SetLaunch(true);
                }
                RefreshInput();
                launched = true;
            }

            return;
        }
        else if(inputString == offCode)
        {
            if(launched == true)
            {    
                foreach(var launcher in spawnFireworks)
                {
                    launcher.SetLaunch(false);
                }
                RefreshInput();
                launched = false;
            }
            return;
        }

        displayText.text = "Wrong pwd";
        messageTime = Time.time + 1f;
        return;

    }
}
