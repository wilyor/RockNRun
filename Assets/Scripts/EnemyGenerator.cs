using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public Transform enemyInitialPosUp;
    public Transform enemyInitialPosDown;

    public void GenerateEnemy(enemyType enemyT, Transform enemyPosition)
    {
        Enemy newEnemy = EnemyPool.instance.RequestEnemy(enemyT);
        newEnemy.transform.position = enemyPosition.position;
        newEnemy.speedMovement = 6;
    }

    public void SelectEnemy(string enemy)
    {
        switch (enemy)
        {
            case "u":
                GenerateEnemy(enemyType.up, enemyInitialPosUp);
                break;
            case "d":
                GenerateEnemy(enemyType.down, enemyInitialPosDown);
                break;
            default:
                GenerateEnemy(enemyType.up, enemyInitialPosUp);
                break;
        }
    }
}
