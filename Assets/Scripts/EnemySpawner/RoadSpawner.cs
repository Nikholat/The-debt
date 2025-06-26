using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float roadLength;
    private GameObject enemy;

    private void Start()
    {
        enemy = Instantiate(enemies[Random.Range(0, enemies.Count - 1)], transform.position, Quaternion.identity);
    }

    public void Spawn()
    {
        Vector2 position = new Vector2(enemy.transform.position.x + roadLength, enemy.transform.position.y);

        enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], position, Quaternion.identity);
    }
}
