using UnityEngine;

public class explosionTransform : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        gameObject.transform.localScale += new Vector3(speed, speed);
    }
}
