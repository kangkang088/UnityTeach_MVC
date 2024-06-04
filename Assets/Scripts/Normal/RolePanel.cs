using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolePanel : MonoBehaviour {
    public Text textHP;
    public Text textAtk;
    public Text textDef;
    public Text textLevel;
    public Text textCrit;
    public Text textMiss;
    public Text textLucky;
    public Button btnClose;
    public Button btnUp;
    private static RolePanel panel;
    void Start() {
        btnClose.onClick.AddListener(() => { HideMe(); });
        btnUp.onClick.AddListener(() => {
            //升级
            int level = PlayerPrefs.GetInt("PlayerLevel");
            int hp = PlayerPrefs.GetInt("PlayerHP");
            int atk = PlayerPrefs.GetInt("PlayerAtk");
            int def = PlayerPrefs.GetInt("PlayerDef");
            int crit = PlayerPrefs.GetInt("PlayerCrit");
            int miss = PlayerPrefs.GetInt("PlayerMiss");
            int lucky = PlayerPrefs.GetInt("PlayerLucky");
            level += 1;
            hp += level;
            atk += level;
            def += level;
            crit += level;
            miss += level;
            lucky += level;
            PlayerPrefs.SetInt("PlayerLevel",level);
            PlayerPrefs.SetInt("PlayerHP",hp);
            PlayerPrefs.SetInt("PlayerAtk",atk);
            PlayerPrefs.SetInt("PlayerDef",def);
            PlayerPrefs.SetInt("PlayerCrit",crit);
            PlayerPrefs.SetInt("PlayerMiss",miss);
            PlayerPrefs.SetInt("PlayerLucky",lucky);

            UpdateInfo();
            MainPanel.Panel.UpdateInfo();
        });
    }
    public void UpdateInfo() {
        textLevel.text = "LV." + PlayerPrefs.GetInt("PlayerLevel",1);
        textHP.text = PlayerPrefs.GetInt("PlayerHP",100).ToString();
        textAtk.text = PlayerPrefs.GetInt("PlayerAtk",10).ToString();
        textDef.text = PlayerPrefs.GetInt("PlayerDef",5).ToString();
        textCrit.text = PlayerPrefs.GetInt("PlayerCrit",10).ToString();
        textMiss.text = PlayerPrefs.GetInt("PlayerMiss",1).ToString();
        textLucky.text = PlayerPrefs.GetInt("PlayerLucky",3).ToString();
    }
    public static void ShowMe() {
        if(panel == null) {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
            panel = obj.GetComponent<RolePanel>();
        }
        panel.gameObject.SetActive(true);
        panel.UpdateInfo();
    }
    public static void HideMe() {
        if(panel != null) {
            panel.gameObject.SetActive(false);
        }
    }
    void Update() {

    }
}
