using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab; // حجر أو نيزك
    public Transform player;
    public float spawnRadius = 10f; // نصف القطر حول اللاعب
    public float spawnHeight = 15f; // ارتفاع ظهور النيازك
    public float spawnInterval = 2f; // كل كم ثانية نيزك جديد

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnMeteor();
            timer = 0f;
        }
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = player.position + Random.onUnitSphere * spawnRadius;
        spawnPosition.y = player.position.y + spawnHeight; // فوق اللاعب بمسافة

        // حافظي على نفس مستوى الأرض
        spawnPosition.y = player.position.y + spawnHeight;

        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }
}
