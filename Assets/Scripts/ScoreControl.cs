using UnityEngine;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    [SerializeField]
    public int score;
    [SerializeField]
    public TextMeshProUGUI scoreText;
    [SerializeField]
    public TextMeshProUGUI playerLifeText;
    [SerializeField]
    private int playerLife;

    public static ScoreControl instance;

    private void Start()
    {
        score = 0;
        playerLife = 100;
        scoreText.text = score.ToString();
        playerLifeText.color = Color.green;
        playerLifeText.text = playerLife.ToString() + "%";
        IncScore(0);
    }
    public void IncScore(int scoreBonus)
    {
        score += scoreBonus;
        scoreText.text = score.ToString();
    }
    public void DecLife(int damage)
    {
        playerLife -= damage;

        if (playerLife < 60)
        {
            playerLifeText.color = Color.cyan;
        }
        if (playerLife < 30)
        {
            playerLifeText.color = Color.red;
        }
        playerLifeText.text = playerLife.ToString() + "%";
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
    }
}
