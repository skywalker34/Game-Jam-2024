using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody playerRigidbody;
    public Transform mainCamera;
    public Animator animator;

    public float speed = 10f;
    public float rotationSpeed = 5.0f;
    bool isDead = false;


    public Camera playerCamera;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerCamera = FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the character
        GetComponent<CharacterController>().Move(movement * speed * Time.deltaTime);

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
}
