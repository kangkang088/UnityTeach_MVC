using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 资源加载模块
/// </summary>
public class ResMgr : BaseManager<ResMgr> {
    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <param name="name"></param>
    public T Load<T>(string name) where T : Object {
        T res = null;
        res = Resources.Load<T>(name);
        if(res is GameObject)
            return GameObject.Instantiate(res);
        else
            return res;
    }
    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <param name="name"></param>
    public void LoadAsync<T>(string name,UnityAction<T> callback) where T : Object {
        MonoMgr.GetInstance().StartCoroutineListener(ReallyLoadAsync<T>(name,callback));
    }
    IEnumerator ReallyLoadAsync<T>(string name,UnityAction<T> callback) where T : Object {
        ResourceRequest rr = Resources.LoadAsync<T>(name);
        yield return rr;
        if(rr.asset is GameObject)
            callback(GameObject.Instantiate(rr.asset) as T);
        else
            callback(rr.asset as T);
    }
}
