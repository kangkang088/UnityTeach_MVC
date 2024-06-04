using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMainView : MonoBehaviour
{
    public Text textName;
    public Text textLevel;
    public Text textMoney;
    public Text textGem;
    public Text textPower;
    public Button btnRole;

    ///MVC思想就写这个方法
    public void UpdateInfo(PlayerDataObj data) {
        textName.text = data.playerName;
        textLevel.text = "LV." + data.lev.ToString();
        textMoney.text = data.money.ToString();
        textGem.text = data.gem.ToString();
        textPower.text = data.power.ToString();
    }
}
