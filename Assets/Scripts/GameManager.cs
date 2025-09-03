using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Grid grid;

    [SerializeField]
    private Transform hexParent;

    [SerializeField]
    private GameObject hexPrefab;

    public const int WIDTH = 50; //no. of Column in this map
    public const int HEIGHT = 60; //no. of Row in this map

    [SerializeField]
    private Hex[,] allHexes = new Hex[WIDTH, HEIGHT];
    public Hex[,] AllHexes { get { return allHexes; } }

    [SerializeField]
    private HexData[] hexData;
    public HexData[] HexData { get { return hexData; } }

    [SerializeField]
    private bool showingText;

    [SerializeField]
    private int oceanEdgeIndex;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }
    
    
    void Start()
    {
        GenerateAllHexes();
    }

    void Update()
    {
        
    }
    
    
    private void GenerateAllHexes()
    {
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                Vector3 hexPos = grid.GetCellCenterWorld(new Vector3Int(x, y));
                //Debug.Log(hexPos);

                GameObject hexObj = Instantiate(hexPrefab, hexPos, Quaternion.identity, hexParent);
                Hex hex = hexObj.GetComponent<Hex>();

                int i = Random.Range(1, hexData.Length);
                hex.HexInit(x, y, hexPos, this, i);//Land
            
                //Debug.Log($"{x}:{y}");
                allHexes[x, y] = hex;
            }
        }
    }


}
