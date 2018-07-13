using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeleccionarFAse : MonoBehaviour {

    public void GoBackToMain()
    {
        SceneManager.LoadScene("PantallaInicioV2");
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void GoToLevel4()
    {
        SceneManager.LoadScene("lvl4");
    }

    public void GoToLevel5()
    {
        SceneManager.LoadScene("lvl5");
    }

    public void GoToLevel6()
    {
        SceneManager.LoadScene("lvl6");
    }

    public void GoToLevel7()
    {
        SceneManager.LoadScene("lvl7");
    }
}
