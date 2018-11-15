using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public Animator animator;
    public Transform weapon, player, firePoint;
    public float rotationSpeed = 3f;

	// Update is called once per frame
	void Update () {
        // Calculates direction from object to cursor
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weapon.position;
        direction.Normalize();
        
        // Verify player orientation
        float angle = (player.transform.localScale.x <= -1) ? 
            Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg 
            : Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Calculates new rotation
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Spherically sets rotation
        weapon.rotation = Quaternion.Slerp(weapon.rotation, newRotation, rotationSpeed * Time.deltaTime);
        //Debug.Log(weapon.rotation.eulerAngles);

        // Attacks on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            animator.ResetTrigger("Attacking");
            animator.SetTrigger("Attacking");
            Vector3 bRotation = (firePoint.position - weapon.position).normalized;
            gameObject.GetComponent<Shoot>().SpawnBullet(firePoint.position, bRotation);
        }
    }
}