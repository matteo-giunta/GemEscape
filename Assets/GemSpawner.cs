using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab;

    public int baseGemCount = 1;
    public int maxGemCount = 5;

    public float spawnRangeX = 7f;
    public float spawnRangeY = 4f;

    void Start()
    {
        SpawnGems(GetTargetGemCount());
    }

    void Update()
    {
        int currentGems = GameObject.FindGameObjectsWithTag("Gem").Length;
        int targetGems = GetTargetGemCount();

        if (currentGems < targetGems)
        {
            SpawnGems(targetGems - currentGems);
        }
    }

    int GetTargetGemCount()
    {
        int target = baseGemCount + (GameManager.instance.score / 5);
        return Mathf.Min(target, maxGemCount);
    }

    void SpawnGems(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 spawnPos = new Vector2(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(-spawnRangeY, spawnRangeY)
            );

            Instantiate(gemPrefab, spawnPos, Quaternion.identity);
        }
    }
}