using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : MonoBehaviour
{
      //Init Game Here
         void Start()
    {
        //Init Game Here
        //SceneManager.LoadScene("Ui", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level", LoadSceneMode.Additive);
        Destroy(gameObject);
    }
        
}

