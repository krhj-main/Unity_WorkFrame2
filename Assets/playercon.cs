using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.Translate(Vector3.forward * Time.unscaledDeltaTime * 3f);
            // transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
    }
}
