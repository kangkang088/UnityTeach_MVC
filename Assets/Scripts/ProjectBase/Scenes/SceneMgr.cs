using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : BaseManager<SceneMgr>
{
    /// <summary>
    /// 切换场景接口（同步）
    /// </summary>
    /// <param name="name">场景名</param>
    public void LoadScene(string name,UnityAction func) {
        SceneManager.LoadScene(name);
        func();
    }
    /// <summary>
    /// 切换场景接口（异步）
    /// </summary>
    /// <param name="name"></param>
    /// <param name="func"></param>
    public void LoadSceneAsync(string name,UnityAction func) {
        MonoMgr.GetInstance().StartCoroutineListener(ReallyLoadSceneAsync(name,func));
    }
    /// <summary>
    /// 异步加载场景协程函数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    IEnumerator ReallyLoadSceneAsync(string name,UnityAction func) {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while(!ao.isDone) {
            //这里更新进度条
            EventCenter.GetInstance().EventTrigger("Loading",ao.progress);
            yield return ao.progress;
        }
        func();
    }
}
