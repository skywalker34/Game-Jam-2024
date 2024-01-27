using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;
    public Transform shootingPoint;
    public GameObject chickenPrefab;
    public GameObject bananaPeelPrefab;
    public bool isBanana = false;

    private float lastShotTime;

    //[Header("Sounds")]
    //public AudioSource shoot;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int randomNumberInt = UnityEngine.Random.Range(0, 101);
            isBanana = randomNumberInt > 30 ? true : false;
            animator.SetBool("isShooting", true);
            lastShotTime = Time.time;
            if (isBanana)
            {
                Shoot();
            }
            else
            {
                InvokeRepeating("Shoot", 0.2f, 0.2f);
            }
        }

        if (Time.time - lastShotTime >= 1.0f)
        {
            animator.SetBool("isShooting", false);
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        if (isBanana)
        {
            GameObject bananaPeel = Instantiate(bananaPeelPrefab, shootingPoint.position, transform.rotation);
            Destroy(bananaPeel, 5.0f);
        }
        else
        {
            GameObject chicken = Instantiate(chickenPrefab, shootingPoint.position, transform.rotation);
            ChickenMovement chickenControl = chicken.GetComponent<ChickenMovement>();
            chickenControl.player = playerTransform.position;
            chickenControl.shootingPoint = shootingPoint.position;
            Destroy(chicken, 5.0f);
        }
    }
}
