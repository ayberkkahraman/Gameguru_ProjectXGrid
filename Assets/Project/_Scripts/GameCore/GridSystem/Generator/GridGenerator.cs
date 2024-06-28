using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project._Scripts.GameCore.GridSystem.Generator
{
  public class GridGenerator : MonoBehaviour
  {
    private Camera _camera;
    public Grid GridPrefab;
    [SerializeField][Range(3, 15)] private int GridSize = 5;
    [SerializeField][Range(.05f, .1f)] private float GridOffset = .05f;
    [SerializeField][Range(.1f, 1f)] private float BorderOffset = .5f;

    private Vector2 _screenBounds;
    private Vector2 _gameScreenBounds;

    public List<Grid> Grids;
    private void Awake()
    {
      InitializeComponents();
      SetBounds();
      StartCoroutine(GenerateGrid());
    }
    int i = 0;
    [ContextMenu("Generate")]
    IEnumerator GenerateGrid()
    {
      Grids = new List<Grid>();
      
      float minBorder = Mathf.Min(_gameScreenBounds.x, _gameScreenBounds.y);
      float defaultCellSize = GridPrefab.transform.localScale.x;
      float cellSize = (minBorder - ((GridSize-1) * GridOffset)) / GridSize;

      // var targetCellSize = cellSize > defaultCellSize ? defaultCellSize : cellSize;

      
   
      for (int x = 0; x < GridSize; x++)
      {
        for (int y = 0; y < GridSize; y++)
        {
          var positionX = transform.position.x + (x * (cellSize + GridOffset));
          var positionY = transform.position.y + (y * (cellSize + GridOffset));
          SpawnGridElement(new Vector2(positionX, positionY), cellSize*Vector3.one);
          i++;
        }
      }
      
      transform.position -= new Vector3(Grids[^1].transform.position.x, Grids[^1].transform.position.y)/2;
      Grids.ForEach(x => x.Initialize(Grids, GridOffset));
      yield return null;
    }

    private void InitializeComponents()
    {
      _camera = Camera.main;
    }

    private void SetBounds()
    {
      _screenBounds = (_camera!.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2);
      _gameScreenBounds = _screenBounds - (Vector2.one * BorderOffset * 2);
    }

    private void SpawnGridElement(Vector2 position, Vector3 scale)
    {
      Grid grid = Instantiate(GridPrefab, position, Quaternion.identity, transform);
      grid.transform.localScale = scale;
      grid.name = i.ToString();
      Grids.Add(grid);
    }
  }
}
