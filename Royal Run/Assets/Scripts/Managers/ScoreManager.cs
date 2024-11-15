using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI scoreText;

    int score;


    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void ChangeScore(int changeAmount)
    {
        if (gameManager.GameOver) return;

        score += changeAmount;
        scoreText.text = score.ToString();
    }
}
