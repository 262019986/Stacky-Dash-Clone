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
    void Update()
    {
        if(matched)
        {
            transform.position=new Vector3(GameObject.FindWithTag("Player").transform.position.x , yDistance , GameObject.FindWithTag("Player").transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Player")
        {
            matched=true;
            
            yDistance = ( other.GetComponent<StackController>().count - 1 ) * transform.localScale.y;

        }

    }
}
