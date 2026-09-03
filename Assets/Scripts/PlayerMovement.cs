using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float sideMoveDistance = 3f;
    public float sideMoveSpeed = 10f;
    public float jumpForce = 7f;
    public float gravity = 20f;
    public bool isJumping = false;
    private int currentLane = 1;
    private float verticalVelocity = 0f;
    private float groundY;
    private float startX;

    #region Particle
    public ParticleSystem movementLines;
    public ParticleSystem jumpLines;
    #endregion

    void Start()
    {
        startX = transform.position.x;
        groundY = transform.position.y;
    }

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        HandleSideMovement();
        HandleJump();
    }

    public void MoveLeft()
    {
        if (currentLane > 0)
        {
            currentLane--;

            #region Animation
            GetComponent<Animator>().SetTrigger("Left");
            #endregion

            #region Particle
            movementLines.transform.localRotation = Quaternion.Euler(0, -90f, 0);
            movementLines.Play();
            #endregion
        }
    }

    public void MoveRight()
    {
        if (currentLane < 2)
        {
            currentLane++;

            #region Animation
            GetComponent<Animator>().SetTrigger("Right");
            #endregion

            #region Particle
            movementLines.transform.localRotation = Quaternion.Euler(0, 90f, 0);
            movementLines.Play();
            #endregion
        }
    }

    public void Jump()
    {
        if (isJumping)
            return;

        verticalVelocity = jumpForce;
        isJumping = true;

        #region Animation
        GetComponent<Animator>().SetBool("Jump", true);
        #endregion

        #region Particle
        jumpLines.transform.localRotation = Quaternion.Euler(-90f, 0, 0);
        jumpLines.Play();
        #endregion
    }

    void HandleSideMovement()
    {
        float targetX = startX + (currentLane - 1) * sideMoveDistance;
        float newX = Mathf.MoveTowards(transform.position.x, targetX, sideMoveSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void HandleJump()
    {
        verticalVelocity -= gravity * Time.deltaTime;
        float newY = transform.position.y + verticalVelocity * Time.deltaTime;
        
        if (newY <= groundY)
        {
            newY = groundY;
            verticalVelocity = 0f;
            isJumping = false;

            #region Animation
            GetComponent<Animator>().SetBool("Jump", false);
            #endregion
        }

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}