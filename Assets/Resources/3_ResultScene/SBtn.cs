using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SBtn : MonoBehaviour {

	public void Reset()
    {
        SceneManager.LoadScene(2);
    }
}
