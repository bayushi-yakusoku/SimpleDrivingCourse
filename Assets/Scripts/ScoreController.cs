using System.Collections;
using System.Collections.Generic;
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

        textScore.text = "" + Mathf.FloorToInt(score);
    }
}
