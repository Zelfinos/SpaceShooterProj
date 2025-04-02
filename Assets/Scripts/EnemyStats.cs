using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private int life;
    [SerializeField]
    public int scoreGain;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject explosion;

    private GameObject gameControl;

    private void Start()
    {
        gameControl = GameObject.Find("GameControl");
    }

    public void LoseLife(int strength)
    {
        StartCoroutine(HitColorChangeCoroutine(gameObject.GetComponent<SpriteRenderer>()));
        life -= strength;
        if (life <= 0)
        {

            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(2);
            }

            int scoreGain = gameObject.GetComponent<EnemyStats>().scoreGain;
            gameControl.GetComponent<ScoreControl>().IncScore(scoreGain);
            if (explosion != null)
            {
                var exploder = gameObject.GetComponent<EnemyStats>().explosion;
                GameObject destruction = Instantiate(exploder, gameObject.transform.position, Quaternion.identity);
                Destroy(destruction, 0.2f);
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator HitColorChangeCoroutine(SpriteRenderer sprite)
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Change color to white again");
        sprite.color = Color.white;
    }
}