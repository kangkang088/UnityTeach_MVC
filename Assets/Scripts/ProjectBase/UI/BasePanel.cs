using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 面板基类
/// </summary>
public class BasePanel : MonoBehaviour {
    //所有控件的容器
    private Dictionary<string,List<UIBehaviour>> controlDic = new Dictionary<string,List<UIBehaviour>>();
    protected virtual void Awake() {
        FindChildControl<Button>();
        FindChildControl<Image>();
        FindChildControl<Text>();
        FindChildControl<Slider>();
        FindChildControl<Toggle>();
        FindChildControl<ScrollRect>();
        FindChildControl<InputField>();
    }
    protected virtual void OnClick(string buttonName) {

    }
    protected virtual void OnValueChanged(string toggleName,bool value) {

    }
    /// <summary>
    /// 显示面板
    /// </summary>
    public virtual void ShowMe() {

    }
    /// <summary>
    /// 隐藏面板
    /// </summary>
    public virtual void HideMe() {

    }
    /// <summary>
    /// 得到对应名字的对应控件脚本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="controlName"></param>
    /// <returns></returns>
    protected T GetControl<T>(string controlName) where T : UIBehaviour {
        if(controlDic.ContainsKey(controlName)) {
            for(int i = 0;i < controlDic[controlName].Count;i++) {
                if(controlDic[controlName][i] is T)
                    return controlDic[controlName][i] as T;
            }
        }
        return null;
    }
    /// <summary>
    /// 找到所有面板子控件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private void FindChildControl<T>() where T : UIBehaviour {
        T[] controls = this.GetComponentsInChildren<T>();
        for(int i = 0;i < controls.Length;i++) {
            string controlName = controls[i].gameObject.name;
            if(controlDic.ContainsKey(controlName))
                controlDic[controlName].Add(controls[i]);
            else
                controlDic.Add(controlName,new List<UIBehaviour>() { controls[i] });
            if(controls[i] is Button) {
                (controls[i] as Button).onClick.AddListener(() => {
                    OnClick(controlName);
                });
            }
            if(controls[i] is Toggle) {
                (controls[i] as Toggle).onValueChanged.AddListener((value) => {
                    OnValueChanged(controlName,value);
                });
            }
        }
    }
}
