using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;
    public Transform shootingPoint;
    public Transform meteorSpawn;
    public GameObject chickenPrefab;
    public GameObject bananaPeelPrefab;
    public GameObject firePrefab;
    public bool isBanana = false;
    private float speed = 30f;

    private bool canShoot = false;

    int randomNumberInt;
    public Vector3 player { get; set; }
    public Vector3 enemy { get; set; }
    public Vector3 shootingOrigin { get; set; }
    public Rigidbody fireRigidbody;

    //public Camera playerCamera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isShooting", true);
            Invoke("EnableShooting", 1f); // Enable shooting after 4 
        }

        if (canShoot)
        {
            randomNumberInt = UnityEngine.Random.Range(0, 101);
            isBanana = randomNumberInt > 60 ? true : false;
            Shoot();
            canShoot = false; // Reset the flag
            animator.SetBool("isShooting", false);
        }
    }

    void EnableShooting()
    {
        canShoot = true;
    }

    void Shoot()
    {
        if (isBanana)
        {
            GameObject bananaPeel = Instantiate(bananaPeelPrefab, shootingPoint.position, transform.rotation);
            Destroy(bananaPeel, 5.0f); // Destroys bananaPeel after 5 seconds
        }
        else if(randomNumberInt < 60 && randomNumberInt > 30)
        {
            GameObject fireball = Instantiate(firePrefab, meteorSpawn.position, transform.rotation);

            fireRigidbody = fireball.GetComponent<Rigidbody>();

            //Destroy(fireball, 5.0f); // Destroys bananaPeel after 5 seconds

            // Get the mouse position in screen coordinates
            Vector2 mousePosition = Input.mousePosition;

            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            // Declare a variable to store the hit information
            RaycastHit hit;

            // Check if the ray hits any object
            if (Physics.Raycast(ray, out hit))
            {
                // Get the point where the hit occurred
                Vector3 hitPoint = hit.point;

                Vector3 direction = (hitPoint - shootingOrigin).normalized;
                fireRigidbody.velocity = new Vector3(direction.x * speed, direction.y * speed, direction.z * speed);
                // Print the hit point to the console
                Debug.Log("You clicked at " + hitPoint);
            }

        }
        else
        {
            GameObject chicken = Instantiate(chickenPrefab, shootingPoint.position, transform.rotation);
            ChickenMovement chickenControl = chicken.GetComponent<ChickenMovement>();
            chickenControl.player = playerTransform.position;
            chickenControl.shootingPoint = shootingPoint.position;
            Destroy(chicken, 5.0f); // Destroys chicken after 5 seconds
        }
    }
}
