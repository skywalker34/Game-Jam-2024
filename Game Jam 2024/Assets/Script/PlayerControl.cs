using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody playerRigidbody;
    public Transform mainCamera;
    public Animator animator;
    public GameObject player;
    public GameObject banana;
    public Shooting shootingControl;

    public float speed = 10f;
    public float rotationSpeed = 5.0f;
    bool isDead = false;

    public bool canMove = true;

    public Camera playerCamera;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerCamera = FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        bool isBanana = shootingControl.isBanana;
        player.SetActive(!isBanana);
        banana.SetActive(isBanana);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the character
        if (canMove)
        {

            GetComponent<CharacterController>().Move(movement * speed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            SetCanMoveFalse(); // Stops player from moving during casting animation
            Invoke("SetCanMoveTrue", 1.0f); // After 3 seconds (duration of the animation) player can move again

        }


        //Face The Mouse
        Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        animator.SetFloat("Speed", movement.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            //animator.SetBool("isDead", true);
            isDead = true;
        }
    }



    public void SetCanMoveFalse() // Stops playing from moving during casting animation
    {
        if (canMove)
        {
            //canMove = false;
        }
    }
    public void SetCanMoveTrue() // Player can move again after animation is done
    {
        if (!canMove)
        {
            canMove = true;
        }
    }
}
