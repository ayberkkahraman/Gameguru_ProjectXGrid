using UnityEngine;
using UnityEngine.Serialization;

namespace Project._Scripts.GameCore.GridSystem.ScreenHandler
{
  public class Test : MonoBehaviour
  {
    public GameObject gridPrefab; // Kare sprite'ı temsil eden prefab
    public int gridSize = 15;     // n değeri

    void Start()
    {
      GenerateGrid();
    }

    void GenerateGrid()
    {
      Camera mainCamera = Camera.main;
      float screenHeight = 2f * mainCamera.orthographicSize;
      float screenWidth = screenHeight * mainCamera.aspect;
      
      Debug.Log(screenHeight);
      Debug.Log(screenWidth);

      float cellSize = Mathf.Min(screenWidth, screenHeight) / gridSize;

      Vector3 startPosition = new Vector3(-screenWidth / 2 + cellSize / 2, screenHeight / 2 - cellSize / 2, 0);

      for (int i = 0; i < gridSize; i++)
      {
        for (int j = 0; j < gridSize; j++)
        {
          Vector3 position = new Vector3(startPosition.x + j * cellSize, startPosition.y - i * cellSize, 0);
          GameObject gridCell = Instantiate(gridPrefab, position, Quaternion.identity);
          gridCell.transform.localScale = new Vector3(cellSize, cellSize, 1);
        }
      }
    }
  }
}
