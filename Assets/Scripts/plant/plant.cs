using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public plant_object plantAttr ;
    int currentStage = 0;
    int timer = 0;
    SpriteRenderer plantSprite ;

    void Start(){
        Debug.Log("hello");
        plantSprite = gameObject.GetComponent<SpriteRenderer>();
        plantSprite.sprite = plantAttr.plantStages[0];
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {  
        
        if (currentStage < plantAttr.growTime_002Sec.Length && timer >= plantAttr.growTime_002Sec[currentStage])
        {
                timer = 0 ;
                currentStage+=1;
                Debug.Log(currentStage);
                //Update
                plantSprite.sprite = plantAttr.plantStages[currentStage];
        }
        
        timer+=1;
    }

}