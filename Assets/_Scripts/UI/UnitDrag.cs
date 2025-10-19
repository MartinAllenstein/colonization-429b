using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Image unitImage;

    [SerializeField]
    private LandUnit landUnit;
    public LandUnit LandUnit { get { return landUnit; } set { landUnit = value; } }
    
    [SerializeField]
    private Transform iconParent;
    public Transform IconParent { get { return iconParent; } set { iconParent = value; } }

    [SerializeField]
    private TerrainSlot terrainSlot;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
    
    public void UnitInit(LandUnit landUnit)
    {
        unitImage.sprite = landUnit.UnitSprite.sprite;
        this.landUnit = landUnit;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        iconParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        unitImage.raycastTarget = false;
    }

    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(iconParent);
        unitImage.raycastTarget = true;
    }


    public void QuitOldTerrainSlot()
    {
        if (terrainSlot != null)
        {
            terrainSlot.Hex.Labor = null;
            terrainSlot.RemoveYieldIcons();
            terrainSlot.Hex.YieldID = -1; //no yield for this hex
            terrainSlot = null;
        }
    }

    public void WorkAtNewTerrainSlot(TerrainSlot terrainSlot)
    {
        this.terrainSlot = terrainSlot;
    }

}
