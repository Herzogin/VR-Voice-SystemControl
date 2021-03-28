using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{    
    public void TurnGreen()
    {
        Debug.Log("inside TurnGreen");
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void TurnBlue()
    {
        Debug.Log("inside TurnBlue");
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void TurnRed()
    {
        Debug.Log("inside TurnRed");
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void TurnYellow()
    {
        Debug.Log("inside TurnYellow");
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
