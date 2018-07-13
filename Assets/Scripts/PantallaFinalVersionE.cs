using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class PantallaFinalVersionE : MonoBehaviour {

    public Text mFase1Tiempo, mFase1Fallos;
    public Text mFase2Tiempo, mFase2Fallos;
    public Text mFase3Tiempo, mFase3Fallos;
    public Text mFase4Tiempo, mFase4Fallos;
    public Text mFase5Tiempo, mFase5Fallos;
    public Text mFase6Tiempo, mFase6Fallos;
    public Text mFase7Tiempo, mFase7Fallos;

    public GameObject mExitButton;

	// Use this for initialization
	void Start () {
        mFase1Tiempo.text = PlayerPrefs.GetFloat("timeLevel1").ToString("0.##");
        mFase2Tiempo.text = PlayerPrefs.GetFloat("timeLevel2").ToString("0.##");
        mFase3Tiempo.text = PlayerPrefs.GetFloat("timeLevel3").ToString("0.##");
        mFase4Tiempo.text = PlayerPrefs.GetFloat("timeLevel4").ToString("0.##");
        mFase5Tiempo.text = PlayerPrefs.GetFloat("timeLevel5").ToString("0.##");
        mFase6Tiempo.text = PlayerPrefs.GetFloat("timeLevel6").ToString("0.##");
        mFase7Tiempo.text = PlayerPrefs.GetFloat("timeLevel7").ToString("0.##");

        mFase1Fallos.text = PlayerPrefs.GetInt("failsLevel1").ToString();
        mFase2Fallos.text = PlayerPrefs.GetInt("failsLevel2").ToString();
        mFase3Fallos.text = PlayerPrefs.GetInt("failsLevel3").ToString();
        mFase4Fallos.text = PlayerPrefs.GetInt("failsLevel4").ToString();
        mFase5Fallos.text = PlayerPrefs.GetInt("failsLevel5").ToString();
        mFase6Fallos.text = PlayerPrefs.GetInt("failsLevel6").ToString();
        mFase7Fallos.text = PlayerPrefs.GetInt("failsLevel7").ToString();
    }

    public void Exit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
