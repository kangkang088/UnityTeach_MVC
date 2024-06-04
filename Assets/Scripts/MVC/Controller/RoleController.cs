using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour {
    private RoleView roleView;
    private static RoleController controller;
    public static RoleController Controller {
        get {
            return controller;
        }
    }
    public static void ShowMe() {
        if(controller == null) {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
            controller = obj.GetComponent<RoleController>();
        }
        controller.gameObject.SetActive(true);
    }
    public static void HideMe() {
        if(controller != null) {
            controller.gameObject.SetActive(false);
        }
    }
    private void Start() {
        roleView = this.GetComponent<RoleView>();
        roleView.UpdateInfo(PlayerModel.Data);
        roleView.btnUp.onClick.AddListener(() => { PlayerModel.Data.LevelUp(); });
        roleView.btnClose.onClick.AddListener(() => { HideMe(); });
        PlayerModel.Data.AddEventListener(UpdateInfo);
    }
    private void UpdateInfo(PlayerModel data) {
        if(roleView != null)
            roleView.UpdateInfo(data);
    }
    private void OnDestroy() {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
