using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    //Button handler is intended to hold data about the different button states of this button
    //and register the buttons with a manager that handles the global mode and what states each button should be in

    
    public Text buttonText;
    public Button buttonObj;
    //number the manager will look for to turn off and on buttons
    public int buttonNumber;    

    // number to appear as text on button
    public string numberText;
    //number for if you are using Unicode symbols in rich text/text mesh (not implemented)
    public int symbolNumber;
    // string for simple text on button 
    public string symbolText;

    //holds some colors for color changing (not implemented)
    public Color otherColor;
    public Color startColor;

    //reference to the manager
    private ButtonManger bman;

    // Start is called before the first frame update
    void Start()
    {
        //find the button manager in the scene and register with them to recieve further orders
        bman = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<ButtonManger>();
        bman.RegisterButton(this);
    }

}
