using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RM : MonoBehaviour
{

    GameObject prefab;
    GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        //prefab = ResourcesManager.Instance.Instantiate("Cube");

        cube = ResourcesManager.Instance.Instantiate("Cube",GameObject.Find("RM").transform);

        Destroy(cube,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
