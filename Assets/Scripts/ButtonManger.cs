using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManger : MonoBehaviour
{
    public List<ButtonHandler> buttonsList;
    //public List<int[]> modeList;
    public int[,] modeList = { { 0, 2 }, { 1, 3 }, { 0, 3 }, { 2, 3 } };
    private int[] activeButtonList = {0,2};
    private int currentNumber;
    private bool isNumeric;
    private bool setNumeric = true;
    private bool setSymbol = false;


    public GameObject statusObject; 
    public Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        currentNumber = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        // testing features 
        // key press for changing between modes using . and ,
        // key press B to enact mode change de/activate buttons
        // key press F to change between display numbers and letters

        if (Input.GetKeyDown(KeyCode.Period))
        {
            Debug.Log("Plus");
            currentNumber++;
            if (currentNumber >= modeList.GetLength(0))
            {
                currentNumber = modeList.GetLength(0) - 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            Debug.Log("Minus");
            currentNumber--;
            if (currentNumber < 0)
            {
                currentNumber = 0;
            }

        }

        statusText.text = "Use period (.) and comma (,) keys to change the button mode. Press B to change. Press F to change text. Current mode is " + currentNumber.ToString();

        if (Input.GetKeyDown(KeyCode.B))
        {
            for (int x = 0; x < modeList.GetLength(1); x++)
            {
                activeButtonList[x] = modeList[currentNumber,x];

            }
            ActivateButtons(currentNumber);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            if (isNumeric)
            {
                isNumeric = false;
                setSymbol = true;
            }
            else
            {
                isNumeric = true;
                setNumeric = true;
            }

        }

        if (setSymbol)
        {
            setSymbol = false;
            SymbolButtons();
        }
        if (setNumeric)
        {
            setNumeric = false;
            NumericButtons();
        }
    }

    //register and deregister buttons on list
    public void RegisterButton(ButtonHandler newButton)
    {
        buttonsList.Add(newButton);
    }

    public void UnregisterButton(ButtonHandler deleteButton)
    {
        buttonsList.Remove(deleteButton);
    }

    //function to loop through the buttons list and deactivate and activate buttons based on the current mode list
    // could be cleaner using a list of objects for the modes (scriptable objects?)
    public void ActivateButtons(int mode)
    {

        //activeButtonList = modeList[mode];

        foreach(ButtonHandler button in buttonsList)
        {
            //button.buttonObj.enabled = false;
            button.buttonObj.gameObject.SetActive(false);
            foreach (int numberButton in activeButtonList)
            {
                if(button.buttonNumber == numberButton)
                {
                    button.buttonObj.gameObject.SetActive(true);
                }
            }
        }
    }

    //functions to loop through the buttons registered and change them to use the number or symbol they hold for themselves
    public void NumericButtons()
    {
        Debug.Log("Numeric");
        foreach (ButtonHandler button in buttonsList)
        {
            button.buttonText.text = button.numberText;
        }
    }

    public void SymbolButtons()
    {
        Debug.Log("Symbol");
        foreach (ButtonHandler button in buttonsList)
        {
            button.buttonText.text = button.symbolText;
        }
    }
}
