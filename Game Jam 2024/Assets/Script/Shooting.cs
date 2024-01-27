using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public Animator animator;
    public Transform playerTransform;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private float lastShotTime;

    //[Header("Sounds")]
    //public AudioSource shoot;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //animator.SetBool("isShooting", true);
            lastShotTime = Time.time;
            Shoot();
        }

        //if (Time.time - lastShotTime > 1)
        //{
        //    animator.SetBool("isShooting", false);
        //}
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }
}
