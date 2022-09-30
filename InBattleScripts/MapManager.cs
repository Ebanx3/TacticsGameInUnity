using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }

    public OverlayTile overlayTilePrefab;
    public GameObject overlayContainer;

    public Dictionary<Vector2Int, OverlayTile> map;

    public List<OverlayTile> availableStartingTilesP1 = new List<OverlayTile>();
    public List<OverlayTile> availableStartingTilesP2 = new List<OverlayTile>();

    BoundsInt bounds;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        var tileMap = gameObject.GetComponentInChildren<Tilemap>();
        map = new Dictionary<Vector2Int, OverlayTile>();
        bounds = tileMap.cellBounds;

        for (int z = bounds.max.z; z >= bounds.min.z; z--)
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
                for (int x = bounds.min.x; x < bounds.max.x; x++)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    var tileKey = new Vector2Int(x, y);
                    if (tileMap.HasTile(tileLocation))
                    {
                        var overlayTile = Instantiate(overlayTilePrefab, overlayContainer.transform);
                        var cellWorldPosition = tileMap.GetCellCenterWorld(tileLocation);

                        overlayTile.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, cellWorldPosition.z + 1);
                        overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder;
                        overlayTile.gridLocation = tileLocation;
                        map.Add(tileKey, overlayTile);
                    }
                }
            }
        }

    }

    public List<OverlayTile> GetNeighbourTiles(OverlayTile current, List<OverlayTile> searchableTiles)
    {
        Dictionary<Vector2Int, OverlayTile> tileToSearch = new Dictionary<Vector2Int, OverlayTile>();

        if (searchableTiles.Count > 0)
        {
            foreach (var item in searchableTiles)
            {
                tileToSearch.Add(item.gridLocation2d, item);
            }
        }
        else
        {
            tileToSearch = map;
        }

        List<OverlayTile> neighbours = new List<OverlayTile>();

        Vector2Int locationToCheck = new Vector2Int(current.gridLocation.x, current.gridLocation.y + 1);
        if (tileToSearch.ContainsKey(locationToCheck))
        {
            if (Mathf.Abs(current.gridLocation.z - tileToSearch[locationToCheck].gridLocation.z) <= 1)
                neighbours.Add(tileToSearch[locationToCheck]);
        }

        locationToCheck = new Vector2Int(current.gridLocation.x, current.gridLocation.y - 1);
        if (tileToSearch.ContainsKey(locationToCheck))
        {
            if (Mathf.Abs(current.gridLocation.z - tileToSearch[locationToCheck].gridLocation.z) <= 1)
                neighbours.Add(tileToSearch[locationToCheck]);
        }

        locationToCheck = new Vector2Int(current.gridLocation.x + 1, current.gridLocation.y);
        if (tileToSearch.ContainsKey(locationToCheck))
        {
            if (Mathf.Abs(current.gridLocation.z - tileToSearch[locationToCheck].gridLocation.z) <= 1)
                neighbours.Add(tileToSearch[locationToCheck]);
        }

        locationToCheck = new Vector2Int(current.gridLocation.x - 1, current.gridLocation.y);
        if (tileToSearch.ContainsKey(locationToCheck))
        {
            if (Mathf.Abs(current.gridLocation.z - tileToSearch[locationToCheck].gridLocation.z) <= 1)
                neighbours.Add(tileToSearch[locationToCheck]);
        }

        return neighbours;
    }

    public void SetStartingTilesVIsible(int playerNmb)
    {
        if (playerNmb == 1)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = -15; y < -2; y++)
                {
                    Vector2Int tilePosition = new Vector2Int(-19 + x, y);
                    if (map.ContainsKey(tilePosition))
                    {
                        map[tilePosition].ShowTile();
                        availableStartingTilesP1.Add(map[tilePosition]);
                    }
                }
            }
        }
        else
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = -15; y < -2; y++)
                {
                    Vector2Int tilePosition = new Vector2Int(0 - x, y);
                    if (map.ContainsKey(tilePosition))
                    {
                        map[tilePosition].ShowTile();
                        availableStartingTilesP2.Add(map[tilePosition]);
                    }
                }
            }
        }
    }
}
