using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private float missilespeed = 5;
    [SerializeField]
    private float missileAcceleration = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Translate(Vector3.up * missilespeed * Time.deltaTime);
        missilespeed *= missileAcceleration;
    }
}
