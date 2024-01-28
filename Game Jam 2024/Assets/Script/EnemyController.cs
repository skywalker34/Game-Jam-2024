using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;  // Player's transform
    public NavMeshAgent navMeshAgent;
    public GameObject bananaPrefab;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target (Player) not assigned.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Set the destination for the NavMeshAgent to follow
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("banana peel"))
        {
            GameObject banana = Instantiate(bananaPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("chicken") || collision.gameObject.tag.Equals("meteor") || collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
