using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] m_asteroidPrefabs;
    [SerializeField] float m_secondsBetweenAsteroids = 1.5f;
    [SerializeField] Vector2 m_forceRange;

    private float m_timer;
    private Camera m_mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
    }

    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer < 0)
        {
            SpawnAsteroid();
            m_timer += m_secondsBetweenAsteroids;
        }
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);
        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
        case 0: // Left
            spawnPoint.x = 0;
            spawnPoint.y = Random.value;
            direction = new Vector2(1f, Random.Range(-1f, 1f));
            break;
        case 1: // Right
            spawnPoint.x = 1f;
            spawnPoint.y = Random.value;
            direction = new Vector2(-1f, Random.Range(-1f, 1f));        
            break;
        case 2: // Bottom
            spawnPoint.y = 0;
            spawnPoint.x = Random.value;
            direction = new Vector2(Random.Range(-1f, 1f), 1f);
            break;
        case 3: // Top
            spawnPoint.y = 1;
            spawnPoint.x = Random.value;
            direction = new Vector2(Random.Range(-1f, 1f), -1f);        
            break;
        }

        Vector3 worldSpawnPoint = m_mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroid = m_asteroidPrefabs[Random.Range(0, m_asteroidPrefabs.Length)];
        GameObject asteroidInstance = Instantiate(selectedAsteroid, worldSpawnPoint, Quaternion.Euler(0, 0, Random.Range(0, 360)));

        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(m_forceRange.x, m_forceRange.y);
    }
}
