using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public Vector3 player { get; set; }
    public Vector3 enemy { get; set; }
    public Vector3 shootingPoint { get; set; }
    public Rigidbody chickenRigidbody;
    private float speed = 10f;

    //void Start()
    //{
    //    Vector3 direction = (shootingPoint - player).normalized;
    //    chickenRigidbody.velocity = new Vector3(direction.x * speed, 0, direction.z * speed);
    //}

    void Update()
    {
        Vector3 direction = (shootingPoint - player).normalized;
        chickenRigidbody.velocity = new Vector3(direction.x * speed, chickenRigidbody.velocity.y, direction.z * speed);
    }
}
