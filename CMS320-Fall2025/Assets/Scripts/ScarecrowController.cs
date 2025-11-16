using UnityEngine;
using System.Collections;

public class ScarecrowController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMove;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private float jumpDuration = 0.4f;
    private SpriteRenderer sr;
    private int normalSortingOrder;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        normalSortingOrder = sr.sortingOrder;
    }

    void Update()
    {
        //Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Normalize diagonal movement
        movement = movement.normalized;

        //Store last movement direction if moving
        if(movement.magnitude > 0) 
        {
            lastMove = movement;
        }

        //Update animator parameters
        animator.SetFloat("MoveX", movement.magnitude > 0 ? movement.x : lastMove.x);
        animator.SetFloat("MoveY", movement.magnitude > 0 ? movement.y : lastMove.y);
        animator.SetBool("IsMoving", movement.magnitude > 0);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            animator.SetTrigger("Jump");
            StartCoroutine(JumpRoutine());
        }
    }

    private IEnumerator JumpRoutine()
    {
        isJumping = true;

        //Ignore collisions between Player layer (your character) and Haybale layer
        int playerLayer = LayerMask.NameToLayer("Player");
        int haybaleLayer = LayerMask.NameToLayer("Haybale");
        Physics2D.IgnoreLayerCollision(playerLayer, haybaleLayer, true);

        float originalOffset = rb.position.y;

        rb.position += Vector2.up * 0.2f; //Lifts the player visually

        //Bring scarecrow in front of haybales
        sr.sortingOrder = normalSortingOrder + 10;

        //Wait for jump animation duration
        yield return new WaitForSeconds(jumpDuration);

        //Restore collisions
        Physics2D.IgnoreLayerCollision(playerLayer, haybaleLayer, false);
        rb.position = new Vector2(rb.position.x, originalOffset);

        //Restore normal draw order
        sr.sortingOrder = normalSortingOrder;
        
        isJumping = false;
    }

    void FixedUpdate()
    {
        //Move character using Rigidbody2D for proper collision
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}