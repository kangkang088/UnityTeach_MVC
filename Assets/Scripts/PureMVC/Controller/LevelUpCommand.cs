using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpCommand : SimpleCommand
{
    public override void Execute(INotification notification) {
        base.Execute(notification);
        //得到数据代理 调用升级 通知完成升级 更新数据
        PlayerProxy proxy = Facade.RetrieveProxy(PlayerProxy.NAME) as PlayerProxy;
        if(proxy != null) {
            proxy.LevelUp();
            proxy.SaveData();
            SendNotification(PureNotification.UPDATE_PLAYER_INFO,proxy.Data);
        }
    }
}
