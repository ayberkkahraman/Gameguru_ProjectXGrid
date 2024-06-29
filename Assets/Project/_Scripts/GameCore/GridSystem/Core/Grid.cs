using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project._Scripts.GameCore.GridSystem
{
  public class Grid : MonoBehaviour
  {
    private GameObject _selectionMark;

    public delegate void OnSelected();
    public OnSelected OnSelectedHandler;
    
    public delegate void OnDeSelected();
    public OnDeSelected OnDeSelectedHandler;

    public List<Grid> NeighbourGrids = new();
    public List<Grid> ActiveGrids = new();
    public bool IsActive { get; set; }
    
    private void Awake() => InitializeComponents();
    private void OnEnable()
    {
      OnSelectedHandler += Select;
      OnDeSelectedHandler += DeSelect;
    }
    public void OnDisable()
    {
      OnSelectedHandler -= Select;
      OnDeSelectedHandler -= DeSelect;
    }
    private void InitializeComponents() => _selectionMark = transform.GetChild(0).gameObject;
    public void Initialize(List<Grid> allGrids, float gridOffset) => FindNeighbours(allGrids, gridOffset);
    private void Select()
    {
      IsActive = true;
      _selectionMark.SetActive(true);
      
      NeighbourGrids.ForEach(x => x.ActiveGrids.Add(this));

      var nodes = GridContainer.GridContainer.CheckForGrids(ActiveGrids);
      int countOfLinkedNodes = nodes.Count;
      Debug.Log(countOfLinkedNodes);
      
      if(countOfLinkedNodes < 3) return;

      nodes.ToList().ForEach(x => x.OnDeSelectedHandler());
    }
    private void DeSelect()
    {
      IsActive = false;
      _selectionMark.SetActive(false);
      
      NeighbourGrids.ForEach(x => x.ActiveGrids.Remove(this));
    }

    private void OnMouseDown()
    {
      OnSelectedHandler();
    }
    
    public void FindNeighbours(List<Grid> allGrids, float gridOffset)
    {
      float tolerance = 0.01f;

      for (var i = 0; i < allGrids.Count; i++)
      {
        var otherGrid = allGrids[i];
        if (gameObject == otherGrid.gameObject) continue;

        Vector2 direction = otherGrid.transform.position - transform.position;
        float distance = direction.magnitude;
        float expectedDistance = transform.localScale.x + gridOffset;

        if (Mathf.Abs(distance - expectedDistance) < tolerance)
        {
          NeighbourGrids.Add(otherGrid.GetComponent<Grid>());
        }
      }
    }
  }
}