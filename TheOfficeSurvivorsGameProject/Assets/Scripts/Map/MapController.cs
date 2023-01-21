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

    public void OnPlayerMovement(InputAction.CallbackContext value)
    {
        if (!currentChunk)
        {
            return;
        }

        float x = value.ReadValue<Vector2>().x;
        float y = value.ReadValue<Vector2>().y;

        if (x > 0 && y == 0)
        {
            // moving right
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                // there isn’t any chunk on that specific point that we overlapped
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }else if(x < 0 && y == 0)
        {
            // moving left
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                // there isn’t any chunk on that specific point that we overlapped
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }else if(y > 0 && x == 0)
        {
            // moving up
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }else if(y < 0 && x == 0)
        {
            //moving down
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }else if(x > 0 && y > 0)
        {
            // moving right up
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }
        }
        else if (x > 0 && y < 0)
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
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);

    }
}
