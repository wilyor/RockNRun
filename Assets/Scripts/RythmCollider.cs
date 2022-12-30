using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmCollider : MonoBehaviour
{
    public float collisionRadius;
    public KeyCode input;
    Animator anim;
    public float distanceForPerfect = 0.5f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        CheckInput();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collisionRadius);
    }

    /// <summary>
    /// check button pressed
    /// </summary>
    void CheckInput()
    {
        if (Input.GetKeyDown(input)) ActivateCollider();
    }

    /// <summary>
    /// Activates the collider, triggers activation animation
    /// </summary>
    void ActivateCollider()
    {
        anim.SetTrigger("Active");
        CheckCollideWithEnemy();
    }

    /// <summary>
    /// Check if an enemy has collider
    /// </summary>
    void CheckCollideWithEnemy()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, collisionRadius);
        if (enemy)
        {
            enemy.GetComponent<Enemy>().DestroyOnCollision(checkAccuracy(enemy.transform));
        }
    }

    public Accuracy checkAccuracy(Transform enemy)
    {
        if(Vector2.Distance(enemy.position, transform.position) <= distanceForPerfect)
        {
            return Accuracy.Perfect;
        }
        return Accuracy.Great;
    }
}
