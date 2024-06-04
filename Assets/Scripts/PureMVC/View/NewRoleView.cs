using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRoleView : MonoBehaviour
{
    public Text textHP;
    public Text textAtk;
    public Text textDef;
    public Text textLevel;
    public Text textCrit;
    public Text textMiss;
    public Text textLucky;
    public Button btnClose;
    public Button btnUp;
    public void UpdateInfo(PlayerDataObj data) {
        textHP.text = data.hp.ToString();
        textAtk.text = data.atk.ToString();
        textDef.text = data.def.ToString();
        textLevel.text = "LV." + data.lev;
        textCrit.text = data.crit.ToString();
        textMiss.text = data.miss.ToString();
        textLucky.text = data.lucky.ToString();

    }
}
