using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class MonoMgr : BaseManager<MonoMgr> {
    private MonoController controller;

    public MonoMgr() {
        GameObject obj = new GameObject("MonoController");
        controller = obj.AddComponent<MonoController>();
    }
    public void AddUpdateListener(UnityAction func) {
        controller.AddUpdateListener(func);
    }
    public void RemoveUpdateListener(UnityAction func) {
        controller.RemoveUpdateListener(func);
    }
    public Coroutine StartCoroutineListener(IEnumerator routine) {
        return controller.StartCoroutine(routine);
    }
    public Coroutine StartCoroutineListener(string methodName,[DefaultValue("null")] object value) {
        return controller.StartCoroutine(methodName,value);
    }
    public Coroutine StartCoroutineListener(string methodName) {
        return controller.StartCoroutine(methodName);
   }
    public void StopCoroutine(IEnumerator routine) {
        controller.StopCoroutine(routine);
    }
}
