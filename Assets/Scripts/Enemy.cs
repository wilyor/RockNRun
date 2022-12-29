using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedMovement = 10;
    public int score = 1;

    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.left * speedMovement * Time.deltaTime);
    }

    public virtual void DestroyMiss()
    {
        gameObject.SetActive(false);
        SendInfoToScore(Accuracy.Miss, 0);
    }

    public virtual void DestroyOnCollision(Accuracy accuracy)
    {
        gameObject.SetActive(false);
        SendInfoToScore(accuracy, score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destructor"))
        {
            DestroyMiss();
        }
    }

    void SendInfoToScore(Accuracy accuracy, int score = 0)
    {
        ScoreManager.instance.ReceiveScore(accuracy, score);
    }
}
