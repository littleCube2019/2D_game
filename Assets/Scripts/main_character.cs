using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_character : MonoBehaviour
{

    public CharacterController2D controller2D;
    public float hunger;
    public float stamina;
    public float maxStamina;
    public float maxhunger;
   // public Inventory inventory;
  //  public Transform handPoint;
    public Inventory inventory;
    private float horizontalSpeed = 0;
    private float verticalSpeed = 0;
    private bool jump = false;
    private bool pick = false;    
    public float moveSpeed = 0.4f;

    public terrian_generator terrian_Generator ;
    public  BlockCollection dirts;
    Block choosedBlock;
    private KeyCode[] hotkey =
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4
    };
    // Start is called before the first frame update
    void Start()
    {
        choosedBlock = dirts.whitedirt ;
        
        // Coroutine結束就結束了，所以才要用while
        StartCoroutine(hungerSystem());
        StartCoroutine(staminaSystem());

        hunger = maxhunger;
        stamina = maxStamina;
    }
    Vector2Int mousePos ;
    // Update is called once per frame

    void FixedUpdate(){
        controller2D.Move(horizontalSpeed, verticalSpeed, jump);
    }
    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");
        
       
        if(Input.GetKey(KeyCode.W)){
            jump = true;
        }    
        else
        {
            jump = false;
        }
       

        if (Input.GetKeyDown(KeyCode.F))
        {
            pick = true;
        }
        else
        {
            pick = false;
        }


        mousePos.x  = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        mousePos.y  = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        
        if(Input.GetMouseButton(1)){
            terrian_Generator.playerDestroyBlock(mousePos.x , mousePos.y);  
        }
        if(Input.GetMouseButton(0)){
           
            terrian_Generator.playerConstructBlock(choosedBlock , mousePos.x , mousePos.y);  
        }
    }
    IEnumerator hungerSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            hunger = Mathf.Max(0, hunger -= 1);
            //Debug.Log("hunger: " + hunger.ToString());
        }
    }
    IEnumerator staminaSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            stamina = Mathf.Min(stamina += 5, maxStamina);
            //Debug.Log("stamina: " + stamina.ToString());
        }
    }

    public void useItem(int itemNumber)
    {
        inventory.useItem(itemNumber);     
    }
}
