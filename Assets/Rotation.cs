using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private float rotationSpeedMax;
    [SerializeField] 
    private float rotationSpeedMin;

    private float rotationSpeed;

    private void Start()
    {
        rotationSpeed = Random.Range(rotationSpeedMax, rotationSpeedMin);
    }
    private void Update()
    {
        myTransform.Rotate(0, 0, rotationSpeed);
    }
}
