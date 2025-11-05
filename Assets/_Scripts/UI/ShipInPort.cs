using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShipInPort : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image unitImage;

    [SerializeField]
    private NavalUnit navalUnit;
    public NavalUnit NavalUnit { get { return navalUnit; } set { navalUnit = value; } }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click at ship");
    }


    public void UnitInit(NavalUnit navalUnit)
    {
        unitImage.sprite = navalUnit.UnitSprite.sprite;
        this.navalUnit = navalUnit;
    }


}
