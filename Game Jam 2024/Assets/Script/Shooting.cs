using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;
    public Transform shootingPoint;
    public GameObject chickenPrefab;

    private float lastShotTime;

    //[Header("Sounds")]
    //public AudioSource shoot;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isShooting", true);
            lastShotTime = Time.time;
            InvokeRepeating("Shoot", 0.0f, 0.2f);
        }

        if (Time.time - lastShotTime >= 1.0f)
        {
            animator.SetBool("isShooting", false);
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        GameObject chicken = Instantiate(chickenPrefab, shootingPoint.position, transform.rotation);
        ChickenMovement chickenControl = chicken.GetComponent<ChickenMovement>();
        chickenControl.player = playerTransform.position;
        chickenControl.shootingPoint = shootingPoint.position;
    }
}
