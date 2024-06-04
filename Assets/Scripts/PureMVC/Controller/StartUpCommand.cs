using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpCommand : SimpleCommand {
    //1.继承PureMVC中的Command相关脚本
    //2.重写执行函数
    public override void Execute(INotification notification) {
        base.Execute(notification);
        //当命令被执行时，就会调用该方法
        //注册数据
        if(!Facade.HasProxy(PlayerProxy.NAME))
            Facade.RegisterProxy(new PlayerProxy());
    }
}
