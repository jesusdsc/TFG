using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void Continuar (){
		SceneManager.LoadScene("lvl2");
	}
}
