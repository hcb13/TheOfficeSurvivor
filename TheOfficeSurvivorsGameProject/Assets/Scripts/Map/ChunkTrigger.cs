using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject targetMap;

    private MapController mapController;

    private void Awake()
    {
        mapController = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mapController.CurrentChunk = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(mapController.CurrentChunk == targetMap)
            {
                mapController.CurrentChunk = null;
            }
        }
    }

}
