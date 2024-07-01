using System.Collections.Generic;
using Project._Scripts.GameCore.GridSystem.Core;
using UnityEngine;

namespace Project._Scripts.GameCore.GridSystem.Generator
{
  [DefaultExecutionOrder(650)]
  public class GridGenerator : MonoBehaviour
  {
    #region Components
    private Camera _camera;
    public Grid GridPrefab;
    #endregion

    #region Fields
    private Vector2 _screenBounds;
    private Vector2 _gameScreenBounds;
    
    public static GridData GridData { get; set; }

    public List<Grid> Grids { get; set; }
    #endregion

    #region Unity Functions
    private void Awake()
    {
      Grids = new List<Grid>();
      GridData = new GridData(5, .05f, .25f);
      InitializeComponents();
      SetBounds();
    }
    #endregion

    #region Initializaiton
    private void InitializeComponents() => _camera = Camera.main;
    #endregion

    #region Generation
    /// <summary>
    /// Handles the generation of the grid
    /// </summary>
    /// <param name="gridSize"></param>
    /// <param name="gridOffset"></param>
    /// <param name="borderOffset"></param>
    public void GenerateGrid(int gridSize, float gridOffset, float borderOffset)
    {
      float minBorder = Mathf.Min(_gameScreenBounds.x, _gameScreenBounds.y);
      float cellSize = (minBorder - ((gridSize-1) * gridOffset)) / gridSize;
      
      var positionOffsetX = cellSize/2 - _gameScreenBounds.x/2;
      var positionOffsetY = -cellSize/2 + _gameScreenBounds.y/2;
      
      for (int x = 0; x < gridSize; x++)
      {
        for (int y = 0; y < gridSize; y++)
        {
          var positionX = positionOffsetX + (x * (cellSize + gridOffset));
          var positionY = positionOffsetY - (y * (cellSize + gridOffset));
          SpawnGridElement(new Vector2(positionX, positionY), cellSize*Vector3.one);
        }
      }

      Grids.ForEach(x => x.Initialize(Grids, gridOffset));
    }
    
    /// <summary>
    /// Spawns a grid element with desired position & scale
    /// </summary>
    /// <param name="position"></param>
    /// <param name="scale"></param>
    private void SpawnGridElement(Vector2 position, Vector3 scale)
    {
      Grid grid = Instantiate(GridPrefab, position, Quaternion.identity, transform);
      grid.transform.localScale = scale;
      Grids.Add(grid);
    }
    
    /// <summary>
    /// Allows the generate grid with a UI Interaction
    /// </summary>
    public void UIF_GenerateGrid()
    {
      Grids.ForEach(x => Destroy(x.gameObject));
      Grids.Clear();

      SetBounds();
      GenerateGrid(GridData.GridSize, GridData.GridOffset, GridData.BorderOffset);
    }
    
    /// <summary>
    /// Sets the bounds of the game screen
    /// </summary>
    private void SetBounds()
    {
      _screenBounds = (_camera!.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2);
      _gameScreenBounds = _screenBounds - (Vector2.one * GridData.BorderOffset * 2);
    }
    #endregion
  }
}
