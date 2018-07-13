using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    //public GameObject IngredientsPanel;
    public GameObject ingredientes;
    public GameObject mantequilla;
    public GameObject huevos;
    public GameObject harina;
    public GameObject polvo;
    public GameObject azucar;
    public GameObject leche;
    public GameObject naranja;
    public GameObject vainilla;
    public GameObject buttonContinue;

    public GameObject pauseMarco, buttonPause;
    private bool paused = false;
    private bool muted = false;

    public int currentLine;
    public int endLine;

    public Animator mYure, mYera;

    // Use this for initialization
    void Start()
    {
        // IngredientsPanel.SetActive(false);
        //EventSystem.current.SetSelectedGameObject(textBox);
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }

        mYera.SetBool("hablando", false);
        mYure.SetBool("hablando", false);
        if (endLine == 0) endLine = textLines.Length - 1;

        PlayerPrefs.SetString("savedLevel", SceneManager.GetActiveScene().name);
    }


    void Update()
    {
        //eggsText.text = eggs.value.ToString("0.00");

        textManager();
    }

    void textManager()
    {
        if (currentLine > endLine)
        {
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);
            //textBox.SetActive(false);
            return;
        }
        if (currentLine == 4) ingredientes.SetActive(true);
        if (currentLine == 5) huevos.SetActive(true);
        if (currentLine == 7) harina.SetActive(true);
        if (currentLine == 9) mantequilla.SetActive(true);
        if (currentLine == 11) polvo.SetActive(true);
        if (currentLine == 13) leche.SetActive(true);
        if (currentLine == 15) naranja.SetActive(true);
        if (currentLine == 17) azucar.SetActive(true);
        if (currentLine == 19) vainilla.SetActive(true);
        if (currentLine == 29) buttonContinue.SetActive(true);
        theText.text = textLines[currentLine];
        if (!paused && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && currentLine != 29) currentLine += 1;

        if (textLines[currentLine].Substring(0, 4).Equals("Yera"))
        {
            mYera.SetBool("hablando", true);
            mYure.SetBool("hablando", false);
        }

        if (textLines[currentLine].Substring(0, 4).Equals("Yure"))
        {
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", true);
        }
    }

    /// <summary>
    /// Pausa el juego.
    /// </summary>
    public void Pausa()
    {
        paused = !paused;
        if (paused)
        {
            buttonPause.SetActive(false);
            pauseMarco.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            buttonPause.SetActive(true);
            pauseMarco.SetActive(false);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// Sale del juego.
    /// </summary>
    public void Salir()
    {
        Application.Quit();
    }

    /// <summary>
    /// Mutea - pausa la musica.
    /// </summary>
    public void Mutear()
    {
        muted = !muted;
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
