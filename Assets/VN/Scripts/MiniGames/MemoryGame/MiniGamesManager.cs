using Naninovel;
using UnityEngine;

public class MiniGamesManager : MonoBehaviour
{

    [SerializeField] private MG_Memory_CardController MemoryGameController;

    [HideInInspector] public string nextSceneName;
    public static MiniGamesManager Instance { get; private set; }

    private bool _isGameStarted = false;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        var vars = Engine.GetService<ICustomVariableManager>();
        if (vars != null)
        {
            var value = vars.GetVariableValue("MiniGameStarted");
            if (value == "False")
            {
                if (_isGameStarted == true)
                {
                    StopMinigame(1);
                    _isGameStarted = false;
                }
            }
        }
    }
    
    public void tryStartGame(int MinigameID)
    {
            StartMinigame(MinigameID);
    }
    public void StartMinigame(int gameID)
    {
        switch (gameID)
        {
            case 1: MemoryGameController.StartMiniGame(); 
                break;
        }
        _isGameStarted = true;
    }

    public void StopMinigame(int gameID)
    {
        
            switch (gameID)
            {
                case 1:
                    MemoryGameController.StopMiniGame();
                    break;
            }
        
        _isGameStarted = false;
    }

    public async void FinishedMinigame()
    {
        var player = Engine.GetService<IScriptPlayer>();
        var scriptManager = Engine.GetService<IScriptManager>();
        var script = scriptManager.GetScript(nextSceneName);
        
        await player.PreloadAndPlayAsync(script);
    }
    
}
