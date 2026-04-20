using UnityEngine;

public class JellyfishSpawner : MonoBehaviour
{
    public GameObject jellyfishPrefab;
    public float spawnInterval = 2f;
    public float moveSpeed = 2f;
    public float spawnY = -4f;      // borda inferior
    public float destroyY = 6f;     // borda superior (some se não coletada)
    public float minX = -3.5f;      // limite esquerdo da tela
    public float maxX = 3.5f;       // limite direito da tela

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnJellyfish();
        }
    }

    void SpawnJellyfish()
    {
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0);
        GameObject jelly = Instantiate(jellyfishPrefab, pos, Quaternion.identity);
        jelly.GetComponent<JellyfishMove>().speed = moveSpeed;
    }
}