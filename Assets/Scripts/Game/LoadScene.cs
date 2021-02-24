using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //=========================================================//
    // Mouse click handler
    public void OnClickLoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}
