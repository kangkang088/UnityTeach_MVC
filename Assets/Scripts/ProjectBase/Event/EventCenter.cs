using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventBase {

}
public class EventInfo<T> : IEventBase {
    public UnityAction<T> actions;
    public EventInfo(UnityAction<T> action) {
        actions += action;
    }
}
public class EventInfo : IEventBase {
    public UnityAction actions;
    public EventInfo(UnityAction action) {
        actions += action;
    }
}

/// <summary>
/// 事件中心
/// </summary>
public class EventCenter : BaseManager<EventCenter> {
    //key~事件名 value~监听事件的处理函数们
    private Dictionary<string,IEventBase> eventDic = new Dictionary<string,IEventBase>();

    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="eventName">事件名</param>
    /// <param name="action">处理事件的委托函数</param>
    public void AddListener<T>(string eventName,UnityAction<T> action) {
        if(eventDic.ContainsKey(eventName)) {
            (eventDic[eventName] as EventInfo<T>).actions += action;
        }
        else {
            eventDic.Add(eventName,new EventInfo<T>(action));
        }
    }
    public void AddListener(string eventName,UnityAction action) {
        if(eventDic.ContainsKey(eventName)) {
            (eventDic[eventName] as EventInfo).actions += action;
        }
        else {
            eventDic.Add(eventName,new EventInfo(action));
        }
    }
    /// <summary>
    /// 移除事件监听
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="action"></param>
    public void RemoveListener<T>(string eventName,UnityAction<T> action) {
        if(eventDic.ContainsKey(eventName)) {
            (eventDic[eventName] as EventInfo<T>).actions -= action;
        }
    }
    public void RemoveListener(string eventName,UnityAction action) {
        if(eventDic.ContainsKey(eventName)) {
            (eventDic[eventName] as EventInfo).actions -= action;
        }
    }
    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="eventName">触发的事件的事件名</param>
    public void EventTrigger<T>(string eventName,T obj) {
        if(eventDic.ContainsKey(eventName))
            (eventDic[eventName] as EventInfo<T>).actions?.Invoke(obj);

    }
    public void EventTrigger(string eventName) {
        if(eventDic.ContainsKey(eventName))
            (eventDic[eventName] as EventInfo).actions?.Invoke();

    }
    /// <summary>
    /// 切换场景时，清空事件中心
    /// </summary>
    public void Clear() {
        eventDic.Clear();
    }
}
