using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField]
    public int missileStrength;
    [SerializeField]
    private string rivalTag;

    private GameObject gameControl;
    private GameObject audioControl;
    private AudioSource hitSound;

    private void Start()
    {
        gameControl = GameObject.Find("GameControl");
        audioControl = GameObject.Find("AudioControl");
        hitSound = audioControl.GetComponent<AudioSource>();
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
            if (hitSound != null)
            {
                if (collision.gameObject.name != "MissileEnemy1" && collision.gameObject.name != "MissileEnemy2" && collision.gameObject.name != "MissileEnemy3" && !collision.gameObject.CompareTag("PlayerMissile"))
                {
                    hitSound.Play();
                }
            }
            gameObject.SetActive(false);
        }
    }
}
