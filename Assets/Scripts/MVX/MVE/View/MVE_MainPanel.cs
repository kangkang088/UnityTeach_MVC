using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVE_MainPanel : BasePanel
{
    // Start is called before the first frame update
    void Start() {
        UpdateInfo(MVE_PlayerModel.Data);
        //MVE_PlayerModel.Data.AddEventListener(UpdateInfo);
        EventCenter.GetInstance().AddListener<MVE_PlayerModel>("PlayerData",UpdateInfo);
    }
    protected override void OnClick(string buttonName) {
        base.OnClick(buttonName);
        switch(buttonName) {
            case "btnRole":
                UIMgr.GetInstance().ShowPanel<MVE_RolePanel>("RolePanel");
                break;
        }
    }
    public void UpdateInfo(MVE_PlayerModel data) {
        GetControl<Text>("txtName").text = data.PlayerName;
        GetControl<Text>("txtLev").text = "LV." + data.Level;
        GetControl<Text>("txtMoney").text = data.Money.ToString();
        GetControl<Text>("txtGem").text = data.Gem.ToString();
        GetControl<Text>("txtPower").text = data.Power.ToString();
    }
    private void OnDestroy() {
        //MVE_PlayerModel.Data.RemoveEventListener(UpdateInfo);
        EventCenter.GetInstance().RemoveListener<MVE_PlayerModel>("PlayerData",UpdateInfo);
    }
}
