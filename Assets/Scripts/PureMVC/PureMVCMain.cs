using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureMVCMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameFacade.Instance.StartUp();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) {
            GameFacade.Instance.SendNotification(PureNotification.SHOW_PANEL,"MainPanel");
        }
        else if(Input.GetKeyDown(KeyCode.N)) {
            GameFacade.Instance.SendNotification(PureNotification.HIDE_PANEL,GameFacade.Instance.RetrieveMediator(NewMainViewMediator.NAME));
        }
    }
}
