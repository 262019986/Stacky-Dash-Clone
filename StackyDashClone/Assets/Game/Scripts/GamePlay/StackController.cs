using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{

    public bool canMove=true;
    public int count;
    Vector3 lastPos;
    
    private GameObject hitObject;
    public float passTime=1.5f;
    public float maxRayDistance=50f;
    private Character characterScript;
    public  Vector3 characterPos;

     private Vector2 movementInput; //this will hold the input value for joystick or touchpad
    private Vector3 tiltInput; //This will hold the tilt value of the device

    JoystickMovement Joystick;
    [SerializeField] private TiltController TiltController;

    private Rigidbody rigidbody;
  
    

    private void Awake() 
    {
       
    }

    private void Start() {
        rigidbody=GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        //Swipe events
        SwipeEvents.OnSwipeUp += OnSwipeUp;
        SwipeEvents.OnSwipeDown += OnSwipeDown;
        SwipeEvents.OnSwipeLeft += OnSwipeLeft;
        SwipeEvents.OnSwipeRight += OnSwipeRight;

        //Tap events
        
    }

    void OnDisable()
    {
        //! Always unsubscribe to events if you have subscribed to them
        //Swipe Events
        SwipeEvents.OnSwipeUp -= OnSwipeUp;
        SwipeEvents.OnSwipeDown -= OnSwipeDown;
        SwipeEvents.OnSwipeLeft -= OnSwipeLeft;
        SwipeEvents.OnSwipeRight -= OnSwipeRight;

        //Tap Events
        

    }

   

   
    void FixedUpdate()
    {
        //We are getting the horizontal and vertical touch or joystick input
        movementInput.x = Joystick.HorizontalInput();
        movementInput.y = Joystick.VerticalInput();

       
        
    }

    
   private void CanMove()
    {
        canMove=true;
    }
    private void OnSwipeUp()
    {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.right, 100.0F);
            
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
    
                if(hit.collider.gameObject.tag=="Obstacle"&&canMove)
                {
                    canMove=false;
                    transform.DOLocalMove(new Vector3(hit.collider.transform.position.x,transform.position.y,hit.collider.transform.position.z)-Vector3.right,passTime );

                    Debug.Log("fORWARD");
                    Debug.Log(hit.collider.gameObject.name);
                    Invoke("CanMove",passTime);

                    return;
                }
                
            }
    }



    private void OnSwipeDown()
    {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, Vector3.left, 100.0F);
            for (int i = 0; i < hits.Length; i++)
        {
           RaycastHit hit = hits[i];
           
            
                
            if(hit.collider.gameObject.tag=="Obstacle"&&canMove)
            {
                canMove=false;
                transform.DOLocalMove(new Vector3(hit.collider.transform.position.x,transform.position.y,hit.collider.transform.position.z)+Vector3.right,passTime );
                Invoke("CanMove",passTime);
                return;
            }
            
        }
    }

    private void OnSwipeLeft()
    {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
            for (int i = 0; i < hits.Length; i++)
        {   

            RaycastHit hit = hits[i];
                
            
            if(hit.collider.gameObject.tag=="Obstacle"&&canMove)
            {
                canMove=false;
                transform.DOLocalMove( new Vector3(hit.collider.transform.position.x,transform.position.y,hit.collider.transform.position.z)-Vector3.forward,passTime );
                Debug.Log("Back");
                Debug.Log(hit.collider.gameObject.name);
                Invoke("CanMove",passTime);
                return;
            }
            
        }
    }

    private void OnSwipeRight()
    {
        RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward*-1, 100.0F);
            
            for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
                
            
            if(hit.collider.gameObject.tag=="Obstacle"&&canMove)
            {
                canMove=false;
                transform.DOLocalMove( new Vector3(hit.collider.transform.position.x,transform.position.y,hit.collider.transform.position.z)+Vector3.forward,passTime );
                Debug.Log("right");
                Debug.Log(hit.collider.gameObject.name);
                Invoke("CanMove",passTime);
                return;
            }
            
        }
    }

    

    
    
        private void OnTriggerEnter(Collider other) 
        {
           
            if(other.tag=="CollectibleStacks")
            {
                count=transform.childCount;
                Debug.Log("stack");
                other.transform.parent=transform;
                count=transform.childCount;
                other.transform.position=transform.position+count*Vector3.up*transform.localScale.y;

            }
        }

   
}
