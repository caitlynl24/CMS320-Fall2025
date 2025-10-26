using UnityEngine;

public class ScarecrowController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Normalize diagonal movement
        movement = movement.normalized;

        //Update animator parameters
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", movement.magnitude > 0);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }

        //Move character
        transform.position += new Vector3(movement.x, movement.y, 0) * moveSpeed * Time.deltaTime;
    }
}