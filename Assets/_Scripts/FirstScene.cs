using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(LoadMenu());
	}

    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }
}
