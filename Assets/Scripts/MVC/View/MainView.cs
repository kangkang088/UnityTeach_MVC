using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    public Text textName;
    public Text textLevel;
    public Text textMoney;
    public Text textGem;
    public Text textPower;
    public Button btnRole;

    public void UpdateInfo(PlayerModel data) {
        textName.text = data.PlayerName;
        textLevel.text = "LV." + data.Level.ToString();
        textMoney.text = data.Money.ToString();
        textGem.text = data.Gem.ToString();
        textPower.text = data.Power.ToString();
    }
}
