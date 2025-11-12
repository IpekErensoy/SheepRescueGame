using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public bool canSpawn = true; // 1
    public GameObject sheepPrefab; // 2
    public List<Transform> sheepSpawnPositions = new List<Transform>(); // 3
    public float timeBetweenSpawns; // 4
    private List<GameObject> sheepList = new List<GameObject>(); // 5

private void SpawnSheep()
{
    Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
    GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
    sheepList.Add(sheep);
    sheep.GetComponent<Sheep>().SetSpawner(this);

    if (Random.value < 0.2f)
    {
        Renderer sheepRenderer = sheep.GetComponentInChildren<Renderer>();
        if (sheepRenderer != null)
        {
            sheepRenderer.material.color = new Color(1f, 0.6f, 0.8f); // pembe ton
        }

        sheep.GetComponent<Sheep>().isPink = true;
    }
}



    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn) // 2
        {
            SpawnSheep(); // 3
            yield return new WaitForSeconds(timeBetweenSpawns); // 4
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }
    
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in new List<GameObject>(sheepList))
        {
            Destroy(sheep);
        }
        sheepList.Clear();
    }



    void Start()
    {
        StartCoroutine(SpawnRoutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
