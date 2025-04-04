using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private float missilespeed = 5;
    [SerializeField]
    private float missileAcceleration = 1f;

    void Start()
    {
   
    }

    void Update()
    {
        myTransform.Translate(Vector3.up * missilespeed * Time.deltaTime);
        missilespeed *= missileAcceleration;
    }
}
