using UnityEngine;

public class Factions : MonoBehaviour
{
    
    public enum Nation
    {
        England,
        France,
        Spain,
        Netherlands,
        Portugal
    }

    [SerializeField]
    private Nation nation;
    public Nation Nations { get { return nation; } }

    [SerializeField]
    private bool isEuropean;
    public bool IsEuropean { get { return isEuropean; } }

    [SerializeField]
    private Transform townParent;
    public Transform TownParent { get { return townParent; } }

    [SerializeField]
    private Transform unitParent;
    public Transform UnitParent { get { return unitParent; } }

    [SerializeField]
    private Sprite flagIcon;
    public Sprite FlagIcon { get { return flagIcon; } }

    [SerializeField]
    private Sprite shieldIcon;
    public Sprite ShieldIcon { get { return shieldIcon; } }

    [SerializeField]
    private Sprite unitIcon;
    public Sprite UnitIcon { get { return unitIcon; } }

    [SerializeField]
    private Sprite townIcon;
    public Sprite TownIcon { get { return townIcon; } }
    
    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void FactionInit(FactionData data)
    {
        nation = data.nation;
        isEuropean = data.isEuropean;
        flagIcon = data.flagIcon;
        shieldIcon = data.shieldIcon;
        unitIcon = data.unitIcon;
        townIcon = data.townIcon;
    }
}
