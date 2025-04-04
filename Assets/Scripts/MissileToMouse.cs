using UnityEngine;

public class MissileToMouse : MonoBehaviour
{
    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private float missilespeed = 5;
    [SerializeField]
    private float missileAcceleration = 1f;

    private Vector3 currentMouseClickWorldSpace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMouseClickWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        
        var heading = currentMouseClickWorldSpace - myTransform.position;
        var distance = heading.magnitude * 10;
        var direction = heading / distance;

        direction.z = 0;
        direction.x = (float)System.Math.Round((double)direction.x, 2);
        direction.y = (float)System.Math.Round((double)direction.y, 2);
        direction = direction.normalized;

        myTransform.Translate(direction * missilespeed * Time.deltaTime);
        missilespeed *= missileAcceleration;
    }
}
