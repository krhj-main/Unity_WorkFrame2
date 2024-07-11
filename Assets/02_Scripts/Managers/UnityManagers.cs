using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManagers : MonoBehaviour
{
    static UnityManagers instance;
    public static UnityManagers Instance
    {
        get { return instance; }
    }

    InputManager input = new InputManager();

    public static InputManager Input
    {
        get { return Instance.input; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input.OnUpdate();
    }
}
