using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{

    public bool isMovingForward; 
    public bool isMovingBack;
    public bool isMovingRight;
    public bool isMovingLeft;
    public float speed; 
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        
        if( (Input.GetKey(KeyCode.W)))
        {
            isMovingForward=true;

        }
        else if( (Input.GetKey(KeyCode.S)))
        {
            isMovingBack=true;
        }
        else if( (Input.GetKey(KeyCode.A)))
        {
            isMovingLeft=true;
        }
        else if( (Input.GetKey(KeyCode.D)))
        {
            isMovingRight=true;
        }


        if(isMovingForward)
        {
            rigidbody.AddForce(Vector3.forward*speed);
        }
        else if(isMovingBack)
        {
            rigidbody.AddForce(Vector3.back*speed);
        }
        else if (isMovingRight)
        {
            rigidbody.AddForce(Vector3.right*speed);
        }
        else if(isMovingLeft)
        {
            rigidbody.AddForce(Vector3.left*speed);
        }

        
    }

    
    private void OnCollisionEnter(Collision other) {
        
        var count=transform.childCount+1;
        if(other.gameObject.tag=="CollectibleStack")
        {
            
            other.transform.position=new Vector3(transform.position.x,transform.position.y+transform.localScale.y*count,transform.position.z);
            other.transform.parent=transform;
          //  other.gameObject.AddComponent<StackController>();/
        }

        if(other.gameObject.tag=="Obstacle")
        {
            rigidbody.velocity=Vector3.zero;
            isMovingForward=false;
            isMovingBack=false;
            isMovingLeft=false;
            isMovingRight=false;
        }
    }
}
