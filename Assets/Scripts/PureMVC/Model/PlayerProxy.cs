using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家数据代理对象
/// 主要处理玩家数据更新相关的逻辑
/// </summary>
public class PlayerProxy : Proxy {
    public new const string NAME = "PlayerProxy";
    //1.继承Proxy父类
    //2.写构造函数
    public PlayerProxy() : base(PlayerProxy.NAME) {
        PlayerDataObj data = new PlayerDataObj();
        data.playerName = PlayerPrefs.GetString("PlayerName","kangkang");
        data.lev = PlayerPrefs.GetInt("PlayerLevel",15);
        data.money = PlayerPrefs.GetFloat("PlayerMoney",9999);
        data.gem = PlayerPrefs.GetFloat("PlayerGem",888);
        data.power = PlayerPrefs.GetFloat("PlayerPower",100);
        data.hp = PlayerPrefs.GetInt("PlayerHP");
        data.atk = PlayerPrefs.GetInt("PlayerAtk");
        data.def = PlayerPrefs.GetInt("PlayerDef");
        data.crit = PlayerPrefs.GetInt("PlayerCrit");
        data.miss = PlayerPrefs.GetInt("PlayerMiss");
        data.lucky = PlayerPrefs.GetInt("PlayerLucky");
        Data = data;
    }
    public void LevelUp() {
        PlayerDataObj data = Data as PlayerDataObj;
        data.lev += 1;
        data.hp += data.lev;
        data.atk += data.lev;
        data.def += data.lev;
        data.crit += data.lev;
        data.miss += data.lev;
        data.lucky += data.lev;
    }
    public void SaveData() {
        PlayerDataObj data = Data as PlayerDataObj;
        PlayerPrefs.SetString("PlayerName",data.playerName);
        PlayerPrefs.SetInt("PlayerLevel",data.lev);
        PlayerPrefs.SetFloat("PlayerMoney",data.money);
        PlayerPrefs.SetFloat("PlayerGem",data.gem);
        PlayerPrefs.SetFloat("PlayerPower",data.power);
        PlayerPrefs.SetInt("PlayerHP",data.hp);
        PlayerPrefs.SetInt("PlayerAtk",data.atk);
        PlayerPrefs.SetInt("PlayerDef",data.def);
        PlayerPrefs.SetInt("PlayerCrit",data.crit);
        PlayerPrefs.SetInt("PlayerMiss",data.miss);
        PlayerPrefs.SetInt("PlayerLucky",data.lucky);

    }
}
