using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 输入管理模块
/// </summary>
public class InputMgr : BaseManager<InputMgr> {
    private bool isStart = false;
    /// <summary>
    /// 构造函数中，添加Update监听
    /// </summary>
    public InputMgr() {
        MonoMgr.GetInstance().AddUpdateListener(MyUpdate);
    }
    /// <summary>
    /// 是否开启输入管理模块
    /// </summary>
    /// <param name="isOpen"></param>
    public void StartOrEndCheck(bool isOpen) {
        isStart = isOpen;
    }
    /// <summary>
    /// 用来检测按键抬起按下 分发事件的
    /// </summary>
    /// <param name="key"></param>
    void CheckKeyCode(KeyCode key) {
        if(Input.GetKeyDown(key))
            EventCenter.GetInstance().EventTrigger("Key_Down",key);
        if(Input.GetKeyUp(key))
            EventCenter.GetInstance().EventTrigger("Key_Up",key);
    }
    void MyUpdate() {
        if(!isStart)
            return;
        //wasd
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.D);
    }
}
