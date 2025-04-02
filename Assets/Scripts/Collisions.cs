using UnityEngine;

public class Collisions : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision occuring");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Objects are staying in collision");
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        
    }
    */

}
