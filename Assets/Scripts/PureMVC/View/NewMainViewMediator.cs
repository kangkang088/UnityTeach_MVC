using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMainViewMediator : Mediator {
    public new static string NAME = "NewMainViewMediator";
    //1.继承PureMVC中的Mediator脚本
    //2.写构造函数
    public NewMainViewMediator() : base(NAME) {
        //这里可以写创建界面等逻辑
        //但是界面的显示应该是由用户触发控制的
        //而且界面往往不止一个，通过构造函数创建界面会写很多重复代码
    }
    //3.重写监听通知的方法
    public override string[] ListNotificationInterests() {
        //PureMVC规则
        //你需要监听哪些通知，就通过字符串数组的方式返回出去，PureMVC就会监听这些通知
        //类似 通过事件名 注册事件监听        
        return new string[] { PureNotification.UPDATE_PLAYER_INFO,PureNotification.SHOW_PANEL };
    }
    public void SetView(NewMainView view) {
        ViewComponent = view;
        view.btnRole.onClick.AddListener(() => { SendNotification(PureNotification.SHOW_PANEL,"RolePanel"); });
    }
    //4.重写处理通知的方法
    public override void HandleNotification(INotification notification) {
        //INotification
        //1.包含通知名 我们根据这个名字 做对应的处理
        //2.包含 这个通知带来的信息
        switch(notification.Name) {
            case PureNotification.UPDATE_PLAYER_INFO:
                //收到玩家数据更新通知，对View处理
                if(ViewComponent != null)
                    (ViewComponent as NewMainView).UpdateInfo(notification.Body as PlayerDataObj);
                break;
        }
    }
    //5.可选：重写注册时的方法
    public override void OnRegister() {
        base.OnRegister();
        //注册时初始化一些内容
    }
}
