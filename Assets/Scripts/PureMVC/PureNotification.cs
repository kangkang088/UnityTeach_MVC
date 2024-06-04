using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// PureMVC中的 通知名类
/// 主要是用来声明各个通知的名字
/// 方便使用和管理
/// </summary>
public class PureNotification
{
    public const string START_UP = "StartUp";
    public const string SHOW_PANEL = "ShowPanel";
    public const string HIDE_PANEL = "HidePanel";
    public const string LEVEL_UP = "LevelUp";
    /// <summary>
    /// 玩家数据更新通知
    /// </summary>
    public const string UPDATE_PLAYER_INFO = "UpdatePlayerInfo";
}
