using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateHndler : MonoBehaviour
{
    public TMP_Text text;
    public int gatePlusOrMinus;
    public Spawn GameHndler;
    public bool multiplierGate;
    public bool dividerGate;
    public int gateMultiplier;
    public int gateDivider;

    private void Awake()
    {
        if (multiplierGate == false && dividerGate == false)
        {
            if (gatePlusOrMinus > 0)
            {
                text.text = "+" + gatePlusOrMinus;
            }
            if (gatePlusOrMinus < 0)
            {
                text.text = gatePlusOrMinus.ToString();
            }
        }
        if (multiplierGate == true)
        {
            text.text = "X" + gateMultiplier;
        }
        if (dividerGate == true)
        {
            text.text = "/" + gateDivider;
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (multiplierGate == false && dividerGate == false)
            {
                if (gatePlusOrMinus > 0)
                {
                    Debug.Log("kapiya girdi");
                    GameHndler.SetPositiveDifference(gatePlusOrMinus);
                }
                if (gatePlusOrMinus < 0)
                {
                    int temp = gatePlusOrMinus * -1;
                    GameHndler.SetNegativeDifference(temp);
                }
            }
            else if (multiplierGate == true)
            {
                int currentCount = GameHndler.GetCount() + 1;
                int temp = currentCount * gateMultiplier;
                GameHndler.SetPositiveDifference(temp - currentCount);
            }
            else if (dividerGate == true)
            {
                int currentCount = GameHndler.GetCount() + 1;
                int temp = currentCount / gateDivider;
                GameHndler.SetNegativeDifference(currentCount - temp);
            }
        }
        

    }

}
