using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleView : MonoBehaviour
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

    public void UpdateInfo(PlayerModel data) {
        textHP.text = data.Hp.ToString();
        textAtk.text = data.Atk.ToString();
        textDef.text = data.Def.ToString();
        textLevel.text = "LV." + data.Level;
        textCrit.text = data.Crit.ToString();
        textMiss.text = data.Miss.ToString();
        textLucky.text = data.Lucky.ToString();
        
    }
}
