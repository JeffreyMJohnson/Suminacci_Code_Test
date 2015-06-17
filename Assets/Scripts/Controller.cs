using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Controller : MonoBehaviour
{

    public InputField testValue;
    public Text resultTxt;
    public Button resultBtn;

    // Use this for initialization
    void Start()
    {
        //setfocus to input
        testValue.Select();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            resultBtn.Select();
        }
    }

    public void HandleButton(string value)
    {
        testValue.text = value;
    }

    public void GetResult()
    {
        uint value = 0;
        try
        {
            value = uint.Parse(testValue.text);
        }
        catch(OverflowException e)
        {
            resultTxt.text = "Must be positive.";
                testValue.text = "";
                testValue.Select();
                return;
        }
        catch(FormatException e)
        {
            testValue.text = "Enter a number!";
            testValue.text = "";
            testValue.Select();
        }

        List<uint> fibSeq = GetFibSeq(value);
        uint sum = GetFibSum(fibSeq);


        //have sum
        resultTxt.text = sum.ToString();

    }

    private List<uint> GetFibSeq(uint value)
    {
        List<uint> result = new List<uint>();

        //prevMinusOne + prev = next ... 
        uint prevMinusOne = 0;
        uint prev = 1;
        uint next = 0;
        result.Add(prevMinusOne);

        //0 edge case
        if(value == 0)
        {
            return result;
        }
        result.Add(prev);

        //1 edge case
        if(value == 1)
        {
            return result;
        }

        //value > 1 so calculate
        while (next < value)
        {
            //get next in seq
            next = prevMinusOne + prev;
            //move up the line
            prevMinusOne = prev;
            prev = next;

            //check if this too large to add to result
            if (next <= value)
            {
                result.Add(next);
            }

        }
        return result;
    }


    private uint GetFibSum(List<uint> fibSeq)
    {
        uint result = 0;
        foreach (uint i in fibSeq)
        {
            result += i;
        }
        return result;
    }

}
