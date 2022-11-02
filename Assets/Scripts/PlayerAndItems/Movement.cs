
using UnityEngine;
using Mirror;

public class Movement : NetworkBehaviour
{
    //public GameObject CameraMountPoint;
    public GameObject playerCamera;
    public GameObject playerAudioListener;
    public Actions actions;

    private CharacterController controller; 
    private Vector3 playerVelocity;
    private bool isWalking;
    private bool isSprinting;
    private bool groundedPlayer;
    private float walkSpeed = 25.0f;
    private float sprintSpeed = 50.0f;
    private float playerSpeed;
    private float jumpHeight = 10.0f;
    private float gravityValue = -98.11f;

    private float xDirection, zDirection;

    void Start() {
        controller = GetComponent<CharacterController>();
        actions = GetComponentInChildren<Actions>();
        playerSpeed = walkSpeed;
        isWalking = false;
        isSprinting = false;
        
        if (!isLocalPlayer)
        {
            playerCamera.gameObject.SetActive(false);
            playerAudioListener.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isLocalPlayer)
        {
            return;
        }
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // directional movement input
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");

        // input for sprint
        if (Input.GetKey(KeyCode.LeftShift)) {
            playerSpeed = sprintSpeed;
            isSprinting = true;
            isWalking = false;
        }
        else {
            playerSpeed = walkSpeed;
            isSprinting = false;
            isWalking = true;
            
        }

        // jump input
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
        
    }

    void FixedUpdate() {
        UpdatePlayer();
    }

    void UpdatePlayer() {
        Vector3 moveDirection = transform.right * xDirection + transform.forward * zDirection;
        controller.Move(moveDirection * playerSpeed * Time.deltaTime);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        AnimatePlayer(); 
    }

    void Jump(){
        if (groundedPlayer) {
            actions.Jump();
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }

    void AnimatePlayer() {
        if (xDirection == 0 && zDirection == 0) {
            isWalking = false;
            isSprinting = false;
            actions.Stay();
        }

        if (isWalking) {
            actions.Walk();
        }
        else if (isSprinting) {
            actions.Run();
        }
    }
     
}


