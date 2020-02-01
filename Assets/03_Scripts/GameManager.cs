using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private GameObject prefabAxe;
    [SerializeField] private GameObject prefabPick;
    [SerializeField] private GameObject prefabRamp;
    [SerializeField] private GameObject prefabBridge;
    
    public event Action<int> OnAmountChangeAxe = delegate { };
    public event Action<int> OnAmountChangePick = delegate { };
    public event Action<int> OnAmountChangeRamp = delegate { };
    public event Action<int> OnAmountChangeBridge = delegate { };

    private int amountAxe;
    private int amountPick;
    private int amountRamp;
    private int amountBridge;

    private bool isSnapped = false;

    private GameObject selectedTool = null;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadNewLevel();
    }

    public void LoadNewLevel()
    {
        setAmountAxe(2);
        setAmountPick(1);
        setAmountRamp(1);
        setAmountBridge(1);
    }

    private void setAmountAxe(int amount)
    {
        amountAxe = amount;
        OnAmountChangeAxe(amount);
    }
    
    private void setAmountPick(int amount)
    {
        amountPick = amount;
        OnAmountChangePick(amount);
    }
    
    private void setAmountRamp(int amount)
    {
        amountRamp = amount;
        OnAmountChangeRamp(amount);
    }
    
    private void setAmountBridge(int amount)
    {
        amountBridge = amount;
        OnAmountChangeBridge(amount);
    }
    
    public void OnSelectionAxe()
    {
        if (amountAxe <= 0) return;
            
        if(selectedTool != null & !isSnapped)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabAxe);
        isSnapped = false;    
    }
    
    public void OnSelectionPick()
    {
        if (amountPick <= 0) return;
            
        if(selectedTool != null & !isSnapped)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabPick);
        isSnapped = false;
    }
    
    public void OnSelectionRamp()
    {
        if (amountRamp <= 0) return;
            
        if(selectedTool != null & !isSnapped)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabRamp);
        isSnapped = false;  
    }
    
    public void OnSelectionBridge()
    {
        if (amountBridge <= 0) return;
            
        if(selectedTool != null & !isSnapped)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabBridge);
        isSnapped = false;  
    }

    public void UpdateAmountAxe()
    {
        setAmountAxe(amountAxe-1);
    }
    
    public void UpdateAmountPick()
    {
        setAmountPick(amountPick-1);
    }
    
    public void UpdateAmountRamp()
    {
        isSnapped = true;
        setAmountRamp(amountRamp-1);
    }
    
    public void UpdateAmountBrdige()
    {
        isSnapped = true;
        setAmountBridge(amountBridge-1);
    }
}
