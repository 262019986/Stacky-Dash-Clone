using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{

    
    public int count;
    public Direction _direction=new Direction();
    public float passTime=1.5f;
    public Vector3 PositionController;


    private void Start() 
    {
        
        
    }
    
    void OnEnable()
    {
        //Swipe events
        SwipeEvents.OnSwipeUp += OnSwipeUp;
        SwipeEvents.OnSwipeDown += OnSwipeDown;
        SwipeEvents.OnSwipeLeft += OnSwipeLeft;
        SwipeEvents.OnSwipeRight += OnSwipeRight;
        EventManager.OnGameStart.AddListener(() => transform.SetParent(null));
        EventManager.OnUnStack.AddListener (Unstack);
        EventManager.OnStop.AddListener( () => Destroy(transform.GetChild(0) , 1f )) ;


        


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

        EventManager.OnGameStart.RemoveListener(() => transform.SetParent(null));
        EventManager.OnUnStack.RemoveListener (Unstack);
         EventManager.OnStop.RemoveListener( () => Destroy(transform.GetChild(0) , 1f )) ;
        
        

        //Tap Events
        

    }

   
   
     private void OnSwipeRight()
    {
        if(_direction.Right)
        {
            _direction.Right=false;
            Move(Vector3.back);
        }
    }

    private void OnSwipeUp()
    {
       if(_direction.Up)
       {
            _direction.Up=false;
            Move(Vector3.right);
       }
    }



    private void OnSwipeDown()
    {
        if(_direction.Down)
        {
            _direction.Down=false;
             Move(Vector3.left);
        }
            
    }

    private void OnSwipeLeft()
    {
        if(_direction.Left) 
        {
            _direction.Left=false;
            Move(Vector3.forward);
            Debug.Log("LEFT");
        }

    }

   
    private void Move(Vector3 direction)
    {
        EventManager.OnMove.Invoke();
        Vector3 rayStart=transform.position + Vector3.up  ;
        Debug.DrawRay(rayStart,direction,Color.red,5);
        RaycastHit hit;
        if(Physics.Raycast(rayStart, direction, out hit, 100.0f))
        {           
            Debug.Log(hit.transform.name);
            if(hit.transform.tag == "Obstacle")
            {   
                
                  
                PositionController=hit.transform.position-direction;
                passTime= Vector3.Distance (transform.position,hit.transform.position)/13;
                transform.DOMove( hit.transform.position-direction,passTime );
                
                
                CheckAvailableWays();

            }
        }
            
        
    }

    IEnumerator AutomaticMove(Vector3 direction)
    {
        yield return new WaitForSeconds(0.05f);
        Move(direction);
    }
    private void Unstack()
    {
        

       for(int i=2;i<transform.childCount;i++)
        {
            transform.GetChild(i).transform.position = new Vector3(transform.position.x , transform.GetChild(i).transform.position.y -0.1f , transform.position.z);
        }

    }
    

    
    private void CheckAvailableWays()
    { 
        _direction.Left=WayRay(Vector3.forward);
        _direction.Right=WayRay(Vector3.back);
        _direction.Up=WayRay(Vector3.right);
        _direction.Down=WayRay(Vector3.left);
    }
    
    private bool WayRay(Vector3 dir )
    {
        Vector3 rayStart = transform.position + Vector3.up ;
        Debug.DrawRay(rayStart , dir , Color.red , 5);
        RaycastHit hit;
        
        if(Physics.Raycast(rayStart, dir,out hit, 1) && hit.transform.tag == "Obstacle" )
        {
            return true;
        }
        
        return true;
    }
        private void OnTriggerEnter(Collider other) 
        {
           
            if(other.tag == "CollectibleStacks")
            {
                EventManager.OnStack.Invoke();
                count++;
                other.tag="Collected";  
                other.transform.position=new Vector3(transform.position.x , transform.position.y + transform.localScale.y * (count) , transform.position.z);
                other.transform.parent=transform;
                EventManager.OnStop.Invoke();



            }

            if(other.tag=="UnCollectible")
            {
                
                other.tag="base";
                count--;
                EventManager.OnUnStack.Invoke();
                transform.GetChild(2).position = other.transform.position + Vector3.up * transform.localScale.y ;
                transform.GetChild(2).transform.SetParent(null);
 
            }

            if(other.tag == "Obstacle")
            {
               
                
            }

            if(other.CompareTag("DownArrow"))
            {
                
                StartCoroutine(AutomaticMove(Vector3.left));
            }

            if(other.CompareTag("UpArrow"))
            {
                
                StartCoroutine(AutomaticMove(Vector3.right));
            }

            if(other.CompareTag("LeftArrow"))
            {
                
                StartCoroutine(AutomaticMove(Vector3.forward));
            }

            if(other.CompareTag("RightArrow"))
            {
                
               StartCoroutine(AutomaticMove(Vector3.back));
            }
            
        }

   
}

[System.Serializable]
public class Direction 
{
    public bool Up=true;
    public bool Down=true;
    public bool Right=true;
    public bool Left=true;
}
