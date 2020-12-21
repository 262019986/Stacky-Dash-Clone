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
        Vector3 rayStart=transform.position + Vector3.up  ;
        Debug.DrawRay(rayStart,direction,Color.red,5);
        RaycastHit hit;
        if(Physics.Raycast(rayStart, direction,out hit, 100.0f))
        {           
            Debug.Log(hit.transform.name);
            if(hit.transform.tag=="Obstacle")
            {   
                PositionController=hit.transform.position-direction;
                passTime=Vector3.Distance(transform.position,hit.transform.position)/10;
                transform.DOMove( hit.transform.position-direction,passTime );
                CheckAvailableWays();

            }
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
        Vector3 rayStart=transform.position + Vector3.up ;
        Debug.DrawRay(rayStart,dir,Color.red,5);
        RaycastHit hit;
        
        if(Physics.Raycast(rayStart, dir,out hit, 1) && hit.transform.tag=="Obstacle" )
        {
            return true;
        }
        
        return true;
    }
        private void OnTriggerEnter(Collider other) 
        {
           
            if(other.tag=="CollectibleStacks")
            {
                
                
                other.transform.position=new Vector3(transform.position.x , transform.position.y + transform.localScale.y * (count+1) , transform.position.z);
                other.transform.parent=transform;


               
                //transform.position=new Vector3(transform.position.x,0.1f*(count+1),transform.position.z);
                count++;
                other.tag="Collected";
                
               

                

            }

            if(other.tag=="UnCollectible")
            {
                
                other.tag="base";
                transform.GetChild(0).parent.transform.position=other.transform.position;
                transform.GetChild(0).parent=null;
                count--;
                for(int i=0;i<transform.childCount;i++)
                {
                    transform.GetChild(i).transform.position=new Vector3(transform.position.x,transform.GetChild(i).transform.position.y-0.1f,transform.position.z);
            
                }

            
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
