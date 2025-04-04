using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    private int score;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    void OnEnable()
    {
        score = PlayerPrefs.GetInt("score");
    }

    private void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
