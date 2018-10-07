using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D cc;
    public Animator animator;

    public float rSpeed = 40f; //Run Speed
    private float hMove = 0f; //Horizontal Move

    [SerializeField] private bool jump = false; //Jump
    [SerializeField] private bool duck = false; //Duck

    // Update is called once per frame
    void Update() {
        hMove = Input.GetAxisRaw("Horizontal") * rSpeed;

        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("Jumping", true);
        }

        if (Input.GetButtonDown("Duck"))
            duck = true;
        else if (Input.GetButtonUp("Duck"))
            duck = false;
    }

    public void OnLanding() {
        animator.SetBool("Jumping", false);
    }

    public void OnDucking(bool isDucking) {
        animator.SetBool("Ducking", isDucking);
    }

    void FixedUpdate() {
        cc.Move(hMove * Time.fixedDeltaTime, duck, jump);
        jump = false;
    }
}
