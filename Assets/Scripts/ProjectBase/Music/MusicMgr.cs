using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicMgr : BaseManager<MusicMgr> {
    //唯一背景音乐
    private AudioSource bkMusic = null;
    //背景音乐音量
    private float bkValue = 1;
    //挂载音效们的唯一对象
    private GameObject soundObj = null;
    //音效记录容器
    private List<AudioSource> soundList = new List<AudioSource>();
    private float soundValue = 1;
    public MusicMgr() {
        MonoMgr.GetInstance().AddUpdateListener(MyUpdate);
    }
    private void MyUpdate() {
        for(int i = soundList.Count - 1;i >= 0;i--) {
            if(!soundList[i].isPlaying) {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);
            }        }
    }
    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void PlayBackMusic(string name) {
        if(bkMusic == null) {
            GameObject obj = new GameObject();
            obj.name = "BKMusic";
            bkMusic = obj.AddComponent<AudioSource>();
        }
        ResMgr.GetInstance().LoadAsync<AudioClip>("Music/BK/" + name,(music) => {
            bkMusic.clip = music;
            bkMusic.loop = true;
            bkMusic.volume = bkValue;
            bkMusic.Play();
        });
    }
    /// <summary>
    /// 改变背景音乐音量大小
    /// </summary>
    /// <param name="v"></param>
    public void ChangeBKMusicValue(float v) {
        bkValue = v;
        if(bkMusic == null)
            return;
        bkMusic.volume = bkValue;
    }
    /// <summary>
    /// 暂停背景音乐
    /// </summary>
    public void PauseBackMusic() {
        bkMusic.Pause();
    }
    /// <summary>
    /// 停止背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void StopBackMusic() {
        if(bkMusic == null)
            return;
        bkMusic.Stop();
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name"></param>
    public void PlaySound(string name,bool isLoop,UnityAction<AudioSource> callback = null) {
        if(soundObj == null) {
            soundObj = new GameObject();
            soundObj.name = "Sound";
        }
        ResMgr.GetInstance().LoadAsync<AudioClip>("Music/Sound/" + name,(music) => {
            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.clip = music;
            source.loop = isLoop;
            source.volume = soundValue;
            source.Play();
            soundList.Add(source);
            callback?.Invoke(source);
        });
    }
    /// <summary>
    /// 改变音效音量大小
    /// </summary>
    /// <param name="v"></param>
    public void ChangeSoundValue(float v) {
        soundValue = v;
        for(int i = 0;i < soundList.Count;i++) {
            soundList[i].volume = soundValue;
        }
    }
    /// <summary>
    /// 停止音效
    /// </summary>
    /// <param name="source"></param>
    public void StopSound(AudioSource source) {
        if(soundList.Contains(source)) {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }
}
