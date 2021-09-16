using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject door;
    private bool isGround ;
     
    
    


            
    
    	
    void  FixedUpdate()
    {
        if(isGround)
        {
        	door.transform.position = new Vector3(16, 5, -49);
        }
        
    	if(Input.GetKey(KeyCode.W))
    	{
        	transform.position += Vector3.forward*_speed*Time.deltaTime;
        	transform.rotation = Quaternion.Euler(0,0,0);
    	}
    	else if(Input.GetKey(KeyCode.S))
    		 {
        		transform.position -= Vector3.forward*_speed*Time.deltaTime;
        		transform.rotation = Quaternion.Euler(0,180,0);
    		 }   
     	else if(Input.GetKey(KeyCode.A))
    		 {
        		transform.position += Vector3.left*_speed*Time.deltaTime;
        		transform.rotation = Quaternion.Euler(0,-90,0);
    		 }
    	else if(Input.GetKey(KeyCode.D))
    		 {
        		transform.position -= Vector3.left*_speed*Time.deltaTime;
        		transform.rotation = Quaternion.Euler(0,90,0);
    		 }   
    }

    private void OnCollisionEnter(Collision other)
    {
    	if(other.gameObject.layer == 8)
        isGround = true;
    }
   
    
  
   
}
