using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);

        if (transform == null)
        {
            return null;
        }
        return transform.gameObject;
    }

    // 최상의 부모, 이름은 비교하지않고 그 타입에만 해당하면 리턴 (컴포넌트이름)
    // 재귀적으로 사용 자식만 찾을건지 자식의 자식도 찾을 건지
    // Find().GetComponent<> 과정을 합친 기능
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
        {
            return null;
        }

        if (recursive == false)     // 직속 자식만 
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else// 자식의 자식까지
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }
            }
        }

        return null;
    }
    public static T GetorAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();

        if (component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }
    
}
