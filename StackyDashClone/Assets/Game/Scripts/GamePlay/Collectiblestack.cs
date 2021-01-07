using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectiblestack : MonoBehaviour
{
   private bool matched;

   float yDistance=0.1f;
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
               Debug.Log("Pass Detected");
               EventManager.OnPass.Invoke();
               gameObject.AddComponent<StackController>();
               gameObject.tag ="Player";
               Destroy(this);
               
           }
       }
   }
}
