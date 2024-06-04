using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPresenter : MonoBehaviour {
    private MVP_MainView mvp_mainView;
    private static MainPresenter presenter = null;
    public static MainPresenter Presenter {
        get {
            return presenter;
        }
    }
    public static void ShowMe() {
        if(presenter == null) {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
            presenter = obj.GetComponent<MainPresenter>();
        }
        presenter.gameObject.SetActive(true);
    }
    public static void HideMe() {
        if(presenter != null) {
            presenter.gameObject.SetActive(false);
        }
    }
    private void Start() {
        mvp_mainView = this.GetComponent<MVP_MainView>();
        //mainView.UpdateInfo(PlayerModel.Data);
        UpdateInfo(PlayerModel.Data);
        mvp_mainView.btnRole.onClick.AddListener(() => {
            //RoleController.ShowMe();
            RolePresenter.ShowMe();
        });

        PlayerModel.Data.AddEventListener(UpdateInfo);
    }
    private void UpdateInfo(PlayerModel data) {
        if(mvp_mainView != null) {
            //mainView.UpdateInfo(data);
            mvp_mainView.textName.text = data.PlayerName;
            mvp_mainView.textLevel.text = "LV." + data.Level;
            mvp_mainView.textMoney.text = data.Money.ToString();
            mvp_mainView.textGem.text = data.Gem.ToString();
            mvp_mainView.textPower.text = data.Power.ToString();
        }
    }
    private void OnDestroy() {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
