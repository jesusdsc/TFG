using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class TextBoxManagerLvl3 : MonoBehaviour
{

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    //public GameObject IngredientsPanel;
    public GameObject ingredientes, mantequilla, huevos, harina, polvo, azucar, leche, naranja, vainilla, buttonYes, buttonNo, textObjectiveO, recipeSix, textObjectiveT;
    public Text lecheEntera, lecheNumerador, lecheDenominador, mantEnt, mantNum, mantDen, azucarEnt, azucarNum, azucarDen, polvoEnt, polvoNum, polvoDen;
    public GameObject calculador;
    private int id;
    public Text textoValorEntero, textoValorNumerador, textoValorDenominador;
    public GameObject BotonesDeEdicion;
    public GameObject unidadesResto;
    public GameObject fAz, fPo, fLe, yAz, yPo, yLe, eAz, ePo, eLe, fraccionMant, yMant, enteroMant;
    public GameObject buttonLog, buttonHint, buttoncheck, buttonContinue, log, hint;
    public GameObject movil, botonMensaje, textoMensaje;
    public GameObject recipeTwelve;
    public int currentLine;
    public int endLine;
    int valorEntero, valorNumerador, valorDenominador;

    public GameObject pauseMarco, buttonPause;
    public Text tiempoValor, intentosValor;
    public GameObject pantallaVictoria;

    private bool paused = false;
    private bool muted = false;
    private int intentos = 0;
    private float time;

    public GameObject mMantErrorMarco;
    public GameObject mLecheErrorMarco;
    public GameObject mAzucarErrorMarco;
    public GameObject mPolvoErrorMarco;

    public GameObject mStar1;
    public GameObject mStar2;
    public GameObject mStar3;
    public Animator mYure, mYera;

    public Text numeroEstrellas;

    // Use this for initialization
    void Start()
    {
        // IngredientsPanel.SetActive(false);
        //EventSystem.current.SetSelectedGameObject(textBox);
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }
        PlayerPrefs.SetString("savedLevel", SceneManager.GetActiveScene().name);
        valorEntero = 0;
        valorNumerador = 0;
        valorDenominador = 0;

        mYera.SetBool("hablando", false);
        mYure.SetBool("hablando", false);
        id = 0;
        if (endLine == 0) endLine = textLines.Length - 1;
        int estrellas = PlayerPrefs.GetInt("estrellasLevel2");

        numeroEstrellas.text = estrellas.ToString();
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
        if(currentLine == 2)
        {
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);
            movil.SetActive(true);
        }

        if (currentLine == 4)
        {

            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);
            movil.SetActive(false);
            recipeTwelve.SetActive(true);
        }
        theText.text = textLines[currentLine];
        if(currentLine == 8)
        {
            huevos.SetActive(true);
            harina.SetActive(true);
            naranja.SetActive(true);
            vainilla.SetActive(true);
        }
        if (currentLine == 15)
        {
            time = Time.time;
            Debug.Log("Tiempo: " + time);

            ingredientes.SetActive(true);
            
            mantequilla.SetActive(true);
            polvo.SetActive(true);
            leche.SetActive(true);
            
            azucar.SetActive(true);

            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);

            recipeSix.SetActive(true);
            textObjectiveT.SetActive(true);
            BotonesDeEdicion.SetActive(true);
            buttonHint.SetActive(true);
            buttonLog.SetActive(true);
            buttoncheck.SetActive(true);
            currentLine += 1;
        }

        if (textLines[currentLine].Substring(0, 4).Equals("Yera") && (currentLine != 2) && currentLine != 16 && currentLine != 20 && currentLine != 27
            && currentLine != 29 && currentLine != 24)
        {
            mYera.SetBool("hablando", true);
            mYure.SetBool("hablando", false);
        }

        if (textLines[currentLine].Substring(0, 4).Equals("Yure") && (currentLine != 2) && currentLine != 16 && currentLine != 20 && currentLine != 27
            && currentLine != 29 && currentLine != 24)
        {
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", true);
        }

        if (!paused && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && (currentLine != 2) && currentLine != 16 && currentLine != 20 && currentLine != 27 
            && currentLine != 29) currentLine += 1;

    }

    public void botonSi()
    {

        currentLine = 26;
    }

    public void leerMensaje()
    {
        botonMensaje.SetActive(false);
        textoMensaje.SetActive(true);
        currentLine = 3;
    }
    public void botonNo()
    {
        textObjectiveO.SetActive(false);
        buttonYes.SetActive(false);
        buttonNo.SetActive(false);
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
        id = 1;
        calculador.SetActive(true);
        unidadesResto.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;
    }

    public void botonEditarPolvo()
    {
        id = 2;
        calculador.SetActive(true);
        unidadesResto.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;
    }

    public void botonEditarAzucar()
    {
        id = 3;
        calculador.SetActive(true);
        unidadesResto.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;
    }

    public void botonEditarMant()
    {
        Debug.Log("DENTRO DE MANT");
        id = 4;
        calculador.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        unidadesResto.SetActive(true);
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;
    }

    public void closeCalc()
    {
        valorEntero = valorNumerador = valorDenominador = 0;
        textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();
        calculador.SetActive(false);
        BotonesDeEdicion.SetActive(true);
        unidadesResto.SetActive(false);

        buttonHint.GetComponent<Button>().interactable = true;
        buttonLog.GetComponent<Button>().interactable = true;
        buttoncheck.GetComponent<Button>().interactable = true;
    }
    public void actualizarIngrediente()
    {
        if (id == 1)
        {

            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                && valorNumerador > valorDenominador)
            {
                currentLine = 24;
            }
            else
            {
                if (valorNumerador == 0 && valorDenominador == 0 && valorEntero == 0)
                {
                    fLe.SetActive(false);
                    yLe.SetActive(false);
                    eLe.SetActive(false);
                }
                else
                {
                    if (valorEntero == 0)
                    {
                        eLe.SetActive(false);
                        yLe.SetActive(false);
                        fLe.SetActive(true);
                    }
                    else
                    {
                        if (valorNumerador == 0 && valorDenominador == 0)
                        {
                            fLe.SetActive(false);
                            yLe.SetActive(false);
                            eLe.SetActive(true);
                        }
                        else
                        {
                            fLe.SetActive(true);
                            yLe.SetActive(true);
                            eLe.SetActive(true);
                        }
                    }
                }

                lecheEntera.text = valorEntero.ToString();
                lecheNumerador.text = valorNumerador.ToString();
                lecheDenominador.text = valorDenominador.ToString();
                unidadesResto.SetActive(false);
                calculador.SetActive(false);
                BotonesDeEdicion.SetActive(true);
                valorEntero = valorNumerador = valorDenominador = 0;
                textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

                buttonHint.GetComponent<Button>().interactable = true;
                buttonLog.GetComponent<Button>().interactable = true;
                buttoncheck.GetComponent<Button>().interactable = true;
            }

        }

        if (id == 2)
        {
            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                && valorNumerador > valorDenominador)
            {
                currentLine = 24;
            }
            else
            {
                if (valorNumerador == 0 && valorDenominador == 0 && valorEntero == 0)
                {
                    fPo.SetActive(false);
                    yPo.SetActive(false);
                    ePo.SetActive(false);
                }
                else
                {
                    if (valorEntero == 0)
                    {
                        ePo.SetActive(false);
                        yPo.SetActive(false);
                        fPo.SetActive(true);
                    }
                    else
                    {
                        if (valorNumerador == 0 && valorDenominador == 0)
                        {
                            fPo.SetActive(false);
                            yPo.SetActive(false);
                            ePo.SetActive(true);
                        }
                        else
                        {
                            fPo.SetActive(true);
                            yPo.SetActive(true);
                            ePo.SetActive(true);
                        }
                    }
                }
                polvoEnt.text = valorEntero.ToString();
                polvoNum.text = valorNumerador.ToString();
                polvoDen.text = valorDenominador.ToString();
                unidadesResto.SetActive(false);
                calculador.SetActive(false);
                BotonesDeEdicion.SetActive(true);
                valorEntero = valorNumerador = valorDenominador = 0;
                textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

                buttonHint.GetComponent<Button>().interactable = true;
                buttonLog.GetComponent<Button>().interactable = true;
                buttoncheck.GetComponent<Button>().interactable = true;
            }

        }

        if (id == 3)
        {
            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                && valorNumerador > valorDenominador)
            {
                currentLine = 24;
            }
            else
            {
                if (valorNumerador == 0 && valorDenominador == 0 && valorEntero == 0)
                {
                    fAz.SetActive(false);
                    yAz.SetActive(false);
                    eAz.SetActive(false);
                }
                else
                {
                    if (valorEntero == 0)
                    {
                        eAz.SetActive(false);
                        yAz.SetActive(false);
                        fAz.SetActive(true);
                    }
                    else
                    {
                        if (valorNumerador == 0 && valorDenominador == 0)
                        {
                            fAz.SetActive(false);
                            yAz.SetActive(false);
                            eAz.SetActive(true);
                        }
                        else
                        {
                            fAz.SetActive(true);
                            yAz.SetActive(true);
                            eAz.SetActive(true);
                        }
                    }
                }
                azucarEnt.text = valorEntero.ToString();
                azucarNum.text = valorNumerador.ToString();
                azucarDen.text = valorDenominador.ToString();
                unidadesResto.SetActive(false);
                calculador.SetActive(false);
                BotonesDeEdicion.SetActive(true);
                valorEntero = valorNumerador = valorDenominador = 0;
                textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

                buttonHint.GetComponent<Button>().interactable = true;
                buttonLog.GetComponent<Button>().interactable = true;
                buttoncheck.GetComponent<Button>().interactable = true;
            }

        }

        if (id == 4)
        {
            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                && valorNumerador > valorDenominador)
            {
                currentLine = 24;
            }
            else
            {
                if (valorNumerador == 0 && valorDenominador == 0 && valorEntero == 0)
                {
                    fraccionMant.SetActive(false);
                    yMant.SetActive(false);
                    enteroMant.SetActive(false);
                }
                else
                {
                    if (valorEntero == 0)
                    {
                        enteroMant.SetActive(false);
                        yMant.SetActive(false);
                        fraccionMant.SetActive(true);
                    }
                    else
                    {
                        if (valorNumerador == 0 && valorDenominador == 0)
                        {
                            fraccionMant.SetActive(false);
                            yMant.SetActive(false);
                            enteroMant.SetActive(true);
                        }
                        else
                        {
                            fraccionMant.SetActive(true);
                            yMant.SetActive(true);
                            enteroMant.SetActive(true);
                        }
                    }
                }
            }

            mantEnt.text = valorEntero.ToString();
            mantNum.text = valorNumerador.ToString();
            mantDen.text = valorDenominador.ToString();
            unidadesResto.SetActive(false);
            calculador.SetActive(false);
            BotonesDeEdicion.SetActive(true);
            valorEntero = valorNumerador = valorDenominador = 0;
            textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

            buttonHint.GetComponent<Button>().interactable = true;
            buttonLog.GetComponent<Button>().interactable = true;
            buttoncheck.GetComponent<Button>().interactable = true;
        }
    }

    public void botonCheck()
    {
        //if (lecheFD == 4 && lecheFN == 3 && lecheEnteraV == 2) currentLine = 13;
        int mantEntV, mantNumV, mantDenV, lecheEntV, lecheNumV, lecheDenV, polvoEntV, polvoNumV, polvoDenV, azucarEntV, azucarNumV, azucarDenV;

        int.TryParse(mantEnt.text.ToString(), out mantEntV);
        int.TryParse(mantNum.text.ToString(), out mantNumV);
        int.TryParse(mantDen.text.ToString(), out mantDenV);

        int.TryParse(polvoEnt.text.ToString(), out polvoEntV);
        int.TryParse(polvoNum.text.ToString(), out polvoNumV);
        int.TryParse(polvoDen.text.ToString(), out polvoDenV);

        int.TryParse(lecheEntera.text.ToString(), out lecheEntV);
        int.TryParse(lecheNumerador.text.ToString(), out lecheNumV);
        int.TryParse(lecheDenominador.text.ToString(), out lecheDenV);

        int.TryParse(azucarEnt.text.ToString(), out azucarEntV);
        int.TryParse(azucarNum.text.ToString(), out azucarNumV);
        int.TryParse(azucarDen.text.ToString(), out azucarDenV);

        int checks = 0;

        if (!(mantEntV == 2 && mantNumV == 1 && mantDenV == 4))
        {
            mMantErrorMarco.SetActive(true);
        }
        else
        {
            mMantErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(polvoEntV == 2 && polvoNumV == 0 && polvoDenV == 0))
        {
            mPolvoErrorMarco.SetActive(true);
        }
        else
        {
            mPolvoErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(lecheEntV == 2 && lecheNumV == 0 && lecheDenV == 0))
        {
            mLecheErrorMarco.SetActive(true);
        }
        else
        {
            mLecheErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(azucarEntV == 2 && azucarNumV == 0 && azucarDenV == 0))
        {
            mAzucarErrorMarco.SetActive(true);
        }
        else
        {
            mAzucarErrorMarco.SetActive(false);
            checks += 1;
        }

        if (checks == 4)
        {
            float totalTime = Time.time - time;
            Debug.Log("Tiempo: " + totalTime);
            tiempoValor.text = totalTime.ToString("0.##");
            intentosValor.text = intentos.ToString();
            pantallaVictoria.SetActive(true);

            currentLine = 20;
            buttoncheck.SetActive(false);
            buttonHint.SetActive(false);
            buttonLog.SetActive(false);
            textObjectiveO.SetActive(true);
            buttonYes.SetActive(true);
            buttonNo.SetActive(true);

            ingredientes.SetActive(false);

            mantequilla.SetActive(false);
            polvo.SetActive(false);
            leche.SetActive(false);

            azucar.SetActive(false);

            recipeSix.SetActive(false);
            textObjectiveT.SetActive(false);
            BotonesDeEdicion.SetActive(false);
            recipeTwelve.SetActive(false);
            huevos.SetActive(false);
            harina.SetActive(false);
            naranja.SetActive(false);
            vainilla.SetActive(false);

            PlayerPrefs.SetInt("failsLevel3", intentos);
            PlayerPrefs.SetFloat("timeLevel3", totalTime);

            if (intentos == 0)
            {
                mStar1.SetActive(true);
                mStar2.SetActive(true);
                mStar3.SetActive(true);
                PlayerPrefs.SetInt("estrellasLevel3", 3);
                return;
            }

            if (intentos == 1)
            {
                mStar1.SetActive(true);
                mStar2.SetActive(true);
                PlayerPrefs.SetInt("estrellasLevel3", 2);
                return;
            }

            if (intentos == 2)
            {
                mStar1.SetActive(true);
                PlayerPrefs.SetInt("estrellasLevel3", 1);
                return;
            }
            PlayerPrefs.SetInt("estrellasLevel2", 0);
        }
        else
        {
            currentLine = 29;
            intentos += 1;
        }



    }

    public void showLog()
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

    public void showHint()
    {
        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }
        else
        {
            hint.SetActive(true);
        }
    }

    public void Continuar()
    {
        SceneManager.LoadScene("lvl4");
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
