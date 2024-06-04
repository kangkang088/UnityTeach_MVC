using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum E_UI_Layer {
    Bot, Mid, Top, System
}
/// <summary>
/// UI管理器 管理所有面板
/// </summary>
public class UIMgr : BaseManager<UIMgr> {
    //管理的面板的容器
    public Dictionary<string,BasePanel> panelDic = new Dictionary<string,BasePanel>();
    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;
    //记录UI的Canvas父对象，方便以后使用
    public RectTransform canvas;
    public UIMgr() {
        GameObject obj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
        canvas = obj.transform as RectTransform;
        GameObject.DontDestroyOnLoad(obj);
        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");


        obj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }
    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="panelName">面板名</param>
    /// <param name="layer">面板层级</param>
    /// <param name="callback">面板创建完成后的逻辑</param>
    public void ShowPanel<T>(string panelName,E_UI_Layer layer = E_UI_Layer.Mid,UnityAction<T> callback = null) where T : BasePanel {
        if(panelDic.ContainsKey(panelName)) {
            panelDic[panelName].ShowMe();
            callback?.Invoke(panelDic[panelName] as T);
            return;
        }
        ResMgr.GetInstance().LoadAsync<GameObject>("UI/" + panelName,(obj) => {
            Transform father = mid;
            switch(layer) {
                case E_UI_Layer.Bot:
                    father = bot;
                    break;
                case E_UI_Layer.Mid:
                    father = mid;
                    break;
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
            }
            obj.transform.SetParent(father);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            (obj.transform as RectTransform).offsetMax = Vector3.zero;
            (obj.transform as RectTransform).offsetMin = Vector3.zero;

            //得到预设体面板上的脚本
            T panel = obj.GetComponent<T>();
            //处理得到面板后的逻辑
            callback?.Invoke(panel);
            panel.ShowMe();
            //存面板
            panelDic.Add(panelName,panel);
        });
    }
    /// <summary>
    /// 隐藏面板
    /// </summary>
    public void HidePanel(string panelName) {
        if(panelDic.ContainsKey(panelName)) {
            panelDic[panelName].HideMe();
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }
    /// <summary>
    /// 得到某个已经显示的面板，方便使用
    /// </summary>
    /// <param name="panelName"></param>
    public T GetPanel<T>(string panelName)where T:BasePanel {
        if(panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        return null;
    }
    /// <summary>
    /// 得到层级父对象
    /// </summary>
    /// <param name="layer"></param>
    /// <returns></returns>
    public Transform GetLayerTransform(E_UI_Layer layer) {
        switch(layer) {
            case E_UI_Layer.Bot:
                return bot;                
            case E_UI_Layer.Mid:
                return mid;                
            case E_UI_Layer.Top:
                return top;                
            case E_UI_Layer.System:
                return system;
            default:
                return null;
        }
    }
    /// <summary>
    /// 给控件添加自定义事件监听
    /// </summary>
    /// <param name="control">控件对象</param>
    /// <param name="type">事件类型</param>
    /// <param name="callback">事件响应函数</param>
    public void AddCustomEventListener(UIBehaviour control,EventTriggerType type,UnityAction<BaseEventData> callback) {
        EventTrigger trigger = control.GetComponent<EventTrigger>();
        if(trigger == null)
            trigger = control.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(callback);
        trigger.triggers.Add(entry);
    }
}
