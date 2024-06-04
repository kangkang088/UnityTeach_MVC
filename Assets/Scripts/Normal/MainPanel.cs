using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    public Text textName;
    public Text textLevel;
    public Text textMoney;
    public Text textGem;
    public Text textPower;
    public Button btnRole;
    private static MainPanel panel;
    public static MainPanel Panel => panel;
    void Start()
    {
        btnRole.onClick.AddListener(()=> { RolePanel.ShowMe(); });
    }
    public void UpdateInfo() {
        textName.text = PlayerPrefs.GetString("PlayerName","kangkang");
        textLevel.text = "LV." + PlayerPrefs.GetInt("PlayerLevel",15).ToString();
        textMoney.text = PlayerPrefs.GetFloat("PlayerMoney",9999).ToString();
        textGem.text = PlayerPrefs.GetFloat("PlayerGem",888).ToString();
        textPower.text = PlayerPrefs.GetFloat("PlayerPower",100).ToString();

    }
    public static void ShowMe() {
        if(panel == null) {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
            panel = obj.GetComponent<MainPanel>();
        }
        panel.gameObject.SetActive(true);
        panel.UpdateInfo();
    }
    public static void HideMe() {
        //1.
        //if(panel != null) {
        //    Destroy(panel.gameObject);
        //    panel = null;
        //}
        //2.
        if(panel != null) {
            panel.gameObject.SetActive(false);
        }
    }
}
