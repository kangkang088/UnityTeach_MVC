using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMain : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            MainPanel.ShowMe();
        }
        else if(Input.GetKeyDown(KeyCode.N)) {
            MainPanel.HideMe();
        }

    }
}
