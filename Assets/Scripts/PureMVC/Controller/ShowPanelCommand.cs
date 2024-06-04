using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelCommand : SimpleCommand {
    public override void Execute(INotification notification) {
        base.Execute(notification);
        string panelName = notification.Body.ToString();

        switch(panelName) {
            case "MainPanel":
                //要使用mediator，一定也要在facade中注册，command和proxy都一样，用，就要注册
                if(!Facade.HasMediator(NewMainViewMediator.NAME))
                    Facade.RegisterMediator(new NewMainViewMediator());
                NewMainViewMediator mm = Facade.RetrieveMediator(NewMainViewMediator.NAME) as NewMainViewMediator;
                //有了mediator，创建界面
                if(mm.ViewComponent == null) {
                    GameObject res = Resources.Load<GameObject>("UI/MainPanel");
                    GameObject obj = GameObject.Instantiate(res);
                    obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
                    mm.SetView(obj.GetComponent<NewMainView>());
                }
                SendNotification(PureNotification.UPDATE_PLAYER_INFO,Facade.RetrieveProxy(PlayerProxy.NAME).Data);
                break;
            case "RolePanel":
                //要使用mediator，一定也要在facade中注册，command和proxy都一样，用，就要注册
                if(!Facade.HasMediator(NewRoleViewMediator.NAME))
                    Facade.RegisterMediator(new NewRoleViewMediator());
                NewRoleViewMediator rm = Facade.RetrieveMediator(NewRoleViewMediator.NAME) as NewRoleViewMediator;
                //有了mediator，创建界面
                if(rm.ViewComponent == null) {
                    GameObject res = Resources.Load<GameObject>("UI/RolePanel");
                    GameObject obj = GameObject.Instantiate(res);
                    obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
                    rm.SetView(obj.GetComponent<NewRoleView>());
                }
                SendNotification(PureNotification.UPDATE_PLAYER_INFO,Facade.RetrieveProxy(PlayerProxy.NAME).Data);
                break;
        }
    }
}
