using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] State kritik;
    [SerializeField] State kritikTr;
    [SerializeField] State escapeCross;
    [SerializeField] State escapeCrossTr;

    State currentState;
    void Start()
    {
        currentState = startingState;
        textComponent.text = currentState.getStateText();
        kritikTr.ayrim = true;
        kritik.ayrim = true;
        escapeCross.ayrim = false;
        escapeCrossTr.ayrim = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageStates();
    }

    private void ManageStates()
    {
        var nextStates = currentState.getNextStates();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentState.nextStates.Length > 0)
            {
                if (currentState.name.Equals("Escape"))
                {
                    if (currentState.ayrim == true)
                    {
                        currentState = nextStates[1];
                        return;
                    }
                    else
                    {
                        currentState = nextStates[0];
                    }
                }
                else
                {
                    currentState = nextStates[0];
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentState.nextStates.Length > 1)
            {
                if (currentState.ayrim == true)
                {
                    escapeCross.ayrim = true;
                    escapeCrossTr.ayrim = true;
                }
                currentState = nextStates[1];
            }
        }

        else if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();

        textComponent.text = currentState.getStateText();
    }
}
