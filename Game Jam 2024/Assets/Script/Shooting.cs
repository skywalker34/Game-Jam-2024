using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bananaUI;
    public GameObject chickenUI;
    public GameObject fireballUI;
    public GameObject defaultUI;
    public Animator animator;
    public Transform playerTransform;
    public Transform shootingPoint;
    public GameObject chickenPrefab;
    public GameObject bananaPeelPrefab;
    public GameObject firePrefab;
    public bool isBanana = false;
    private bool isChicken = false;
    private bool isFire = false;
    private bool isDefault = true;
    private bool canShoot = true;
    private bool canResetSpell = true;
    private float speed = 30f;
    private float lastShotTime;
    private float resetTime;


    int randomNumberInt;
    public Vector3 player { get; set; }
    public Vector3 enemy { get; set; }
    public Vector3 shootingOrigin { get; set; }
    public Rigidbody fireRigidbody;

    //public Camera playerCamera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            animator.SetBool("isShooting", true);
            lastShotTime = Time.time;
            if (canResetSpell)
            {
                resetTime = Time.time;
                randomNumberInt = UnityEngine.Random.Range(0, 101);
                isBanana = randomNumberInt > 60;
                isFire = randomNumberInt <= 60 && randomNumberInt > 30;
                isChicken = randomNumberInt <= 30 && randomNumberInt > 10;
                isDefault = randomNumberInt <= 10;
                canResetSpell = false;
            }
            Shoot();
            canShoot = false;
        }

        if (Time.time - lastShotTime >= 1.0f)
        {
            animator.SetBool("isShooting", false);
            canShoot = true;
        }

        if (Time.time - resetTime >= 5.0f)
        {
            canResetSpell = true;
        }
    }

    void Shoot()
    {
        if (isBanana)
        {
            GameObject bananaPeel = Instantiate(bananaPeelPrefab, shootingPoint.position, transform.rotation);
            Destroy(bananaPeel, 5.0f); // Destroys bananaPeel after 5 seconds
            bananaUI.SetActive(true);
            chickenUI.SetActive(false);
            fireballUI.SetActive(false);
            defaultUI.SetActive(false);
        }
        else if (isFire)
        {
            Vector2 mousePosition = Input.mousePosition;    // Get the mouse position in screen coordinates
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);  // Create a ray from the camera to the mouse position
            RaycastHit hit;   // Declare a variable to store the hit information

            // Check if the ray hits any object
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitPoint = hit.point;
                Vector3 direction = (hitPoint - shootingOrigin).normalized;
                GameObject fireball = Instantiate(firePrefab, new Vector3(hit.point.x, 30, hit.point.z), transform.rotation);
                fireRigidbody = fireball.GetComponent<Rigidbody>();
                Destroy(fireball, 5.0f);
            }
            bananaUI.SetActive(false);
            chickenUI.SetActive(false);
            fireballUI.SetActive(true);
            defaultUI.SetActive(false);
        }
        else if (isChicken)
        {
            GameObject chicken = Instantiate(chickenPrefab, shootingPoint.position, transform.rotation);
            ChickenMovement chickenControl = chicken.GetComponent<ChickenMovement>();
            chickenControl.player = playerTransform.position;
            chickenControl.shootingPoint = shootingPoint.position;
            Destroy(chicken, 5.0f); // Destroys chicken after 5 seconds
            bananaUI.SetActive(false);
            chickenUI.SetActive(true);
            fireballUI.SetActive(false);
            defaultUI.SetActive(false);
        }
        else
        {
            bananaUI.SetActive(false);
            chickenUI.SetActive(false);
            fireballUI.SetActive(false);
            defaultUI.SetActive(true);
        }
    }
}
