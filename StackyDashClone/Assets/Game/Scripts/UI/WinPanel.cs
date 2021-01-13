using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    // Start is called before the first frame update


     private void OnEnable() 
    {
            EventManager.OnLevelEnd.AddListener(()=> StartCoroutine(ShowWinPanel()) );
    }

    private void OnDisable() 
    {
             EventManager.OnLevelEnd.RemoveListener(()=> StartCoroutine(ShowWinPanel()) );
    }   


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

     IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(3F);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    

    
}
