using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "plant_object", menuName = "plant", order = 0)]
public class plant_object : ScriptableObject {
   public string plant_name;
   public Sprite[] plantStages;
   public int [] growTime_002Sec; 


}
