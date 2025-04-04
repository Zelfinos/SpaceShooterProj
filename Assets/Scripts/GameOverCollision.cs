using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider entr� en collision");
        if (collision.gameObject.name == "Enemy1(Clone)" || collision.gameObject.name == "Enemy2(Clone)" || collision.gameObject.name == "Enemy3(Clone)")
        {
            Debug.Log("Conditions enemy respect�es");
            SceneManager.LoadScene(2);
        }
    }
}
