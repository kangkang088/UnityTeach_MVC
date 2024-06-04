using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 抽屉容器
/// </summary>
public class PoolData {
    //抽屉中对象们的父节点
    public GameObject fatherObj;
    //抽屉中对象的容器
    public List<GameObject> poolList;
    public PoolData(GameObject obj,GameObject poolObj) {
        //给抽屉对象们创建父节点，并把父节点的父对象设置为池子
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.SetParent(poolObj.transform);
        poolList = new List<GameObject>() { };
        PushObj(obj);
    }
    public void PushObj(GameObject obj) {
        poolList.Add(obj);
        obj.transform.SetParent(fatherObj.transform);
        obj.SetActive(false);
    }
    public GameObject GetObj() {
        GameObject obj = null;
        obj = poolList[0];
        poolList.RemoveAt(0);
        obj.SetActive(true);
        obj.transform.SetParent(null);
        return obj;
    }
}
/// <summary>
/// 池子容器
/// </summary>
public class PoolMgr : BaseManager<PoolMgr> {
    //缓存池容器
    public Dictionary<string,PoolData> poolDic = new Dictionary<string,PoolData>();
    //缓存池根节点
    private GameObject poolObj;
    /// <summary>
    /// 往外拿东西
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public void GetObj(string name,UnityAction<GameObject> callback) {
        if(poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0) {
            callback(poolDic[name].GetObj());
        }
        else {
            ResMgr.GetInstance().LoadAsync<GameObject>(name,(o) => { o.name = name; callback(o); });
            //obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //obj.name = name;
        }
    }
    /// <summary>
    /// 还东西
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public void PushObj(string name,GameObject obj) {
        if(poolObj == null) {
            poolObj = new GameObject("Pool");
        }
        if(poolDic.ContainsKey(name)) {
            poolDic[name].PushObj(obj);
        }
        else {
            poolDic.Add(name,new PoolData(obj,poolObj));
        }
    }
    /// <summary>
    /// 过场景清空缓存池
    /// </summary>
    public void Clear() {
        poolDic.Clear();
        poolObj = null;
    }
}
