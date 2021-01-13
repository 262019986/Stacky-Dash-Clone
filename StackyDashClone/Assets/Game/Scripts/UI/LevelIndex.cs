using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelIndex : MonoBehaviour
{
    public Text LevelText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateLevelText()
    {
        LevelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex +1);
    }
}
 