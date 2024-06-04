using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolePresenter : MonoBehaviour
{
    private MVP_RoleView roleView;
    private static RolePresenter presenter;
    public static RolePresenter Presenter {
        get {
            return presenter;
        }
    }
    public static void ShowMe() {
        if(presenter == null) {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
            presenter = obj.GetComponent<RolePresenter>();
        }
        presenter.gameObject.SetActive(true);
    }
    public static void HideMe() {
        if(presenter != null) {
            presenter.gameObject.SetActive(false);
        }
    }
    private void Start() {
        roleView = this.GetComponent<MVP_RoleView>();

        //roleView.UpdateInfo(PlayerModel.Data);
        UpdateInfo(PlayerModel.Data);

        roleView.btnUp.onClick.AddListener(() => { PlayerModel.Data.LevelUp(); });
        roleView.btnClose.onClick.AddListener(() => { HideMe(); });
        PlayerModel.Data.AddEventListener(UpdateInfo);
    }
    private void UpdateInfo(PlayerModel data) {
        if(roleView != null) {
            //roleView.UpdateInfo(data);
            roleView.textLevel.text = "LV." + data.Level;
            roleView.textHP.text = data.Hp.ToString();
            roleView.textAtk.text = data.Atk.ToString();
            roleView.textDef.text = data.Def.ToString();
            roleView.textCrit.text = data.Crit.ToString();
            roleView.textMiss.text = data.Miss.ToString();
            roleView.textLucky.text = data.Lucky.ToString();
        }

    }
    private void OnDestroy() {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
