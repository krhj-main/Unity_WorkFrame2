using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int hp = 100;
    const int maxHp = 100;

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;

            if (hp > maxHp)
            {
                hp = maxHp;
                Debug.Log("hp�� �ִ� hp�� ���� ");
            }
            else if (hp <= 0)
            {
                OnDie();
            }
            Debug.Log("����  hp : " + hp);
        }
    }

    void OnDie()
    {
        Debug.Log("hp�� 0 �Ʒ��� ������");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
