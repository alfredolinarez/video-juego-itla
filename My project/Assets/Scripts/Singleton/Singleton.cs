using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    protected static T _instance;
    public static T Instance
    {
        get => _instance;
        set => _instance = value;
    }
}
