using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Transform waterCheckpoint;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask background;
    [SerializeField] LayerMask water;  
    [SerializeField] bool airwalk;
    [SerializeField] float jumpForce;
    [SerializeField] main_character player;
    [SerializeField] float moveSpeed;
    [SerializeField] float swimSpeed;

    private bool grounded;
    private bool inWater;
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>(); // get your own rb
        grounded = false; // 有沒有在地上
        inWater = false;  
    }
    private void FixedUpdate()
    {
        if(Physics2D.OverlapCircle(waterCheckpoint.position, checkRadius, water))
        {  
            // 檢查範圍內有沒有水 
            inWater = true;
        }
        else
        {
            inWater = false;
        }
        if(Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, background))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    /*private void OnDrawGizmosSelected()  
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(groundCheckPoint.position, groundCheckRadius);
    }*/
    public void Move(float horizontalSpeed, float verticalSpeed, bool jump)
    {
        if (inWater)
        {
            playerRigidBody.velocity = new Vector3(horizontalSpeed*swimSpeed, verticalSpeed*swimSpeed, 0);
        }

        if (!inWater)
        {
            if (!grounded && !airwalk)
            {
                return;
            }
            if (player.stamina <= 0)
            {
                return;
            }
            if (grounded)
            {
                if (jump)
                {
                    playerRigidBody.AddForce(new Vector2(0, jumpForce));
                    player.stamina -= jumpForce * 0.1f;
                }
            }
            playerRigidBody.velocity = new Vector3(horizontalSpeed*moveSpeed, playerRigidBody.velocity.y, 0); 
        }
        player.stamina -= Mathf.Abs(horizontalSpeed) * Time.deltaTime;
        player.stamina = Mathf.Max(0, player.stamina);
    }
}
