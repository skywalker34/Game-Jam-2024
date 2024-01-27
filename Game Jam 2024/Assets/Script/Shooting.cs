using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;
    public Transform shootingPoint;
    public GameObject chickenPrefab;
    public GameObject bananaPeelPrefab;
    public bool isBanana = false;

    private bool canShoot = false;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isShooting", true);
            Invoke("EnableShooting", 3f); // Enable shooting after 4 
        }

        if (canShoot)
        {
            int randomNumberInt = UnityEngine.Random.Range(0, 101);
            isBanana = randomNumberInt > 30 ? true : false;
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
