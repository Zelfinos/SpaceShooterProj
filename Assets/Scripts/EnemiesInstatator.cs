
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesInstatator : MonoBehaviour
{
    //[SerializeField]
    //Boolean drawGizmo = false;
    [SerializeField]
    private Vector2 SpawnSurface;
    [SerializeField]
    private Transform RootParent;
    [SerializeField]
    private GameObject EnemyType1, EnemyType2, EnemyType3;
    [SerializeField]
    private Transform SPoint;
    [SerializeField]
    private float SpawnTimer1 = 0f;
    [SerializeField]
    private float SpawnTimer2 = 0f;
    [SerializeField]
    private float SpawnTimer3 = 0f;
    [SerializeField]
    private GameObject gameControl;

    private float SpawnTime1;
    private float SpawnTime2;
    private float SpawnTime3;

    private int score;

    [SerializeField]
    private int minScoreEnemy1;
    [SerializeField]
    private int minScoreEnemy2;
    [SerializeField]
    private int minScoreEnemy3;
    

    private void Start()
    {
        score = gameControl.GetComponent<ScoreControl>().score;
        SpawnSurface = SPoint.GetComponent<Renderer>().bounds.size;
    }

    void Update()
    {
        score = gameControl.GetComponent<ScoreControl>().score;
        if (Time.time > SpawnTime1 && score >= minScoreEnemy1)
        {
            OnSpawnEnemy1();
        }
        if (Time.time > SpawnTime2 && score >= minScoreEnemy2)
        {
            OnSpawnEnemy2();
        }
        if (Time.time > SpawnTime3 && score >= minScoreEnemy3)
        {
            OnSpawnEnemy3();
        }
    }

    private void OnSpawnEnemy1()
    {
        var spawnPosition = new Vector3(Random.Range(SpawnSurface.x / 2, -SpawnSurface.x / 2), Random.Range(SpawnSurface.y / 2, -SpawnSurface.y / 2));
        SpawnTime1 = Time.time + SpawnTimer1;
        GameObject enemy1 = Instantiate(EnemyType1, spawnPosition + SPoint.position, Quaternion.identity);
        enemy1.transform.parent = RootParent;
    }

    private void OnSpawnEnemy2()
    {
        var spawnPosition = new Vector3(Random.Range(SpawnSurface.x / 2, -SpawnSurface.x / 2), Random.Range(SpawnSurface.y / 2, -SpawnSurface.y / 2));
        SpawnTime2 = Time.time + SpawnTimer2;
        GameObject enemy2 = Instantiate(EnemyType2, spawnPosition + SPoint.position, Quaternion.identity);
        enemy2.transform.parent = RootParent;
    }

    private void OnSpawnEnemy3()
    {
        var spawnPosition = new Vector3(Random.Range(SpawnSurface.x / 2, -SpawnSurface.x / 2), Random.Range(SpawnSurface.y / 2, -SpawnSurface.y / 2));
        SpawnTime3 = Time.time + SpawnTimer3;
        GameObject enemy3 = Instantiate(EnemyType3, spawnPosition + SPoint.position, Quaternion.identity);
        enemy3.transform.parent = RootParent;
    }


    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(SPoint.position, surface); 
    }
    */
}
