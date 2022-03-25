using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycular_transition : MonoBehaviour
{


    //GameObject camera;
    public GameObject player;
    public GameObject another_door;
    //float smoothing = 1f;
   
    public int door_num ;
    
   
    static int  last_door_num = -1;
    public float  delta_target_X ;
    public float  delta_target_Y ;

    public float  move_myself_x ;
    public float  move_myself_y ;
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
            //moving
            
           

            if(other.CompareTag("Player") ){
                

             
                   // if(last_door_num != door_num){ // 不是自己 ==> 準備傳送
                        last_door_num = door_num;
                        Vector3 targetPosition = new Vector3(player.transform.position.x + delta_target_X , player.transform.position.y +delta_target_Y ,  player.transform.position.z); 
                        //傳送完向內移動自己
                        transform.position = new Vector3(transform.position.x + move_myself_x , transform.position.y+ move_myself_y , transform.position.z);
                        //對方同向
                        another_door.transform.position = new Vector3(another_door.transform.position.x + move_myself_x , another_door.transform.position.y+ move_myself_y , another_door.transform.position.z);
                        
                        player.transform.position = targetPosition;
                        last_door_num = door_num;//設定最後一次成功傳送的門
                    //}
                    /*
                    else{ 
                        transform.position = new Vector3(transform.position.x - move_myself_x , transform.position.y- move_myself_y , transform.position.z);
                       
                        another_door.transform.position = new Vector3(another_door.transform.position.x - move_myself_x , another_door.transform.position.y- move_myself_y , another_door.transform.position.z);
                        last_door_num = -1 ;
                    }*/
                 }
                
               
               
        }
    

   
}
