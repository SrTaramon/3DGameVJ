using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionLevelController : MonoBehaviour
{
    public void toLvl1(){
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void toLvl2(){
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
}
