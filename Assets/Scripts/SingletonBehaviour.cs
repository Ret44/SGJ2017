using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour {

    public static T instance;

    public void Awake()
    {
        instance = gameObject.GetComponent<T>();
    }
}
