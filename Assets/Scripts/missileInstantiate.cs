using Unity.VisualScripting;
using UnityEngine;

public class MissileInstantiate : MonoBehaviour
{
    [SerializeField]
    private KeyCode ShootKey;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform SPoint1;
    [SerializeField]
    private Transform SPoint2;
    [SerializeField]
    private Transform parentRootTransform;
    [SerializeField]
    private Transform vaisseau;
    [SerializeField]
    private float reculAmount;
    [SerializeField]
    private float fireRate = 1f;

    private float nextFire = 0f;

    private AudioSource shootSound;

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(ShootKey))
        {
            if (Time.time > nextFire)
            {
                shootSound.Play();
                nextFire = Time.time + fireRate;
                GameObject missile1 = Instantiate(prefab, SPoint1.position, vaisseau.rotation);
                missile1.transform.parent = parentRootTransform;
                Object.Destroy(missile1, 1.5f);
                GameObject missile2 = Instantiate(prefab, SPoint2.position, vaisseau.rotation);
                missile2.transform.parent = parentRootTransform;
                Object.Destroy(missile2, 1.5f);
            }
        }
    }
}
