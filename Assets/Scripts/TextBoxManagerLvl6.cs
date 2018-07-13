using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextBoxManagerLvl6 : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    //public GameObject IngredientsPanel;
    public GameObject ingredientes, mantequilla, huevos, harina, polvo, azucar, leche, naranja, vainilla, buttonYes, buttonNo, textObjectiveO, recipeSix, textObjectiveT;
    public Text lecheEntera, lecheNumerador, lecheDenominador, mantCent, mantDec, mantUni, azucarEnt, azucarNum, azucarDen, polvoEnt, polvoNum, polvoDen, harinaEnt, harinaNum, harinaDen, huevosEnt, huevosNum, huevosDen;
    public Text mantEnt, mantNum, mantDen;
    public Text lecheCent, lecheDec, lecheUni;
    public Text harinaCent, harinaDec, harinaUni;
    public Text azucarCent, azucarDec, azucarUni;
    public GameObject calculador;
    private int id;
    public Text textoValorEntero, textoValorNumerador, textoValorDenominador;
    public GameObject BotonesDeEdicion;
    public GameObject unidadesMant, unidadesResto;
    public GameObject fAz, fPo, fLe, yAz, yPo, yLe, eAz, ePo, eLe, fraccionHarina, yHarina, enteraHarina, fraccionHuevos, yHuevos, enteraHuevos, fraccionMant, yMant, enteroMant;
    public GameObject buttonLog, buttonHint, buttoncheck, buttonContinue, log, hint;
    public GameObject movil, botonMensaje, textoMensaje;
    public GameObject recipeTwelve;
    public GameObject pauseMarco, buttonPause;
    public int currentLine;
    public int endLine;
    int valorEntero, valorNumerador, valorDenominador;

    public Text tiempoValor, intentosValor;
    public GameObject pantallaVictoria, trofeos;

    public GameObject valorMantequilla, valorHarina, valorAzucar, valorLeche;

    public GameObject mMantErrorMarco;
    public GameObject mLecheErrorMarco;
    public GameObject mAzucarErrorMarco;
    public GameObject mPolvoErrorMarco;
    public GameObject mHuevoErrorMarco;
    public GameObject mHarinaErrorMarco;

    public GameObject unidadesAComprar;

    public GameObject Conversion;

    public GameObject mStar1;
    public GameObject mStar2;
    public GameObject mStar3;

    public GameObject hintAzucar;

    private bool paused = false;
    private bool muted = false;
    private int intentos = 0;
    private float time;

    private int problema = 1;

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
        id = 0;
        mYera.SetBool("hablando", false);
        mYure.SetBool("hablando", false);
        if (endLine == 0) endLine = textLines.Length - 1;

        numeroEstrellas.text = (PlayerPrefs.GetInt("estrellasLevel2") + PlayerPrefs.GetInt("estrellasLevel3") + PlayerPrefs.GetInt("estrellasLevel4") + PlayerPrefs.GetInt("estrellasLevel5")).ToString();
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

        theText.text = textLines[currentLine];


        if (currentLine == 1) hint.SetActive(true);

        if (currentLine == 2) hint.SetActive(false);

        if (currentLine == 2) hintAzucar.SetActive(true);

        if (currentLine == 5) hintAzucar.SetActive(false);

        if (currentLine == 6) recipeTwelve.SetActive(true);

        if (currentLine == 7)
        {
            ingredientes.SetActive(true);
            harina.SetActive(true);
            mantequilla.SetActive(true);
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", false);
            leche.SetActive(true);
            huevos.SetActive(true);

            azucar.SetActive(true);
            time = Time.time;
            Debug.Log("Tiempo: " + time);
            recipeSix.SetActive(true);
            textObjectiveT.SetActive(true);
            BotonesDeEdicion.SetActive(true);
            buttonHint.SetActive(true);
            buttonLog.SetActive(true);
            buttoncheck.SetActive(true);
        }

        if (textLines[currentLine].Substring(0, 4).Equals("Yera") && currentLine != 7 &&
            currentLine != 10 && currentLine != 12 && currentLine != 14)
        {
            mYera.SetBool("hablando", true);
            mYure.SetBool("hablando", false);
        }

        if (textLines[currentLine].Substring(0, 4).Equals("Yure") && currentLine != 7 &&
            currentLine != 12 && currentLine != 14 && currentLine != 14)
        {
            mYera.SetBool("hablando", false);
            mYure.SetBool("hablando", true);
        }

        if (!paused && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && currentLine != 7 && currentLine != 9 &&
            currentLine != 11 && currentLine != 13 && currentLine != 15) currentLine += 1;
     
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
        if (problema == 1)
        {
            unidadesResto.SetActive(true);
        }
        else
        {
            unidadesMant.SetActive(true);
        }
        id = 1;
        calculador.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }

        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;
    }

    public void botonEditarPolvo()
    {
        if (problema == 1)
        {
            unidadesResto.SetActive(true);
        }
        else
        {
            unidadesMant.SetActive(true);
        }
        id = 2;
        calculador.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }
        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;
    }

    public void botonEditarAzucar()
    {
        if (problema == 1)
        {
            unidadesResto.SetActive(true);
        }
        else
        {
            unidadesMant.SetActive(true);
        }
        id = 3;
        calculador.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }
        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;
    }

    public void botonEditarMant()
    {
        if (problema == 1)
        {
            unidadesResto.SetActive(true);
        }
        else
        {
            unidadesMant.SetActive(true);
        }
        Debug.Log("DENTRO DE MANT");
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }
        id = 4;
        calculador.SetActive(true);
        BotonesDeEdicion.SetActive(false);

        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;

    }

    public void botonEditarHarina()
    {
        if (problema == 1)
        {
            unidadesResto.SetActive(true);
        }
        else
        {
            unidadesMant.SetActive(true);
        }
        id = 5;
        calculador.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        if (log.activeSelf)
        {
            log.SetActive(false);
        }

        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }

        buttonHint.GetComponent<Button>().interactable = false;
        buttonLog.GetComponent<Button>().interactable = false;
        buttoncheck.GetComponent<Button>().interactable = false;
    }

    public void botonEditarHuevos()
    {
        id = 6;
        calculador.SetActive(true);
        unidadesResto.SetActive(true);
        BotonesDeEdicion.SetActive(false);
        if (hint.activeSelf)
        {
            hint.SetActive(false);
        }

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
        if (id == 1 && problema == 1)
        {

            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                 )
            {
                currentLine = 15;
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
        else
        {
            if(id == 1)
            {
                lecheCent.text = valorEntero.ToString();
                lecheDec.text = valorNumerador.ToString();
                lecheUni.text = valorDenominador.ToString();
                unidadesMant.SetActive(false);
                calculador.SetActive(false);
                BotonesDeEdicion.SetActive(true);
                valorEntero = valorNumerador = valorDenominador = 0;
                textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

                buttonHint.GetComponent<Button>().interactable = true;
                buttonLog.GetComponent<Button>().interactable = true;
                buttoncheck.GetComponent<Button>().interactable = true;
            }
        }

        if (id == 2 && problema == 1)
        {
            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                 )
            {
                currentLine = 15;
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

        if (id == 3 && problema == 1)
        {
            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                 )
            {
                currentLine = 15;
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
        else
        {
            if (id == 3)
            {
                azucarCent.text = valorEntero.ToString();
                azucarDec.text = valorNumerador.ToString();
                azucarUni.text = valorDenominador.ToString();
                unidadesMant.SetActive(false);
                calculador.SetActive(false);
                BotonesDeEdicion.SetActive(true);
                valorEntero = valorNumerador = valorDenominador = 0;
                textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

                buttonHint.GetComponent<Button>().interactable = true;
                buttonLog.GetComponent<Button>().interactable = true;
                buttoncheck.GetComponent<Button>().interactable = true;
            }
        }

        if (id == 4 && problema == 1)
        {
            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                && valorNumerador > valorDenominador)
            {
                currentLine = 15;
            }
            else
            {
                if (valorNumerador == 0 && valorDenominador == 0 && valorEntero == 0)
                {
                    fraccionMant.SetActive(false);
                    yMant.SetActive(false);
                    enteroMant.SetActive(true);
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
            unidadesMant.SetActive(false);
            calculador.SetActive(false);
            BotonesDeEdicion.SetActive(true);
            valorEntero = valorNumerador = valorDenominador = 0;
            textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

            buttonHint.GetComponent<Button>().interactable = true;
            buttonLog.GetComponent<Button>().interactable = true;
            buttoncheck.GetComponent<Button>().interactable = true;

        }
        else
        {
            if(id == 4)
            {
                mantCent.text = valorEntero.ToString();
                mantDec.text = valorNumerador.ToString();
                mantUni.text = valorDenominador.ToString();
                unidadesMant.SetActive(false);
                unidadesMant.SetActive(false);
                calculador.SetActive(false);
                BotonesDeEdicion.SetActive(true);
                valorEntero = valorNumerador = valorDenominador = 0;
                textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

                buttonHint.GetComponent<Button>().interactable = true;
                buttonLog.GetComponent<Button>().interactable = true;
                buttoncheck.GetComponent<Button>().interactable = true;
            }
        }

        if (id == 5 && problema == 1)
        {

            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)
                 )
            {
                currentLine = 15;
            }
            else
            {
                if (valorNumerador == 0 && valorDenominador == 0 && valorEntero == 0)
                {
                    yHarina.SetActive(false);
                    enteraHarina.SetActive(false);
                    fraccionHarina.SetActive(false);
                }
                else
                {
                    if (valorEntero == 0)
                    {
                        enteraHarina.SetActive(false);
                        yHarina.SetActive(false);
                        fraccionHarina.SetActive(true);
                    }
                    else
                    {
                        if (valorNumerador == 0 && valorDenominador == 0)
                        {
                            fraccionHarina.SetActive(false);
                            yHarina.SetActive(false);
                            enteraHarina.SetActive(true);
                        }
                        else
                        {
                            fraccionHarina.SetActive(true);
                            yHarina.SetActive(true);
                            enteraHarina.SetActive(true);
                        }
                    }
                }
                harinaEnt.text = valorEntero.ToString();
                harinaNum.text = valorNumerador.ToString();
                harinaDen.text = valorDenominador.ToString();
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
        else
        {
            if (id == 5)
            {
                harinaCent.text = valorEntero.ToString();
                harinaDec.text = valorNumerador.ToString();
                harinaUni.text = valorDenominador.ToString();
                unidadesMant.SetActive(false);
                unidadesMant.SetActive(false);
                calculador.SetActive(false);
                BotonesDeEdicion.SetActive(true);
                valorEntero = valorNumerador = valorDenominador = 0;
                textoValorDenominador.text = textoValorEntero.text = textoValorNumerador.text = valorEntero.ToString();

                buttonHint.GetComponent<Button>().interactable = true;
                buttonLog.GetComponent<Button>().interactable = true;
                buttoncheck.GetComponent<Button>().interactable = true;
            }
        }

        if (id == 6)
        {

            if ((valorNumerador == 0 && valorDenominador != 0) || (valorDenominador == 0 && valorNumerador != 0)      )
            {
                currentLine = 15;
            }
            else
            {
                if (valorNumerador == 0 && valorDenominador == 0 && valorEntero == 0)
                {
                    yHuevos.SetActive(false);
                    enteraHuevos.SetActive(false);
                    fraccionHuevos.SetActive(false);
                }
                else
                {
                    if (valorEntero == 0 && problema == 1)
                    {
                        enteraHuevos.SetActive(false);
                        yHuevos.SetActive(false);
                        fraccionHuevos.SetActive(true);
                    }
                    else
                    {
                        if (valorNumerador == 0 && valorDenominador == 0)
                        {
                            fraccionHuevos.SetActive(false);
                            yHuevos.SetActive(false);
                            enteraHuevos.SetActive(true);
                        }
                        else
                        {
                            fraccionHuevos.SetActive(true);
                            yHuevos.SetActive(true);
                            enteraHuevos.SetActive(true);
                        }
                    }
                }

                huevosEnt.text = valorEntero.ToString();
                huevosNum.text = valorNumerador.ToString();
                huevosDen.text = valorDenominador.ToString();
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
    }

    public void BotonCheckGlobal()
    {
        if(problema == 1)
        {
            botonCheck();
        }
        else
        {
            botonCheckDos();
        }
    }

    private void botonCheck()
    {
        //if (lecheFD == 4 && lecheFN == 3 && lecheEnteraV == 2) currentLine = 13;
        int mantEntV, mantNumV, mantDenV, lecheEntV, lecheNumV, lecheDenV, polvoEntV, polvoNumV, polvoDenV, azucarEntV, azucarNumV, azucarDenV, harinaEntV, harinaNumV, harinaDenV, huevosEntV, huevosNumV, huevosDenV;

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

        int.TryParse(harinaEnt.text.ToString(), out harinaEntV);
        int.TryParse(harinaNum.text.ToString(), out harinaNumV);
        int.TryParse(harinaDen.text.ToString(), out harinaDenV);

        int.TryParse(huevosEnt.text.ToString(), out huevosEntV);
        int.TryParse(huevosNum.text.ToString(), out huevosNumV);
        int.TryParse(huevosDen.text.ToString(), out huevosDenV);

        int checks = 0;

        if (!(mantEntV == 0 && mantNumV == 0 && mantDenV == 0))
        {
            mMantErrorMarco.SetActive(true);
        }
        else
        {
            mMantErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(lecheEntV == 0 && lecheNumV == 1 && lecheDenV == 3))
        {
            mLecheErrorMarco.SetActive(true);
        }
        else
        {
            mLecheErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(azucarEntV == 0 && azucarNumV == 2 && azucarDenV == 3))
        {
            mAzucarErrorMarco.SetActive(true);
        }
        else
        {
            mAzucarErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(harinaEntV == 1 && harinaNumV == 0 && harinaDenV == 0))
        {
            mHarinaErrorMarco.SetActive(true);
        }
        else
        {
            mHarinaErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(huevosEntV == 0 && huevosNumV == 1 && huevosDenV == 3))
        {
            mHuevoErrorMarco.SetActive(true);
        }
        else
        {
            mHuevoErrorMarco.SetActive(false);
            checks += 1;
        }


        if (checks == 5)
        {
            currentLine = 9;
            recipeSix.SetActive(false);
            recipeTwelve.SetActive(false);
            unidadesAComprar.SetActive(true);

            huevosEnt.text = 0.ToString();
            huevosNum.text = 0.ToString();
            huevosDen.text = 0.ToString();
            yHuevos.SetActive(false);
            enteraHuevos.SetActive(false);
            fraccionHuevos.SetActive(false);

            yHarina.SetActive(false);
            enteraHarina.SetActive(false);
            fraccionHarina.SetActive(false);

            fraccionMant.SetActive(false);
            yMant.SetActive(false);
            enteroMant.SetActive(false);

            fAz.SetActive(false);
            yAz.SetActive(false);
            eAz.SetActive(false);

            fLe.SetActive(false);
            yLe.SetActive(false);
            eLe.SetActive(false);

            valorAzucar.SetActive(true);
            valorMantequilla.SetActive(true);
            valorLeche.SetActive(true);
            valorHarina.SetActive(true);

            Conversion.SetActive(true);
            hint.SetActive(true);
            problema = 2;
        }
        else
        {
            currentLine = 13;
            intentos += 1;
        }
    }

    private void botonCheckDos()
    {
        //if (lecheFD == 4 && lecheFN == 3 && lecheEnteraV == 2) currentLine = 13;
        int mantCentV, mantDecV, mantUnV, lecheEntV, lecheNumV, lecheDenV, polvoEntV, polvoNumV, polvoDenV, azucarEntV, azucarNumV, azucarDenV, harinaEntV, harinaNumV, harinaDenV, huevosEntV, huevosNumV, huevosDenV;

        int.TryParse(mantEnt.text.ToString(), out mantCentV);
        int.TryParse(mantNum.text.ToString(), out mantDecV);
        int.TryParse(mantDen.text.ToString(), out mantUnV);

        int.TryParse(polvoEnt.text.ToString(), out polvoEntV);
        int.TryParse(polvoNum.text.ToString(), out polvoNumV);
        int.TryParse(polvoDen.text.ToString(), out polvoDenV);

        int.TryParse(lecheCent.text.ToString(), out lecheEntV);
        int.TryParse(lecheDec.text.ToString(), out lecheNumV);
        int.TryParse(lecheUni.text.ToString(), out lecheDenV);

        int.TryParse(azucarCent.text.ToString(), out azucarEntV);
        int.TryParse(azucarDec.text.ToString(), out azucarNumV);
        int.TryParse(azucarUni.text.ToString(), out azucarDenV);

        int.TryParse(harinaCent.text.ToString(), out harinaEntV);
        int.TryParse(harinaDec.text.ToString(), out harinaNumV);
        int.TryParse(harinaUni.text.ToString(), out harinaDenV);

        int.TryParse(huevosEnt.text.ToString(), out huevosEntV);
        int.TryParse(huevosNum.text.ToString(), out huevosNumV);
        int.TryParse(huevosDen.text.ToString(), out huevosDenV);

        int checks = 0;

        if (!(mantCentV * 100 + mantDecV * 10 + mantUnV == 0))
        {
            mMantErrorMarco.SetActive(true);
        }
        else
        {
            mMantErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(lecheEntV * 100 + lecheNumV *10 + lecheDenV == 50))
        {
            mLecheErrorMarco.SetActive(true);
        }
        else
        {
            mLecheErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(azucarEntV *100 + azucarNumV * 10 + azucarDenV == 80))
        {
            mAzucarErrorMarco.SetActive(true);
        }
        else
        {
            mAzucarErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(harinaEntV * 100 + harinaNumV * 10 + harinaDenV == 100))
        {
            mHarinaErrorMarco.SetActive(true);
        }
        else
        {
            mHarinaErrorMarco.SetActive(false);
            checks += 1;
        }

        if (!(huevosEntV == 1 && huevosNumV == 0 && huevosDenV == 0))
        {
            mHuevoErrorMarco.SetActive(true);
        }
        else
        {
            mHuevoErrorMarco.SetActive(false);
            checks += 1;
        }


        if (checks == 5)
        {
            currentLine = 11;
            buttoncheck.SetActive(false);
            buttonHint.SetActive(false);
            buttonLog.SetActive(false);
            buttonContinue.SetActive(true);
            ingredientes.SetActive(false);

            mantequilla.SetActive(false);
            polvo.SetActive(false);
            leche.SetActive(false);
            huevos.SetActive(false);
            harina.SetActive(false);

            azucar.SetActive(false);


            float totalTime = Time.time - time;
            Debug.Log("Tiempo: " + totalTime);
            tiempoValor.text = totalTime.ToString("0.##");
            intentosValor.text = intentos.ToString();
            pantallaVictoria.SetActive(true);
            recipeSix.SetActive(false);
            textObjectiveT.SetActive(false);
            BotonesDeEdicion.SetActive(false);
            huevos.SetActive(false);
            harina.SetActive(false);
            naranja.SetActive(false);
            vainilla.SetActive(false);
            Conversion.SetActive(false);
            unidadesAComprar.SetActive(false);
            hint.SetActive(false);
            log.SetActive(false);

            PlayerPrefs.SetInt("failsLevel6", intentos);
            PlayerPrefs.SetFloat("timeLevel6", totalTime);

            if (intentos == 0)
            {
                mStar1.SetActive(true);
                mStar2.SetActive(true);
                mStar3.SetActive(true);
                PlayerPrefs.SetInt("estrellasLevel6", 3);
                return;
            }

            if (intentos == 1)
            {
                mStar1.SetActive(true);
                mStar2.SetActive(true);
                PlayerPrefs.SetInt("estrellasLevel6", 2);
                return;
            }

            if (intentos == 2)
            {
                mStar1.SetActive(true);
                PlayerPrefs.SetInt("estrellasLevel6", 1);
                return;
            }
            PlayerPrefs.SetInt("estrellasLevel6", 0);
        }
        else
        {
            currentLine = 13;
            intentos += 1;
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
        if (log.activeSelf)
        {
            log.SetActive(false);
        }
        else
        {
            log.SetActive(true);
        }
    }

    /// <summary>
    /// Muestra la pista del nivel actual.
    /// </summary>
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

    /// <summary>
    /// Continua a la siguiente fase.
    /// </summary>
    public void Continuar()
    {
        SceneManager.LoadScene("lvl7");
    }
}
