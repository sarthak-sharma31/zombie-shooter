using System.Collections;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 3.0f;
    public float stoppingDistance = 1.5f;
    public float attackDistance = 1.5f;
    public float attackRate = 1.0f; // Time between attacks in seconds
    public float attackDamage = 10f; // Damage dealt per attack

    private bool canWalk = false;
    private bool isReached = false;
    private Animator animator;
    private PlayerHealth playerHealth;
    private float nextTimeToAttack = 0f;

    void Start()
    {
        canWalk = false;
        isReached = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Spawned", true);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        StartCoroutine(StartWalking());
    }

    IEnumerator StartWalking()
    {
        yield return new WaitForSeconds(2f); // Wait for the spawn interval
        canWalk = true;
    }

    void Update()
    {
        if (canWalk)
        {
            // Calculate the direction towards the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Calculate the distance to the player
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > stoppingDistance)
            {
                // Move towards the player
                transform.position += direction * speed * Time.deltaTime;

                // Rotate to face the player
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);

                // Set animator parameters
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
                isReached = false;
            }
            else if (distance <= attackDistance)
            {
                // Attack the player
                isReached = true;
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);

                if (Time.time >= nextTimeToAttack)
                {
                    Attack();
                    nextTimeToAttack = Time.time + attackRate;
                }
            }
            else
            {
                // Stop moving
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", false);
            }
        }
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
