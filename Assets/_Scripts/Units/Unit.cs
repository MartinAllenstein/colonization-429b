using System;
using UnityEngine;

public enum UnitType
{
    Land,
    Naval
}
    
public enum UnitStatus
{
    None,
    OnBoard,
    Fortified,
    Clearing,
    Building
}

public class Unit : MonoBehaviour
{

    [SerializeField]
    protected string unitName;
    public string UnitName { get { return unitName; } }

    [SerializeField]
    protected UnitType unitType;
    public UnitType UnitType { get { return unitType; } }

    [SerializeField]
    protected UnitStatus unitStatus;
    public UnitStatus UnitStatus { get { return unitStatus; } set { unitStatus = value; } }

    [SerializeField]
    protected int strength;
    public int Strenght { get { return strength; } set { strength = value; } }

    [SerializeField]
    protected int movePoint;
    public int MovePoint { get { return movePoint; } set { movePoint = value; } }

    [SerializeField]
    protected int movePointMax;
    public int MovePointMax { get { return movePointMax; } }

    [SerializeField]
    protected Faction faction;
    public Faction Faction { get { return faction; } }

    [SerializeField]
    protected int visualRange;
    public int VisualRange { get { return visualRange; } }

    [SerializeField]
    private Vector2 curPos;
    public Vector2 CurPos { get { return curPos; } set { curPos = value; } }

    [SerializeField]
    protected Hex curHex;
    public Hex CurHex { get { return curHex; } set { curHex = value; } }

    [SerializeField]
    protected Hex targetHex;
    public Hex TargetHex { get { return targetHex; } set { targetHex = value; } }

    [SerializeField]
    protected bool isMoving = false;
    public bool IsMoving { get { return isMoving; } set { isMoving = value; } }

    [SerializeField]
    protected bool visible = false;
    public bool Visible { get { return visible; } set { visible = value; } }

    [Header("Unit")]
    [SerializeField]
    protected SpriteRenderer unitSprite;

    [Header("Flag")]
    [SerializeField]
    protected SpriteRenderer flagSprite;

    [Header("Border")]
    [SerializeField]
    protected SpriteRenderer borderSprite;

    [SerializeField]
    protected GameManager gameMgr;
    
    
    public void SetupPosition(Hex hex)
    {
        curHex = hex;
        curPos = hex.Pos;
    }

    protected virtual void Update()
    {
        if (isMoving == true)
        {
            MoveToHex();
        }
    }
    
    private void OnMouseDown()
    {
        //Debug.Log("Mouse Down");
        if (faction == gameMgr.PlayerFaction)
        {
            gameMgr.SelectPlayerUnit(this);
        }
    }
    
    public void ToggleBorder(bool flag, Color32 color)
    {
        borderSprite.gameObject.SetActive(flag);
        borderSprite.color = color;
    }

    
    public void ShowHideSprite(bool flag)
    {
        unitSprite.gameObject.SetActive(flag);
        flagSprite.gameObject.SetActive(flag);
    }

    public void SetUnitToFrontLayerOrder()
    {
        unitSprite.sortingOrder = 5;
        flagSprite.sortingOrder = 6;
    }

    
    public void SetUnitToNormalLayerOrder()
    {
        unitSprite.sortingOrder = 2;
        flagSprite.sortingOrder = 3;
    }
    
    public virtual void PrepareMoveToHex(Hex target) //Begin to move by RC or AI auto movement
    {
        //Debug.Log($"MoveCost-{target.MoveCost}");
        //Debug.Log($"UnitMovementP-{movePoint}");

        if (target.MoveCost > movePoint)
            return;

        isMoving = true;
        targetHex = target;
        //Debug.Log($"Target Pos:{targetHex.transform.position.x},{targetHex.transform.position.y}");

        if (faction == gameMgr.PlayerFaction)
            gameMgr.LeaveSeenFogAroundUnit(this);
    }

    
    protected virtual void StayOnHex(Hex targetHex)
    {
        isMoving = false;
        curHex = targetHex;
        targetHex = null;
        transform.position = curHex.transform.position; //confirm position to match this hex

        if (faction == gameMgr.PlayerFaction)
        {
            gameMgr.ClearDarkFogAroundUnit(this);
            ToggleBorder(true, Color.green);
        }
    }
    
    private void MoveToHex()
    {
        ToggleBorder(false, Color.green);
        //Debug.Log($"CurPos-{curPos.x}:{curPos.y}");
        //Debug.Log(targetHex);

        transform.position = Vector2.MoveTowards(curPos, targetHex.transform.position, 4 * Time.deltaTime);
        curPos = transform.position;

        if (curPos == targetHex.Pos) //Reach Destination
        {
            movePoint -= targetHex.MoveCost;
            StayOnHex(targetHex);

            if (faction == gameMgr.PlayerFaction)
                gameMgr.ClearDarkFogAroundEveryUnit(faction);
        }
    }

    
}
