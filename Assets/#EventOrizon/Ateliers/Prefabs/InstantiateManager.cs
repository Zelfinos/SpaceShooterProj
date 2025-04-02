using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab1ToUse;

    [SerializeField]
    private Transform SPoint;

    [SerializeField]
    private Transform parentRootTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bot = Instantiate(prefab1ToUse,this.transform.position, Quaternion.identity);
        }
    }
}
