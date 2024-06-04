using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVE_RolePanel : BasePanel
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
            case "btnClose":
                UIMgr.GetInstance().HidePanel("RolePanel");
                break;
            case "btnLevUp":
                MVE_PlayerModel.Data.LevelUp();
                break;
            default:
                break;
        }
    }
    public void UpdateInfo(MVE_PlayerModel data) {
        GetControl<Text>("txtLev").text = "LV." + data.Level;
        GetControl<Text>("txtHp").text = data.Hp.ToString();
        GetControl<Text>("txtAtk").text = data.Atk.ToString();
        GetControl<Text>("txtDef").text = data.Def.ToString();
        GetControl<Text>("txtCrit").text = data.Crit.ToString();
        GetControl<Text>("txtMiss").text = data.Miss.ToString();
        GetControl<Text>("txtLuck").text = data.Lucky.ToString();
    }
    // Update is called once per frame
    void Update() {

    }
    private void OnDestroy() {
        //MVE_PlayerModel.Data.RemoveEventListener(UpdateInfo);
        EventCenter.GetInstance().RemoveListener<MVE_PlayerModel>("PlayerData",UpdateInfo);
    }
}
