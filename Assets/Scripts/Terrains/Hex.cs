using UnityEngine;


public enum HexType
{
    Ocean,
    Grassland,
    Prairie,
    Savannah,
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

    [Header("Fog of War")]
    [SerializeField]
    private SpriteRenderer fogSprite;

    [SerializeField]
    private SpriteRenderer darkSprite;

    [Header("Terrain")]
    [SerializeField]
    private Sprite[] oceanSprites;

    [SerializeField]
    private Sprite[] grasslandSprites;

    [SerializeField]
    private Sprite[] prairieSprites;

    [SerializeField]
    private Sprite[] savannahSprites;

    [SerializeField]
    private Sprite[] plainSprites;

    [SerializeField]
    private Sprite[] tundraSprites;

    [SerializeField]
    private Sprite[] desertSprites;

    [SerializeField]
    private Sprite[] swampSprites;

    [SerializeField]
    private Sprite[] arcticSprites;

    [SerializeField]
    private Sprite[] hillsSprites;

    [SerializeField]
    private Sprite[] mountainsSprites;

    [Header("Town")]
    [SerializeField]
    private bool hasTown;

    [Header("River")]
    private bool hasRiver;

    [Header("Forest")]
    private bool hasForest;

    [SerializeField]
    private int moveCost = 1;
    public int MoveCost { get { return moveCost; } }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void RandomSprite(Sprite[] sprites)
    {
        int i = Random.Range(0, sprites.Length);
        terrainSprite.sprite = sprites[i];
    }
    
    public void GenOceanSprite()
    {
        type = HexType.Ocean;
        moveCost = 1;
        RandomSprite(oceanSprites);
    }
    
    
    public void RandomHexTerrain()
    {
        int n = Random.Range(1, 11);

        moveCost = 1;

        switch (n)
        {
            case 1:
                type = HexType.Grassland;
                RandomSprite(grasslandSprites);
                break;
            case 2:
                type = HexType.Prairie;
                RandomSprite(prairieSprites); ;
                break;
            case 3:
                type = HexType.Savannah;
                RandomSprite(savannahSprites);
                break;
            case 4:
                type = HexType.Plain;
                RandomSprite(plainSprites);
                break;
            case 5:
                type = HexType.Tundra;
                RandomSprite(tundraSprites);
                break;
            case 6:
                type = HexType.Desert;
                RandomSprite(desertSprites);
                break;
            case 7:
                type = HexType.Swamp;
                RandomSprite(swampSprites);
                moveCost = 2;
                break;
            case 8:
                type = HexType.Arctic;
                RandomSprite(arcticSprites);
                break;
            case 9:
                type = HexType.Hills;
                RandomSprite(hillsSprites);
                moveCost = 2;
                break;
            case 10:
                type = HexType.Mountains;
                RandomSprite(mountainsSprites);
                moveCost = 3;
                break;
        }
    }
}
