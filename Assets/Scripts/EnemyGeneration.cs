using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField]
    int enemyCount;
    [SerializeField]
    float spawnRange;
    [SerializeField]
    GameObject enemyGO;


    private List<Vector3> enemiesPositions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GeneratingEnememies());
    }

    IEnumerator GeneratingEnememies()
    {
        Vector3 pointInRect;
        for (int i = 0; i < enemyCount; i++)
        {
            enemiesPositions.Add(Vector3.zero);

            pointInRect = getRandomVector3();
            while (PosCanBeAdded(pointInRect)) //!enemiesPositions.Contains(pointInRect) ||
            {
                pointInRect = getRandomVector3();
            }

            enemiesPositions.Add(pointInRect);
            var enemy = GameObject.Instantiate(enemyGO, pointInRect, Quaternion.identity);
            enemy.gameObject.name = "Ball" + UnityEngine.Random.Range(2, 50);
        }
        yield return null;
    }

    bool PosCanBeAdded(Vector3 generatedpos)
    {
        foreach (var enemy in enemiesPositions)
        {
            if ((enemy - generatedpos).magnitude < 8f || generatedpos.Equals(Vector3.zero))
            {
                return false;
            }
        }
        //print(generatedpos);
        return true;
    }

    Vector3 getRandomVector3()
    {
        Vector3 pointInRect = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0,
            Random.Range(-spawnRange, spawnRange)
            );
        return pointInRect;
    }
}
