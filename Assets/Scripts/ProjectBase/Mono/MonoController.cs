using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 公共Mono管理者
/// </summary>
public class MonoController : MonoBehaviour
{
    private event UnityAction updateEvent;
    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update() {
        updateEvent?.Invoke();
    }
    public void AddUpdateListener(UnityAction func) {
        updateEvent += func;
    }
    public void RemoveUpdateListener(UnityAction func) {
        updateEvent -= func;
    }
}
