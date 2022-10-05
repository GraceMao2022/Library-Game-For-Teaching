using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; ////

/* PlayerMovement.cs
   
   This is the code for player movement: moving left and right, jumping, flipping the player, dying

   Animations for moving are connected to the code here

*/

public class PlayerMovement : MonoBehaviour
{
    //// General: if there is no modifier before a field or method, it is default private. 
    //// By making a field public, we will be able to edit what is stored in it through the Unity editor.
    //// [SerializeField] makes private variables visible in Unity editor

    private Rigidbody2D rb; // the Rigidbody2D component of the player 

    private float horDir; // -1 means move left, 1 means move right, 0 means stop
    private float vertDir; // 1 means move up, 0 means stop
    public float moveSpeed = 5.59f; // horizontal speed of player. ////We can edit this value later in the Unity editor.

    ////add these after you have showed movement left and right on Unity
    [SerializeField] private float jumpForce = 500f; // jump force of player
                            ////you could also type public float jumpForce
    private bool jump; // true if player is on the ground and about to jump, false otherwise
    private bool isGrounded; // true if player is touching the ground
    public Transform GroundCheck; // The position of a GameObject that will mark the player's feet
    public LayerMask groundLayer; // determines which layers count as the ground

    private bool facingRight = true; // true if player is facing right

    private bool isDead = false; ////Day 3 // true if player is dead

    public Animator animator; ////Day 3 // the animator of the player
    public GameObject player; ////Day 3 // the player
    public GameObject lowestBound; ////Day 3 // an empty GameObject that marks the lowest point in your game

    ////this is similar to the Start() method; both are normally used to initialize variables.
    ////there are differences, but they are not important for this class
    // intialize variables
    void Awake()
    {
        // find the Rigidbody2D component of the object that this script is attached to
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame. We use this to detect user input
    void Update()
    {
        // horizontal movement detection (a & d or left & right arrows): -1 is left, 1 is right
        horDir = Input.GetAxisRaw("Horizontal");
        vertDir = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horDir)); ////day 3
        
        // jump detection (w or up arrow): 1 is jump, must be grounded to be able to jump
        if (vertDir == 1 && isGrounded) 
        {
            jump = true;
            
            ////day3
            ////first show animation without the reset
            // jump animation: if player already jumped immediately before this
            if(animator.GetBool("IsJumping") == true) ////day3
            { ////day3
                // reset jump animation
                animator.Play("Base Layer.Player_Jump", -1, 0f); ////day3
            } ////day3
            // player has not jumped before this
            else ////day3
                animator.SetBool("IsJumping", true); ////day3
        }
        else
        {
            jump = false;

            ////day3
            // jump animation: if player touches ground and doesn't want to jump again, turn off
            // jump animation
            if (isGrounded) ////day3
                animator.SetBool("IsJumping", false); ////day3
        }

        ////day3
        // check if player is below the lowest bound. If it is, then kill the player.
        if (player.transform.position.y <= lowestBound.transform.position.y) ////day3
        { ////day3
            animator.SetBool("IsDead", true); ////day3
            isDead = true; ////day3
        } ////day3
    }

    // similar to Update(), but is better for physics and movement
    private void FixedUpdate()
    {
        // checks if you are within 0.05 position in the Y of the ground layer
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.05f, groundLayer);

        if(!isDead) ////day 3
            Move(); ////NOT Day 3!!!!!!!! DAY 2222222222
    }

    // deals with the the velocity of the player, and calls Flip() and Jump() when applicable
    private void Move()
    {
        // changes horizontal velocity of player
        ////Time.deltaTime makes the speed more constant between different computers with different frames per second
        rb.velocity = new Vector2(horDir * moveSpeed * Time.deltaTime, rb.velocity.y);

        // flip the player if needed
        if ((facingRight && horDir == -1) || (!facingRight && horDir == 1))
            Flip();

        // jump if needed
        if (jump && isGrounded)
            Jump();
    }

    // add a vertical force to the player
    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce));
    }

    // flip the player
    private void Flip()
    {
        facingRight = !facingRight;

        // flips the sprite AND its colliders
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    ////Day 3
    // detects if the player has collided with an enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("IsDead", true);
            isDead = true;
        }
    }
    
    ////Day 3
    // stop the player midair when it dies
    public void Stasis()
    {
        rb.velocity = Vector2.zero; // set player's velocity to zero
        rb.gravityScale = 0;
    }

    ////Day 3
    // the player dies --> reload scene, reset score
    public void Die()
    {
        // reset score
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
