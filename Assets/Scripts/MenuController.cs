using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] TMP_Text highScoretext;
    [SerializeField] TMP_Text playButtonText;
    [SerializeField] int maxNbCharges;
    [SerializeField] int timeToFillCharges;

    public const string HIGH_SCORE = "HighScore";
    public const string NB_CHARGES = "NbCharges";
    public const string RECHARGE_TIME = "RechargeTime";

    private int nbCharges;
    private DateTime rechargeTime;
    //private AndroidNotificationHandler notificationHandler;

    // Start is called before the first frame update
    void Start()
    {
        //notificationHandler = new AndroidNotificationHandler();

        int savedHighScore      = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        nbCharges               = PlayerPrefs.GetInt(NB_CHARGES, maxNbCharges);
        string rechargeTimeText = PlayerPrefs.GetString(RECHARGE_TIME, DateTime.Now.ToString());

        rechargeTime = DateTime.Parse(rechargeTimeText);

        if (rechargeTime < DateTime.Now)
            nbCharges = maxNbCharges;

        highScoretext.text = $"High Score: {savedHighScore}";
        playButtonText.text = $"PLAY ({nbCharges})";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaceLaunch()
    {
        if (nbCharges < 1) return;

        if (rechargeTime < DateTime.Now)
        {
            DateTime rechargeTime = DateTime.Now.AddMinutes(timeToFillCharges);

            PlayerPrefs.SetString(RECHARGE_TIME, rechargeTime.ToString());
#if UNITY_ANDROID
            AndroidNotificationHandler.ScheduleNotification(rechargeTime);
#endif
        }

        nbCharges--;

        PlayerPrefs.SetInt(NB_CHARGES, nbCharges);

        SceneManager.LoadScene(1);
    }
}
