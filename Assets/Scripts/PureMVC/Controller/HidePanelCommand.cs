using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelCommand : SimpleCommand {
    public override void Execute(INotification notification) {
        base.Execute(notification);
        //得到mediator，得到mediator中的view，控制显隐
        //规则：通知体是mediator
        Mediator m = notification.Body as Mediator;
        if(m != null && m.ViewComponent != null) {
            GameObject.Destroy((m.ViewComponent as MonoBehaviour).gameObject);
            m.ViewComponent = null;
        }
    }
}
