using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // Player's transform
    public NavMeshAgent navMeshAgent;
    public GameObject bananaPrefab;
    public Animator animator;
    private bool isDead;

    public EnemySpawner enemySpawner;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        if (target == null)
        {
            Debug.LogError("Target (Player) not assigned.");
        }

        enemySpawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();

        bananaPrefab = GameObject.FindWithTag("banana");

    }

    void Update()
    {
        if (target != null)
        {
            // Set the destination for the NavMeshAgent to follow
            navMeshAgent.SetDestination(target.position);
        }

        if (isDead)
        {
            navMeshAgent.speed = 0;
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Goblin die") && stateInfo.normalizedTime >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("banana peel"))
        {
            GameObject banana = Instantiate(bananaPrefab, transform.position, transform.rotation);
            animator.SetBool("isDead", true);
            isDead = true;
            enemySpawner.enemyCount--;
        }
        if (collision.gameObject.tag.Equals("chicken") || collision.gameObject.tag.Equals("meteor") || collision.gameObject.tag.Equals("Player"))
        {
            animator.SetBool("isDead", true);
            isDead = true;
            enemySpawner.enemyCount--;
        }
    }
}
