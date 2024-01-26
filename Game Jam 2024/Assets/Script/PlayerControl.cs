using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody playerRigidbody;
    public Transform mainCamera;
    //public Animator animator;

    public float speed = 10f;
    public float turnSmoothTime = 0.1f;
    public float rotationSpeed = 5.0f;
    float turnSmoothVelocity;
    bool isDead = false;


    public Camera playerCamera;
    void Start()
    {
       playerRigidbody = GetComponent<Rigidbody>();
       playerCamera = FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

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
             Debug.DrawLine(cameraRay.origin, pointToLook, Color.yellow);
        
             transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
         }

        //animator.SetFloat("Speed", direction.magnitude);
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
