using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        score = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    private void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
