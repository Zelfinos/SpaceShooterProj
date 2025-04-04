using UnityEngine;

public class explosionTransform : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float explosionTime;

    private float explosionMoment;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        explosionMoment = Time.time + explosionTime;
    }
    void Update()
    {
        gameObject.transform.localScale += new Vector3(speed, speed);
        if (Time.time > explosionMoment)
        {
            spriteRenderer.color = Color.clear;
        }
        Destroy(gameObject, 3f);
    }
}
