using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{

    public ParticleSystem dustPs;
    public bool isMovingForward; 
    public bool isMovingBack;
    public bool isMovingRight;
    public bool isMovingLeft;
    public float speed; 
    private RigidbodyConstraints defaultConstraints;
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
    

    private void Awake() 
    {
        defaultConstraints=rigidbody.constraints;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartMovement();
    }

    public void StartMovement()
    {
        
        if( (Input.GetKey(KeyCode.W)))
        {
            rigidbody.constraints=defaultConstraints;
            
            isMovingForward=true;
            dustPs.Play();

        }
        else if( (Input.GetKey(KeyCode.S)))
        {
            rigidbody.constraints=defaultConstraints;
           
            isMovingBack=true;
            dustPs.Play();
        }
        else if( (Input.GetKey(KeyCode.A)))
        {
            rigidbody.constraints=defaultConstraints;
            
            isMovingLeft=true;
            dustPs.Play();
        }
        else if( (Input.GetKey(KeyCode.D)))
        {
            rigidbody.constraints=defaultConstraints;
           
            isMovingRight=true;
            dustPs.Play();
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

     private void StopMovement()
    {
        rigidbody.velocity=Vector3.zero;
        isMovingForward=false;
        isMovingBack=false;
        isMovingLeft=false;
        isMovingRight=false;
        dustPs.Stop();
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        
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
            /*if(transform.position.x>other.gameObject.transform.position.x+transform.localScale.x/2+other.gameObject.transform.localScale.x/2-0.01f)
            {
                transform.position=new Vector3(transform.posititon.x+0.01f,transform.position.y,transform.position.z);
            }
            if(transform.position.z>other.gameObject.transform.position.z+transform.localScale.z/2+other.gameObject.transform.localScale.z/2-0.01f)
            {
               transform.position=new Vector3(transform.posititon.x,transform.position.y,transform.position.z+0.01f);
            }

            if(transform.position.x<other.gameObject.transform.position.x+transform.localScale.x/2+other.gameObject.transform.localScale.x/2+0.01f)
            {
                 transform.position=new Vector3(transform.posititon.x-0.01f,transform.position.y,transform.position.z);
            }
            if(transform.position.z<other.gameObject.transform.position.z+transform.localScale.z/2+other.gameObject.transform.localScale.z/2+0.01f)
            {
                 transform.position=new Vector3(transform.posititon.x,transform.position.y,transform.position.z-0.01f);
            }*/
            StopMovement();

        }
    }

   
}
