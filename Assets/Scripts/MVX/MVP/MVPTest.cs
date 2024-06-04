using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVPTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            MainPresenter.ShowMe();
        }
        else if(Input.GetKeyDown(KeyCode.N)) {
            MainPresenter.HideMe();
        }
    }
}
