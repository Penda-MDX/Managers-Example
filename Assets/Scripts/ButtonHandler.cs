using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text buttonText;
    public Button buttonObj;
    public int buttonNumber;    

    public string numberText;
    public int symbolNumber;
    public string symbolText;

    public Color otherColor;
    public Color startColor;

    private ButtonManger bman;

    void Start()
    {
        bman = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<ButtonManger>();
        bman.RegisterButton(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
