using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectiblestack : MonoBehaviour
{
   private bool matched;

   float yDistance=0.1f;

   private void OnEnable() 
   {
        EventManager.OnPass.AddListener(()=> transform.SetParent(null));    
   }

   private void OnDisable() 
   {
       EventManager.OnPass.RemoveListener(()=> transform.SetParent(null)); 
   }
    void Start()
    {
        transform.SetParent(null);
        
    }

    // Update is called once per frame
   private void Update() 
   {
        RaycastHit hit;
       if( Physics.Raycast(transform.position , Vector3.forward , out hit, 1.1f ) && transform.CompareTag("Collected"))
       {
           if(hit.transform.tag == "Pass")
           { 
              
               StartCoroutine(SetPass());
               hit.transform.tag="CollectibleStacks";
           }
       }
   }

   IEnumerator SetPass()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Pass Detected");
        EventManager.OnPass.Invoke();
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x , 0 ,transform.position.z);
        GameManager.Instance.count=0;
        
    }
}
