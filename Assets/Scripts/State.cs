using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string storyText;
    public State[] nextStates;
    public bool ayrim = false;
    public string getStateText()
    {
        return storyText;
    }

    public State[] getNextStates()
    {
        return nextStates;
    }
}
