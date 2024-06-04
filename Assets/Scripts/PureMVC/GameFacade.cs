using PureMVC.Interfaces;
using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : Facade {
    //1.继承PureMVC中的Facade
    //2.为了方便使用,自己写一个单例模式的属性
    public static GameFacade Instance {
        get {
            if(instance == null) {
                instance = new GameFacade();
            }
            return instance as GameFacade;
        }
    }
    //3.初始化控制层相关内容
    protected override void InitializeController() {
        base.InitializeController();
        //写一些关于  命令（command）和通知 绑定的逻辑

        RegisterCommand(PureNotification.START_UP,() => {
            return new StartUpCommand();//excute函数执行
            });
        RegisterCommand(PureNotification.SHOW_PANEL,() => {
            return new ShowPanelCommand();
        });
        RegisterCommand(PureNotification.HIDE_PANEL,() => {
            return new HidePanelCommand();
        });
        RegisterCommand(PureNotification.LEVEL_UP,() => {
            return new LevelUpCommand();
        });
    }
    //4.启动函数
    public void StartUp() {
        SendNotification(PureNotification.START_UP);
        //SendNotification(PureNotification.SHOW_PANEL,"MainPanel");
    }
}
