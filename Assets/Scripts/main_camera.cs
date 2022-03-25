using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_camera : MonoBehaviour
{

    public Transform target;
    public float smoothing = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate() {
         if(transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.position.x , target.position.y ,  transform.position.z); 
            //不要移動z
            //targetPosition.x = Mathf.Clamp(targetPosition.x , min_x , max_x);
            //targetPosition.y = Mathf.Clamp(targetPosition.y , min_y , max_y);

            transform.position =  targetPosition;
            //Lerp , 線性插植
        }    
    }
}
