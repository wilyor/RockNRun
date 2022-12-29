using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyType
{
   up,
   down
}

public class EnemyPool : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefabUp;
    [SerializeField] Enemy enemyPrefabDown;

    private List<Enemy> enemyPoolUp;
    private List<Enemy> enemyPoolDown;

    public int poolSize = 10;
    public static EnemyPool instance;

    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        FillPool();
    }

    /// <summary>
    /// Fills the pools with enemies
    /// </summary>
    void FillPool()
    {
        enemyPoolUp = new List<Enemy>();
        enemyPoolDown = new List<Enemy>();
        for (int i = 0; i < poolSize; i++)
        {
            AddEnemyToPool(enemyPrefabUp, enemyPoolUp);
            AddEnemyToPool(enemyPrefabDown, enemyPoolDown);
        }
    }

    void AddEnemyToPool(Enemy enemyType, List<Enemy> enemyPool)
    {
        Enemy enemyUp = Instantiate(enemyType, transform);
        enemyPool.Add(enemyUp);
        enemyUp.gameObject.SetActive(false);
    }

    public Enemy RequestEnemy(enemyType enemyToGenerate = enemyType.up)
    {
        List<Enemy> enemyPool = GetEnemyPool(enemyToGenerate);

        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].gameObject.activeSelf)
            {
                enemyPool[i].gameObject.SetActive(true);
                return enemyPool[i];
            }
        }
        return null;
    }

    public List<Enemy> GetEnemyPool(enemyType enemyToGenerate = enemyType.up)
    {
        switch (enemyToGenerate)
        {
            case enemyType.up:
                return enemyPoolUp;
            case enemyType.down:
                return enemyPoolDown;
            default:
                return enemyPoolUp;
        }
    }
}
