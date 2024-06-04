using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
    private MainView mainView;
    private static MainController controller = null;
    public static MainController Controller {
        get {
            return controller;
        }
    }
    public static void ShowMe() {
        if(controller == null) {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
            controller = obj.GetComponent<MainController>();
        }
        controller.gameObject.SetActive(true);
    }
    public static void HideMe() {
        if(controller != null) {
            controller.gameObject.SetActive(false);
        }
    }
    private void Start() {
        mainView = this.GetComponent<MainView>();
        mainView.UpdateInfo(PlayerModel.Data);
        mainView.btnRole.onClick.AddListener(() => { RoleController.ShowMe(); });

        PlayerModel.Data.AddEventListener(UpdateInfo);
    }
    private void UpdateInfo(PlayerModel data) {
        if(mainView != null)
            mainView.UpdateInfo(data);
    }
    private void OnDestroy() {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
