using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UltimoNivel : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public GameObject calculador;
    private int id;
    public Text textoValorEntero, textoValorNumerador, textoValorDenominador;
    public GameObject BotonesDeEdicion;
    public GameObject unidadesMant, unidadesResto;
    public GameObject buttonLog, buttoncheck, buttonContinue, log, log2, log3;
    public GameObject movil, botonMensaje, textoMensaje;
    public GameObject papelGotas, papelLimonada, papelPrecio;
    public GameObject pauseMarco, buttonPause;
    public int currentLine;
    public int endLine;
    int valorEntero, valorNumerador, valorDenominador;

    public Text tiempoValor, intentosValor;
    public GameObject pantallaVictoria, trofeos;

    public GameObject mGotas, mPrecioVuelo, mLimonadaGrande;
    public GameObject fraccionLimonada, enteraLimonada, yLimonada;
    public Text mGotasCentenas, mGotasDecenas, mGotasUnidades;
    public Text mPrecioCentenas, mPrecioDecenas, mPrecioUnidades;
    public Text mLimonadaValorEntero, mLimonadaValorNumerador, mLimonadaValorDenominador;

    public GameObject objetivoTextoPrecio, objetivoTextoLimonada, objetivoTextoGotas;
    public GameObject mGotasErrorMarco;
    public GameObject mPrecioVueloErrorMarco;
    public GameObject mLimonadaErrorMarco;

    public GameObject mStar1;
    public GameObject mStar2;
    public GameObject mStar3;
    public Animator mYure, mYera;

    public GameObject fondo1, fondo2, fondo3;

    private bool paused = false;
    private bool muted = false;
    private int intentos = 0;
    private float time;
    private int problema = 1;

    private const string PANTALLA_FINAL = "PantallaFinal";

    public Text numeroEstrellas;

    // Use this for initialization
    void Start()
    {
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }
        mYera.SetBool("hablando", false);
        mYure.SetBool("hablando", false);
        PlayerPrefs.SetString("savedLevel", SceneManager.GetActiveScene().name);
        valorEntero = 0;
        valorNumerador = 0;
        valorDenominador = 0;
        id = 0;
        if (endLine == 0) endLine = textLines.Length - 1;

        numeroEstrellas.text = (PlayerPrefs.GetInt("estrellasLevel2") + PlayerPrefs.GetInt("estrellasLevel3") + PlayerPrefs.GetInt("estrellasLevel4") + PlayerPrefs.GetInt("estrellasLevel5") + PlayerPrefs.GetInt("estrellasLevel6")).ToString();
    }


    void Update()
    {
        //eggsText.text = eggs.value.ToString("0.00");


        textManager();
    }

    void textManager()
    {
        theText.text = textLines[currentLine];
        if (currentLine > endLine)
        {
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);
            //textBox.SetActive(false);
            return;
        }
        if (currentLine == 22)
        {
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", true);
            //textBox.SetActive(false);
            return;
        }
        

        if (currentLine == 5)
        {
            mGotas.SetActive(true);
            objetivoTextoGotas.SetActive(true);
            papelGotas.SetActive(true);
            time = Time.time;
            Debug.Log("Tiempo: " + time);

            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);
            BotonesDeEdicion.SetActive(true);
            buttonLog.SetActive(true);
            buttoncheck.SetActive(true);
        }

        if (currentLine == 10)
        {
            mLimonadaGrande.SetActive(true);
            papelLimonada.SetActive(true);
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);

            BotonesDeEdicion.SetActive(true);
            buttonLog.SetActive(true);
            buttoncheck.SetActive(true);
        }

        if (currentLine == 17)
        {
            papelPrecio.SetActive(true);
            mPrecioVuelo.SetActive(true);
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);

            BotonesDeEdicion.SetActive(true);
            buttonLog.SetActive(true);
            buttoncheck.SetActive(true);
        }

        if (textLines[currentLine].Substring(0, 4).Equals("Yera") && (currentLine != 5) && currentLine != 10 &&
            currentLine != 17 && currentLine != 22 && currentLine != 25 && currentLine != 27)
        {
            mYera.SetBool("hablando", true);
            mYure.SetBool("hablando", false);
        }

        if (textLines[currentLine].Substring(0, 4).Equals("Yure") && (currentLine != 5) && currentLine != 10 &&
            currentLine != 17 && currentLine != 22 && currentLine != 25 && currentLine != 27)
        {
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", true);
        }
        if (!paused && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && (currentLine != 5) && currentLine != 10 &&
            currentLine != 17 && currentLine != 22 && currentLine != 25 && currentLine != 27) currentLine += 1;

    }

    public void botonSi()
    {

        currentLine = 26;
    }

    public void leerMensaje()
    {
        botonMensaje.SetActive(false);
        textoMensaje.SetActive(true);
        currentLine = 7;
    }
    public void botonNo()
    {
        buttonContinue.SetActive(true);
        currentLine = 21;
    }

    public void botonSumaEntero()
    {
        valorEntero++;
        if (valorEntero == 10) valorEntero = 0;

        textoValorEntero.text = valorEntero.ToString();


    }

    public void botonRestaEntero()
    {
        valorEntero--;
        if (valorEntero == -1) valorEntero = 9;

        textoValorEntero.text = valorEntero.ToString();


    }

    public void botonSumaNumerador()
    {
        valorNumerador++;
        if (valorNumerador == 10) valorNumerador = 0;

        textoValorNumerador.text = valorNumerador.ToString();


    }

    public void botonRestaNumerador()
    {

        valorNumerador--;
        if (valorNumerador == -1) valorNumerador = 9;

        textoValorNumerador.text = valorNumerador.ToString();


    }

    public void botonSumaDenominador()
    {
        valorDenominador++;
        if (valorDenominador == 10) valorDenominador = 0;
        //calculador.SetActive(true);
        textoValorDenominador.text = valorDenominador.ToString();


    }

    public void botonRestaDenominador()
    {

        valorDenominador--;
        if (valorDenominador == -1) valorDenominador = 9;

        textoValorDenominador.text = valorDenominador.ToString();


    }
    public void botonEditarLeche()
    {
        
        if(problema == 1)
        {
            if (log.activeSelf)
            {
                log.SetActive(false);
            }

            id = 1;
            calculador.SetActive(true);
            unidadesMant.SetActive(true);
            BotonesDeEdicion.SetActive(false);

            buttonLog.GetComponent<Button>().interactable = false;
            buttoncheck.GetComponent<Button>().interactable = false;
        }
        else
        {
            if(problema == 2)
            {
                if (log2.activeSelf)
                {
                    log2.SetActive(false);
                }

                id = 2;
                calculador.SetActive(true);
                unidadesResto.SetActive(true);
                BotonesDeEdicion.SetActive(false);

                buttonLog.GetComponent<Button>().interactable = false;
                buttoncheck.GetComponent<Button>().interactable = false;
            }
            else
            {
                if (log3.activeSelf)
                {
                    log3.SetActive(false);
                }


                id = 3;
                calculador.SetActive(true);
                unidadesMant.SetActive(true);
                BotonesDeEdicion.SetActive(false);

                buttonLog.GetComponent<Button>().interactable = false;
                buttoncheck.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void closeCalc()
    {
        valorEntero = valorNumerador = valorDenominador = 0;
        textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();
        calculador.SetActive(false);
        BotonesDeEdicion.SetActive(true);
        unidadesResto.SetActive(false);

        buttonLog.GetComponent<Button>().interactable = true;
        buttoncheck.GetComponent<Button>().interactable = true;
    }
    public void actualizarIngrediente()
    {
        if (id == 2)
        {

            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0))
            {
                currentLine = 27;
            }
            else
            {
                if (valorNumerador == 0 && valorDenominador == 0 && valorEntero == 0)
                {
                    fraccionLimonada.SetActive(false);
                    yLimonada.SetActive(false);
                    enteraLimonada.SetActive(false);
                }
                else
                {
                    if (valorEntero == 0)
                    {
                        enteraLimonada.SetActive(false);
                        yLimonada.SetActive(false);
                        fraccionLimonada.SetActive(true);
                    }
                    else
                    {
                        if (valorNumerador == 0 && valorDenominador == 0)
                        {
                            fraccionLimonada.SetActive(false);
                            yLimonada.SetActive(false);
                            enteraLimonada.SetActive(true);
                        }
                        else
                        {
                            fraccionLimonada.SetActive(true);
                            yLimonada.SetActive(true);
                            enteraLimonada.SetActive(true);
                        }
                    }
                }

                mLimonadaValorEntero.text = valorEntero.ToString();
                mLimonadaValorNumerador.text = valorNumerador.ToString();
                mLimonadaValorDenominador.text = valorDenominador.ToString();
                unidadesResto.SetActive(false);
                calculador.SetActive(false);
                BotonesDeEdicion.SetActive(true);
                valorEntero = valorNumerador = valorDenominador = 0;
                textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

                buttonLog.GetComponent<Button>().interactable = true;
                buttoncheck.GetComponent<Button>().interactable = true;
            }

        }

        if (id == 1)
        {
            mGotasCentenas.text = valorEntero.ToString();
            mGotasDecenas.text = valorNumerador.ToString();
            mGotasUnidades.text = valorDenominador.ToString();
            unidadesMant.SetActive(false);
            calculador.SetActive(false);
            BotonesDeEdicion.SetActive(true);
            valorEntero = valorNumerador = valorDenominador = 0;
            textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

            buttonLog.GetComponent<Button>().interactable = true;
            buttoncheck.GetComponent<Button>().interactable = true;
        }

        if (id == 3)
        {
            mPrecioCentenas.text = valorEntero.ToString();
            mPrecioDecenas.text = valorNumerador.ToString();
            mPrecioUnidades.text = valorDenominador.ToString();
            unidadesMant.SetActive(false);
            calculador.SetActive(false);
            BotonesDeEdicion.SetActive(true);
            valorEntero = valorNumerador = valorDenominador = 0;
            textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

            buttonLog.GetComponent<Button>().interactable = true;
            buttoncheck.GetComponent<Button>().interactable = true;
        }
    }

    public void botonCheck()
    {
        //if (lecheFD == 4 && lecheFN == 3 && lecheEnteraV == 2) currentLine = 13;
        int gotasCentenasValor, gotasDecenasValor, gotasUnidadesValor;
        int limonadaEnteraValor, limonadaNumeradorValor, limonadaDenominadorValor;
        int precioCentenasValor, precioDecenasValor, precioUnidadesValor;

        int.TryParse(mGotasCentenas.text.ToString(), out gotasCentenasValor);
        int.TryParse(mGotasDecenas.text.ToString(), out gotasDecenasValor);
        int.TryParse(mGotasUnidades.text.ToString(), out gotasUnidadesValor);

        int.TryParse(mLimonadaValorEntero.text.ToString(), out limonadaEnteraValor);
        int.TryParse(mLimonadaValorNumerador.text.ToString(), out limonadaNumeradorValor);
        int.TryParse(mLimonadaValorDenominador.text.ToString(), out limonadaDenominadorValor);

        int.TryParse(mPrecioCentenas.text.ToString(), out precioCentenasValor);
        int.TryParse(mPrecioDecenas.text.ToString(), out precioDecenasValor);
        int.TryParse(mPrecioUnidades.text.ToString(), out precioUnidadesValor);

        int checks = 0;

        if (problema == 1)
        {
            if (!(gotasCentenasValor * 100 + gotasDecenasValor * 10 + gotasUnidadesValor == 13))
            {
                mGotasErrorMarco.SetActive(true);
            }
            else
            {
                mGotasErrorMarco.SetActive(false);
                checks += 1;
            }
        }

        if (problema == 2)
        {
            if (!(limonadaEnteraValor == 5 && limonadaNumeradorValor == 1 && limonadaDenominadorValor == 3))
            {
                mLimonadaErrorMarco.SetActive(true);
            }
            else
            {
                mLimonadaErrorMarco.SetActive(false);
                checks += 1;
            }
        }

        if (problema == 3)
        {
            if (!(precioCentenasValor * 100 + precioDecenasValor * 10 + precioUnidadesValor == 196))
            {
                mPrecioVueloErrorMarco.SetActive(true);
            }
            else
            {
                mPrecioVueloErrorMarco.SetActive(false);
                checks += 1;
            }
        }

        if (problema == 1)
        {
            if (checks == 1)
            {
                currentLine = 7;
                buttoncheck.SetActive(false);
                fondo1.SetActive(false);
                fondo2.SetActive(true);
                buttonLog.SetActive(false);

                mGotas.SetActive(false);
                objetivoTextoGotas.SetActive(false);

                problema = 2;

                papelGotas.SetActive(false);
                objetivoTextoGotas.SetActive(false);
                BotonesDeEdicion.SetActive(false);
                return;
            }
            else
            {
                currentLine = 25;
                intentos += 1;
                return;
            }
        }

        if(problema == 2)
        {
            if (checks == 1)
            {
                currentLine = 12;
                buttoncheck.SetActive(false);
                buttonLog.SetActive(false);
                fondo2.SetActive(false);
                fondo3.SetActive(true);

                mLimonadaGrande.SetActive(false);
                problema = 3;

                papelLimonada.SetActive(false);
                objetivoTextoLimonada.SetActive(false);
                BotonesDeEdicion.SetActive(false);
                return;
            }
            else
            {
                currentLine = 25;
                intentos += 1;
                return;
            }
        }

        if (problema == 3)
        {
            if (checks == 1)
            {
                currentLine = 19;
                buttoncheck.SetActive(false);
                buttonLog.SetActive(false);
                buttonContinue.SetActive(true);

                mPrecioVuelo.SetActive(false);

                float totalTime = Time.time - time;
                Debug.Log("Tiempo: " + totalTime);
                tiempoValor.text = totalTime.ToString("0.##");
                intentosValor.text = intentos.ToString();
                pantallaVictoria.SetActive(true);
                papelPrecio.SetActive(false);
                objetivoTextoPrecio.SetActive(false);
                BotonesDeEdicion.SetActive(false);

                PlayerPrefs.SetInt("failsLevel7", intentos);
                PlayerPrefs.SetFloat("timeLevel7", totalTime);

                if (intentos == 0)
                {
                    mStar1.SetActive(true);
                    mStar2.SetActive(true);
                    mStar3.SetActive(true);
                    PlayerPrefs.SetInt("estrellasLevel7", 3);
                    return;
                }

                if (intentos == 1)
                {
                    mStar1.SetActive(true);
                    mStar2.SetActive(true);
                    PlayerPrefs.SetInt("estrellasLevel7", 2);
                    return;
                }

                if (intentos == 2)
                {
                    mStar1.SetActive(true);
                    PlayerPrefs.SetInt("estrellasLevel7", 1);
                    return;
                }
                PlayerPrefs.SetInt("estrellasLevel7", 0);
            }
            else
            {
                currentLine = 14;
                intentos += 1;
                return;
            }
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

    public void Menu()
    {
        //Va al menu principal.
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Muestra el log.
    /// </summary>
    public void showLog()
    {
        if(problema == 1)
        {
            if (log.activeSelf)
            {
                log.SetActive(false);
            }
            else
            {
                log.SetActive(true);
            }
        }

        if (problema == 2)
        {
            if (log2.activeSelf)
            {
                log2.SetActive(false);
            }
            else
            {
                log2.SetActive(true);
            }
        }

        if (problema == 3)
        {
            if (log3.activeSelf)
            {
                log3.SetActive(false);
            }
            else
            {
                log3.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Continua a la siguiente fase.
    /// </summary>
    public void Continuar()
    {
        SceneManager.LoadScene(PANTALLA_FINAL);
    }
}
