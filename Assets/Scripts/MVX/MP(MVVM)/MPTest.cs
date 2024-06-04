using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            UIMgr.GetInstance().ShowPanel<MVE_MainPanel>("MainPanel");
        }
        else if(Input.GetKeyDown(KeyCode.N)) {
            UIMgr.GetInstance().HidePanel("MainPanel");
        }
    }
}
