using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class PantallaInicioVersionE : MonoBehaviour
{

    private float timeToWait = 1.75f;
    private float currentWaitTime;
    private bool checkTime;

    public GameObject mStartButton;
    public GameObject mAbout;
    public GameObject mSettings;
    public GameObject mCredits;
    public GameObject mNewGame;
    public GameObject mContinue;
    public GameObject mComeBack;
    public GameObject mMenu;
    public GameObject mCreditosText;
    public GameObject mAboutText;
    public GameObject mSettingsText;
    public GameObject mSettingsImage;
    public GameObject mSelectFaseButton;

    void Awake()
    {
        ResetTimer();
    }

    void Update()
    {
        if (checkTime)
        {
            currentWaitTime -= Time.deltaTime;
            if (currentWaitTime < 0)
            {
                TimerFinished();
                checkTime = false;
            }
        }

        if (!PlayerPrefs.HasKey("savedLevel"))
        {
            mContinue.GetComponent<Button>().interactable = false;
            mNewGame.GetComponent<Button>().interactable = true;
        }
        else
        {
            mContinue.GetComponent<Button>().interactable = true;
            mNewGame.GetComponent<Button>().interactable = false;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("savedLevel"));
    }

    public void ResetTimer()
    {
        currentWaitTime = timeToWait;
        checkTime = true;
    }

    void TimerFinished()
    {
        mStartButton.SetActive(true);
    }

    public void ShowButtons()
    {
        mStartButton.SetActive(false);
        mAbout.SetActive(true);
        mCredits.SetActive(true);
        mSettings.SetActive(true);
        mNewGame.SetActive(true);
        mContinue.SetActive(true);
        mSelectFaseButton.SetActive(true);
    }

    public void GoToCreditos()
    {
        mAbout.SetActive(false);
        mCredits.SetActive(false);
        mSettings.SetActive(false);
        mNewGame.SetActive(false);
        mContinue.SetActive(false);
        mMenu.SetActive(false);
        mSelectFaseButton.SetActive(false);

        mCreditosText.SetActive(true);
        mComeBack.SetActive(true);
    }

    public void GoToAbout()
    {
        mAbout.SetActive(false);
        mCredits.SetActive(false);
        mSettings.SetActive(false);
        mNewGame.SetActive(false);
        mContinue.SetActive(false);
        mMenu.SetActive(false);
        mSelectFaseButton.SetActive(false);

        mAboutText.SetActive(true);
        mComeBack.SetActive(true);
    }

    public void GoToSettings()
    {
        mAbout.SetActive(false);
        mCredits.SetActive(false);
        mSettings.SetActive(false);
        mNewGame.SetActive(false);
        mContinue.SetActive(false);
        mMenu.SetActive(false);
        mSelectFaseButton.SetActive(false);

        mSettingsImage.SetActive(true);
        mSettingsText.SetActive(true);
        mComeBack.SetActive(true);
    }

    public void ComeBack()
    {
        mAbout.SetActive(true);
        mCredits.SetActive(true);
        mSettings.SetActive(true);
        mNewGame.SetActive(true);
        mContinue.SetActive(true);
        mMenu.SetActive(true);
        mSelectFaseButton.SetActive(true);

        mSettingsImage.SetActive(false);
        mSettingsText.SetActive(false);
        mAboutText.SetActive(false);
        mCreditosText.SetActive(false);
        mComeBack.SetActive(false);
    }

    public void SelectFase()
    {
        SceneManager.LoadScene("SeleccionFase");
    }
}
