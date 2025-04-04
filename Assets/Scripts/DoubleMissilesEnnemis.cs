
using UnityEngine;

public class DoubleMissilesEnnemis : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform SPoint1;
    [SerializeField]
    private Transform SPoint2;
    [SerializeField]
    private Quaternion offSet;
    [SerializeField]
    private Transform vaisseau;
    //[SerializeField]
    //private Vector2 recul;
    [SerializeField]
    private float FireRateMin;
    [SerializeField]
    private float FireRateMax;
    private float FireRate;

    private float NextFire = 0f;

    private AudioSource fireSound;

    private void Start()
    {
        fireSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time > NextFire)
        {
            FireRate = UnityEngine.Random.Range(FireRateMin, FireRateMax);
            NextFire = Time.time + FireRate;
            fireSound.Play();
            GameObject missile1 = Instantiate(prefab, SPoint1.position, vaisseau.rotation);
            GameObject missile2 = Instantiate(prefab, SPoint2.position, vaisseau.rotation);
            UnityEngine.Object.Destroy(missile1, 4.5f);
            UnityEngine.Object.Destroy(missile2, 4.5f);
            //vaisseau.Translate(recul);
        }
    }
}