using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapController : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> terrainChunks;

    [SerializeField]
    private float checkerRadius;

    [SerializeField]
    private Vector3 noTerrainPosition;

    [SerializeField]
    private LayerMask terrainMask;


    [SerializeField]
    private GameObject currentChunk;
    public GameObject CurrentChunk
    {
        get { return currentChunk; }
        set { currentChunk = value; }
    }

    private float x;
    private float y;

    [Header("Optimization")]
    [SerializeField]
    private List<GameObject> spawnedChunks;
    private GameObject latestChunk;
    
    [SerializeField]
    private float maxDistanceFromChunks; //Must be greater than the length and width of the tilemap

    private float currenteDistanceFromChunks;

    [SerializeField]
    private float optimizerCooldownDuration;
    private float optimizerCooldown;


    private void Start()
    {
        optimizerCooldown = optimizerCooldownDuration;
    }

    public void OnPlayerMovement(InputAction.CallbackContext value)
    {
        x = value.ReadValue<Vector2>().x;
        y = value.ReadValue<Vector2>().y;
        
    }

    private void Update()
    {
        optimizerCooldown -= Time.deltaTime;

        if(optimizerCooldown < 0f) {

            optimizerCooldown = optimizerCooldownDuration;
        }
        else
        {
            return;
        }

        ChunkOptimizer();
    }

    private void FixedUpdate()
    {
        CheckSpawnChunk();        
    }

    private void CheckSpawnChunk()
    {
        if (!currentChunk)
        {
            return;
        }

        if (x > 0 && y == 0)
        {
            // moving right
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                // there isn’t any chunk on that specific point that we overlapped
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();

                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();

                noTerrainPosition = currentChunk.transform.Find("RightDown").position;
                SpawnChunk();
            }
        }
        else if (x < 0 && y == 0)
        {
            // moving left
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                // there isn’t any chunk on that specific point that we overlapped
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();

                noTerrainPosition = currentChunk.transform.Find("LeftUp").position;
                SpawnChunk();

                noTerrainPosition = currentChunk.transform.Find("LeftDown").position;
                SpawnChunk();
            }
        }
        else if (y > 0 && x == 0)
        {
            // moving up
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();

                noTerrainPosition = currentChunk.transform.Find("LeftUp").position;
                SpawnChunk();

                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }
        }
        else if (y < 0 && x == 0)
        {
            //moving down
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();

                noTerrainPosition = currentChunk.transform.Find("LeftDown").position;
                SpawnChunk();

                noTerrainPosition = currentChunk.transform.Find("RightDown").position;
                SpawnChunk();
            }
        
        }else if (x > 0 && y > 0)
        {
            // moving right up
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }

        }else if (x > 0 && y < 0)
        {
            // moving right down
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightDown").position;
                SpawnChunk();
            }
        }
        else if (x < 0 && y > 0)
        {
            // moving left up
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftUp").position;
                SpawnChunk();
            }
        }
        else if (x < 0 && y < 0)
        {
            // moving left down
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftDown").position;
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    private void ChunkOptimizer()
    {
        foreach(GameObject chunk in spawnedChunks)
        {
            // calculate the distance between player and the chunk
            currenteDistanceFromChunks = Vector2.Distance(transform.position, chunk.transform.position);

            if(currenteDistanceFromChunks > maxDistanceFromChunks)
            {
                chunk.SetActive(false);
            }
            else{
                chunk.SetActive(true);
            }

        }
    }
}
