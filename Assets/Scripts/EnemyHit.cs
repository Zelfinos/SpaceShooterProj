using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class EnemyHit : MonoBehaviour
{
    [SerializeField]
    public int missileStrength;
    [SerializeField]
    private string rivalTag;

    private GameObject gameControl;

    private void Start()
    {
        gameControl = GameObject.Find("GameControl");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(rivalTag))
        {
            Debug.Log("Missile touche un ennemi");
            collision.GetComponent<EnemyStats>().LoseLife(missileStrength);
            if (collision.gameObject.CompareTag("Player"))
            {
                gameControl.GetComponent<ScoreControl>().DecLife(missileStrength);
            }
            Destroy(gameObject);
        }
    }
}
