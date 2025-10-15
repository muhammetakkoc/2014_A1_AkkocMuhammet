using UnityEngine;

public class CarMultiSpawner : MonoBehaviour
{
    [Header("Car Prefabs ")]
    public GameObject[] carPrefabs;

    [Header("Spawn Areas")]
    public Transform[] spawnAreas;

    [Header("Car Settings")]
    public float spawnInterval = 1.5f;
    public Vector2 speedRange = new Vector2(3f, 8f);

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnCar();
        }
    }

    void SpawnCar()
    {
        if (carPrefabs.Length == 0 || spawnAreas.Length == 0) return;

        
        GameObject prefab = carPrefabs[Random.Range(0, carPrefabs.Length)];

        
        Transform area = spawnAreas[Random.Range(0, spawnAreas.Length)];

        
        Vector3 pos = new Vector3(
            area.position.x + Random.Range(-1f, 1f),
            area.position.y + Random.Range(-1f, 1f),
            0f
        );

        
        GameObject car = Instantiate(prefab, pos, Quaternion.identity);
        CarMover mover = car.GetComponent<CarMover>();
        if (mover != null)
        {
            mover.speed = Random.Range(speedRange.x, speedRange.y);
        }
    }
}
