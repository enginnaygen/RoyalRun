using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void ChangeScore(int changeAmount)
    {
        score += changeAmount;
        scoreText.text = score.ToString();
    }
}
