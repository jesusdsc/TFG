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

public class PantallaFinal : MonoBehaviour {

    private float totalTime;
    private int fallos;

    private const string CORREO_GESTOR = "yure.yera.gestor@gmail.com";
    private string userCorreo;
    private string userName;
    private string profesorCorreo;
    public GameObject mSendCorreo;
    public GameObject mSalir;
    public GameObject mTextoDespedida;
    public GameObject marcoProfesorError, marcoUserError;

    private void Start()
    {
        totalTime = PlayerPrefs.GetFloat("timeLevel1") + PlayerPrefs.GetFloat("timeLevel2") + PlayerPrefs.GetFloat("timeLevel3") + PlayerPrefs.GetFloat("timeLevel4") +
            PlayerPrefs.GetFloat("timeLevel5") + PlayerPrefs.GetFloat("timeLevel6") + PlayerPrefs.GetFloat("timeLevel7") + PlayerPrefs.GetFloat("timeLevel8");
        fallos = PlayerPrefs.GetInt("failsLevel1") + PlayerPrefs.GetInt("failsLevel2") + PlayerPrefs.GetInt("failsLevel3") + PlayerPrefs.GetInt("failsLevel4") +
            PlayerPrefs.GetInt("failsLevel5") + PlayerPrefs.GetInt("failsLevel6") + PlayerPrefs.GetInt("failsLevel7") + PlayerPrefs.GetInt("failsLevel8");
    }
    public void CheckName(string name)
    {
        userName = name;
    }

    public void CheckCorreoPropio(string correo)
    {
        if (IsEmail(correo))
        {
            userCorreo = correo;
            Debug.Log("user correo");
            marcoUserError.SetActive(false);
        }
        else
        {
            Debug.Log("No es un correo");
            marcoUserError.SetActive(true);
        }
    }

    public void CheckCorreoProfesor(string correo)
    {
        if (IsEmail(correo))
        {
            profesorCorreo = correo;
            Debug.Log("profesor correo");
            marcoProfesorError.SetActive(false);
        }
        else
        {
            Debug.Log("No es un correo");
            marcoProfesorError.SetActive(true);
        }
    }

    public const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
          + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    private static bool IsEmail(string email)
    {
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
    } 

    public void sendMail()
    {
        if (IsEmail(userCorreo) && IsEmail(profesorCorreo))
        {
            PrivateSendEmail();
        }
        else
        {
            Debug.Log("CORREOS MALOS");
        }
        
    }

    private void PrivateSendEmail()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(CORREO_GESTOR);
        mail.To.Add(profesorCorreo);
        mail.Subject = "Puntuaciones de " + userName;
        mail.Body = "Correo de " + userName + ": " + userCorreo +
            "\nTiempo Fase 1: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel1")) + "\t Fallos Fase 1: " + PlayerPrefs.GetInt("failsLevel1") +
            "\nTiempo Fase 2: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel2")) + "\t Fallos Fase 2: " + PlayerPrefs.GetInt("failsLevel2") +
            "\nTiempo Fase 3: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel3")) + "\t Fallos Fase 3: " + PlayerPrefs.GetInt("failsLevel3") +
            "\nTiempo Fase 4: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel4")) + "\t Fallos Fase 4: " + PlayerPrefs.GetInt("failsLevel4") +
            "\nTiempo Fase 5: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel5")) + "\t Fallos Fase 5: " + PlayerPrefs.GetInt("failsLevel5") +
            "\nTiempo Fase 6: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel6")) + "\t Fallos Fase 6: " + PlayerPrefs.GetInt("failsLevel6") +
            "\nTiempo Fase 7: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel7")) + "\t Fallos Fase 7: " + PlayerPrefs.GetInt("failsLevel7") +
            "\nTiempo total: " + String.Format("{0:0.00}", totalTime) + "\t Fallos totales: " + fallos;

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential(CORREO_GESTOR, "reaandchris2712") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");
        mSendCorreo.GetComponent<Button>().interactable = false;

        PlayerPrefs.DeleteAll();
        mSalir.SetActive(true);
        mTextoDespedida.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
