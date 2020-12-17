using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Character : MonoBehaviour
{
    private GameObject stack;

    private Rigidbody Rigidbody;
    public Rigidbody rigidbody
    {
        get{
            if(Rigidbody==null)
            {
                Rigidbody=GetComponent<Rigidbody>();

            }
            return Rigidbody;
            
        }
    }
    private void OnEnable() 
    {
    
    }

    // Update is called once per frame
    private void OnDisable() 
    {
        
    }

    private void Start() 
    {
        stack =GameObject.FindWithTag("Stack");
        
        
    }
    private void Update() 
    {
        
        AdjustCharaterPos();
    }

    private void FinishSection()
    {

    }

    public void AdjustCharaterPos()
    {
        transform.position=new Vector3(stack.transform.position.x,stack.transform.position.y+stack.transform.localScale.y*(stack.GetComponent<StackController>().count+1),stack.transform.position.z);
    }


}
