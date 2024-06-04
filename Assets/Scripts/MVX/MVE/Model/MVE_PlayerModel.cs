using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MVE_PlayerModel
{
    private string playerName;
    private int level;
    private float money;
    private float gem;
    private float power;
    private int hp;
    private int atk;
    private int def;
    private int crit;
    private int miss;
    private int lucky;
    private static MVE_PlayerModel data = null;
    public static MVE_PlayerModel Data {
        get {
            if(data == null) {
                data = new MVE_PlayerModel();
                data.Init();
            }
            return data;
        }
    }

    public string PlayerName {
        get => playerName;
    }
    public int Level {
        get => level;
    }
    public float Money {
        get => money;
    }
    public float Gem {
        get => gem;
    }
    public float Power {
        get => power;
    }
    public int Hp {
        get => hp;
    }
    public int Atk {
        get => atk;
    }
    public int Def {
        get => def;
    }
    public int Crit {
        get => crit;
    }
    public int Miss {
        get => miss;
    }
    public int Lucky {
        get => lucky;
    }

    //private event UnityAction<MVE_PlayerModel> updateEvent;

    public void Init() {
        playerName = PlayerPrefs.GetString("PlayerName","kangkang");
        level = PlayerPrefs.GetInt("PlayerLevel",15);
        money = PlayerPrefs.GetFloat("PlayerMoney",9999);
        gem = PlayerPrefs.GetFloat("PlayerGem",888);
        power = PlayerPrefs.GetFloat("PlayerPower",100);
        hp = PlayerPrefs.GetInt("PlayerHP");
        atk = PlayerPrefs.GetInt("PlayerAtk");
        def = PlayerPrefs.GetInt("PlayerDef");
        crit = PlayerPrefs.GetInt("PlayerCrit");
        miss = PlayerPrefs.GetInt("PlayerMiss");
        lucky = PlayerPrefs.GetInt("PlayerLucky");
    }
    public void LevelUp() {
        level += 1;
        hp += Level;
        atk += Level;
        def += Level;
        crit += Level;
        miss += Level;
        lucky += Level;
        SaveData();
    }
    public void SaveData() {
        PlayerPrefs.SetString("PlayerName",PlayerName);
        PlayerPrefs.SetInt("PlayerLevel",Level);
        PlayerPrefs.SetFloat("PlayerMoney",Money);
        PlayerPrefs.SetFloat("PlayerGem",Gem);
        PlayerPrefs.SetFloat("PlayerPower",Power);
        PlayerPrefs.SetInt("PlayerHP",Hp);
        PlayerPrefs.SetInt("PlayerAtk",Atk);
        PlayerPrefs.SetInt("PlayerDef",Def);
        PlayerPrefs.SetInt("PlayerCrit",Crit);
        PlayerPrefs.SetInt("PlayerMiss",Miss);
        PlayerPrefs.SetInt("PlayerLucky",Lucky);

        UpdateInfo();
    }
    //public void AddEventListener(UnityAction<MVE_PlayerModel> function) {
    //    //updateEvent += function;
    //}
    //public void RemoveEventListener(UnityAction<MVE_PlayerModel> function) {
    //    //updateEvent -= function;
    //}
    private void UpdateInfo() {
        //updateEvent?.Invoke(this);
        EventCenter.GetInstance().EventTrigger<MVE_PlayerModel>("PlayerData",this);
    }
}
