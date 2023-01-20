using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapController : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> terrainChunks;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float checkerRadius;

    [SerializeField]
    private Vector3 noTerrainPosition;

    [SerializeField]
    private LayerMask terrainMask;

    [SerializeField]
    private float length = 20;

    public void OnPlayerMovement(InputAction.CallbackContext value)
    {
        float x = value.ReadValue<Vector2>().x;
        float y = value.ReadValue<Vector2>().y;

        if (x > 0 && y == 0)
        {
            // moving right
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(length, 0, 0), checkerRadius, terrainMask))
            {
                // there isn’t any chunk on that specific point that we overlapped
                noTerrainPosition = player.transform.position + new Vector3(length, 0, 0);
                SpawnChunk();
            }
        }else if(x < 0 && y == 0)
        {
            // moving left
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-1 * length, 0, 0), checkerRadius, terrainMask))
            {
                // there isn’t any chunk on that specific point that we overlapped
                noTerrainPosition = player.transform.position + new Vector3(-1 * length, 0, 0);
                SpawnChunk();
            }
        }else if(y > 0 && x == 0)
        {
            // moving up
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, length, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, length, 0);
                SpawnChunk();
            }
        }else if(y < 0 && x == 0)
        {
            //moving down
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, -1 *length, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, -1 * length, 0);
                SpawnChunk();
            }
        }else if(x > 0 && y > 0)
        {
            // moving right up
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(length, length, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(length, length, 0);
                SpawnChunk();
            }
        }
        else if (x > 0 && y < 0)
        {
            // moving right down
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(length, -1 * length, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(length, -1 * length, 0);
                SpawnChunk();
            }
        }
        else if (x < 0 && y > 0)
        {
            // moving left up
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-1 * length, length, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-1 * length, length, 0);
                SpawnChunk();
            }
        }
        else if (x < 0 && y < 0)
        {
            // moving left down
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-1 * length, -1 * length, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-1 * length, -1 * length, 0);
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
