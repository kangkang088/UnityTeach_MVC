﻿using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoleViewMediator : Mediator {
    public new static string NAME = "NewRoleViewMediator";
    public NewRoleViewMediator() : base(NAME) {
    }

    public override string[] ListNotificationInterests() {
        return new string[] { PureNotification.UPDATE_PLAYER_INFO };
    }
    public void SetView(NewRoleView view) {
        ViewComponent = view;
        view.btnClose.onClick.AddListener(() => { SendNotification(PureNotification.HIDE_PANEL,this); });
        view.btnUp.onClick.AddListener(() => { SendNotification(PureNotification.LEVEL_UP,this); });
    }
    public override void HandleNotification(INotification notification) {
        switch(notification.Name) {
            case PureNotification.UPDATE_PLAYER_INFO:
                if(ViewComponent != null)
                    (ViewComponent as NewRoleView).UpdateInfo(notification.Body as PlayerDataObj);
                break;
        }
    }
    public override void OnRegister() {
        base.OnRegister();
    }
}
