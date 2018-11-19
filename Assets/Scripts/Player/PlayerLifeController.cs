using UnityEngine;

public class PlayerLifeController : MonoBehaviour {

    public float deathYHeight = -30f;
    public Animator animator;
    
    private Vector2 lastCheckpoint;
    private bool dead;

    // Initialization
    private void Awake() {
        dead = false;
        lastCheckpoint = gameObject.transform.position;
    }

    // Death by height
    private void Update() {
        if (transform.position.y <= deathYHeight) {
            RespawnPlayer();
        }
    }

    // Collision with new checkpoint
    void OnTriggerEnter2D(Collider2D collider) {
        string tag = collider.tag;

        if (tag == "Checkpoint") {
            Checkpoint checkpoint = collider.gameObject.GetComponent<Checkpoint>();

            if (!checkpoint.GetIsOn()) {
                lastCheckpoint = collider.gameObject.GetComponent<Transform>().position;
                checkpoint.Activate();
            }
        } else if (tag == "Enemy" || tag == "Hazard") {
            RespawnPlayer();
        }
    }

    // Enemies and hazards
    void OnCollisionEnter2D(Collision2D collision) {
        Collider2D collider = collision.collider;
        string tag = collider.tag;

        if (tag == "Enemy" || tag == "Hazard") {
            RespawnPlayer();
        }
    }

    // Plays death animation
    public void RespawnPlayer() {
        if (!dead) {
            dead = true;
            animator.SetBool("Died", true);
        }
    }

    // Move player to spawn
    public void DiedAnimationEnded() {
        transform.position = lastCheckpoint;
        dead = false;
        animator.SetBool("Died", false);
    }

    // Returns if the player is dead (respawning)
    public bool GetDead() {
        return dead;
    }
}