using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] TMP_Text highScoretext;

    public const string HIGH_SCORE = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        int savedHighScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);

        highScoretext.text = $"High Score: {savedHighScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaceLaunch()
    {
        SceneManager.LoadScene(1);
    }
}
