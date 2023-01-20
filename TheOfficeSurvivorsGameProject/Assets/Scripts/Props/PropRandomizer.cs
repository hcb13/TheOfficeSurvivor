using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [Header("Spawn Points")]
    [SerializeField]
    private List<GameObject> propSpawnPoints;

    [Header("Props Prefabs")]
    [SerializeField]
    private List<GameObject> propPrefabs;

    private void Start()
    {
        SpawnProps();
    }

    private void SpawnProps()
    {
        foreach(GameObject sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity, sp.transform);

        }
    }
}
