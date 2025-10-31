using UnityEngine;

public class ScarecrowController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMove;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }
    void FixedUpdate()
    {
        //Move character using Rigidbody2D for proper collision
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}