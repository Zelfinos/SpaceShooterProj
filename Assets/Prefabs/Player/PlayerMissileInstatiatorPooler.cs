using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMissileInstatiatorPooler : MonoBehaviour
{
    [SerializeField]
    private KeyCode ShootKey;
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
                GameObject missile1 = FirePooler.instance.getPoolObject();
                if (missile1 != null)
                {
                    missile1.transform.position = SPoint1.position;
                    missile1.SetActive(true);
                    //missile1.transform.parent = parentRootTransform;
                }
                else
                {
                    Debug.Log("Plus de pool dispos");
                }

                    //Object.Destroy(missile1, 1.5f);
                    GameObject missile2 = FirePooler.instance.getPoolObject();
                if (missile2 != null)
                {
                    missile2.transform.position = SPoint2.position;
                    missile2.SetActive(true);
                    //missile2.transform.parent = parentRootTransform;
                }
                
                //Object.Destroy(missile2, 1.5f);
            }
        }
    }
}
