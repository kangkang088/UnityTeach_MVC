﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour {
    private static T instance;
    protected virtual void Awake() {
        instance = this as T;
    }
    public static T GetInstance() {
        return instance;
    }
}
