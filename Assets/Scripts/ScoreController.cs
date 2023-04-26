using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TMP_Text textScore;
    [SerializeField] int scoreIncrement;

    float score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += scoreIncrement * Time.deltaTime;

        textScore.text = $"{Mathf.FloorToInt(score)}";
    }

    private void OnDestroy()
    {
        int savedHighScore = PlayerPrefs.GetInt(MenuController.HIGH_SCORE, 0);

        if (score > savedHighScore)
        {
            PlayerPrefs.SetInt(MenuController.HIGH_SCORE, Mathf.FloorToInt(score));
        }
    }
}
