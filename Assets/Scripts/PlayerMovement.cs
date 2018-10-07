using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D cc;
    public float rSpeed = 40f; //Run Speed
    private float hMove = 0f; //Horizontal Move
    private bool jump = false; //Jump
    private bool duck = false; //Duck

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal") * rSpeed;
        if (Input.GetButtonDown("Jump"))
            jump = true;

        if (Input.GetButtonDown("Duck"))
        { duck = true; }
        else if (Input.GetButtonUp("Duck"))
            duck = false;
    }

    void FixedUpdate()
    {
        cc.Move(hMove * Time.fixedDeltaTime, duck, jump);
        jump = false;
    }
}
