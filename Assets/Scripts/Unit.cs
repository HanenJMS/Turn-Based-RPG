using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    GridPosition currentGridPosition;
    [SerializeField] Inventory inventory;
    public Action OnUnitSelected;
    List<BaseAction> actions;
    bool isSelected = false;
    private void Awake()
    {
        actions = new List<BaseAction>(GetComponents<BaseAction>());
        inventory = GetComponent<Inventory>();

    }
    private void Start()
    {
        currentGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(currentGridPosition, this);

    }
    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != currentGridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, currentGridPosition, newGridPosition);
            currentGridPosition = newGridPosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Inventory : " + inventory.GetItemList().Count);
            if (inventory.GetItemList().Count > 0)
                Instantiate(inventory.GetItemList()[0].item.prefab, MouseWorld.GetMousePosition(), Quaternion.identity);
            Debug.Log("Inventory : " + inventory.GetItemList()[0].quantity);
        }
    }
    public List<BaseAction> GetActionList()
    {
        return actions;
    }
    public GridPosition GetUnitGridPosition()
    {
        return currentGridPosition;
    }
    public BaseAction GetMoveAction()
    {
        BaseAction moveAction = null;
        if (actions.Count <= 0)
        {
            Debug.Log($"Missing MoveAction on {this.transform.name} on {this.transform.position}");
            return moveAction;
        }
        foreach (BaseAction action in actions)
        {
            if (action is MoveAction)
            {
                moveAction = action;
                return action;
            }
        }
        return moveAction;
    }

    public void MoveTo(GridPosition destination)
    {
        GetMoveAction().Execute(destination);
    }
    public void SetIsSelected(bool isSelected)
    {
        this.isSelected = isSelected;
        OnUnitSelected?.Invoke();
    }
    public bool IsSelected()
    {
        return isSelected;
    }
    public Inventory GetInventory()
    {
        return inventory;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out Item item))
        {
            inventory.PickUpItem(item);
        }
        inventory.GetItemList();
    }
}
