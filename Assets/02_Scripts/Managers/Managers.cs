using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    // ���ϼ��� �����
    // ������ �Ŵ����� ������´�


    // ������Ƽ �б�����  set�� ���� ���Ⱑ ����
    // s_instance ���� �ٲ�� �ȵǹǷ� get�� �����
    public static Managers Instance
    {
        get 
        {
            Init();

            return s_instance;
        }
    }

    private void Start()
    {
        Init();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject
                {
                    name = "@Managers"
                };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
