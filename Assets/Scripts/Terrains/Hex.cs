using UnityEngine;


public enum HexType
{
    Ocean,
    Grassland,
    Prairie,
    Savanna,
    Plain,
    Tundra,
    Desert,
    Swamp,
    Arctic,
    Hills,
    Mountains
}

public class Hex : MonoBehaviour
{
    [SerializeField]
    private int x;
    public int X { get { return x; } set { x = value; } }

    [SerializeField]
    private int y;
    public int Y { get { return y; } set { y = value; } }

    [SerializeField]
    private Vector2 pos;
    public Vector2 Pos { get { return pos; } set { pos = value; } }

    [SerializeField]
    private HexType type = HexType.Plain;
    public HexType Type { get { return type; } }

    [Header("Basic")]
    [SerializeField]
    private SpriteRenderer terrainSprite;
    
    [SerializeField]
    private SpriteRenderer forestSprite;

    [Header("Fog of War")]
    [SerializeField]
    private SpriteRenderer fogSprite;

    [SerializeField]
    private SpriteRenderer darkSprite;

    [Header("Town")]
    [SerializeField]
    private bool hasTown;

    public bool HasTown {get { return hasTown;} set { hasTown = value;  }
    }

    [Header("River")]
    private bool hasRiver;

    [Header("Forest")]
    private bool hasForest;

    [SerializeField]
    private int moveCost = 1;
    public int MoveCost { get { return moveCost; } }
    
    [Header("Terrain")]
    [SerializeField]
    private Sprite[] terrainSprites;

    [Header("Forest")]
    [SerializeField]
    private Sprite[] forestSprites;

    [SerializeField]
    private string hexName;
    public string HexName { get { return hexName; } set { hexName = value; } }

    [SerializeField]
    private int[] resourceYield;
    public int[] ResourceYield { get { return resourceYield; } set { resourceYield = value; } }

    [Header("Special")]
    [SerializeField]
    private bool specialHex;
    public bool SpecialHex { get { return specialHex; } set { specialHex = value; } }

    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    
    
}
