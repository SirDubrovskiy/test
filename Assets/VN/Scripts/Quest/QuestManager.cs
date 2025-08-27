using System.Collections.Generic;
using System.Linq;
using Naninovel;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public static QuestManager Instance { get; private set; }

    [SerializeField] private Quests SOQuests;
    [SerializeField] private GameObject questLogController;
    
    private List<GameObject> _stagesArray = new List<GameObject>();

    private QuestName currentQuest;
    private QuestLog_Controller _QLController;

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
        if (currentQuest != null)
        {
            var vars = Engine.GetService<ICustomVariableManager>();
            if (vars != null)
            {
                var value = vars.GetVariableValue("Quest_01_Stage");
                if (value != null)
                {
                    var stage = int.Parse(value);
                    QuestCheck(stage);
                }
            }
        }
    }

    public void SetCurrentQuest(int questID)
    {
        currentQuest = SOQuests.quests.FirstOrDefault(q => q.questID == questID);
        if (currentQuest != null)
        {
            _QLController = questLogController.GetComponent<QuestLog_Controller>();
            _QLController.StartNewQuest(currentQuest.questName, currentQuest.questDescription, SOQuests, questID);
        }
    }
    
    
    public void QuestCheck(int currentStage)
    {
        _QLController.QuestCheck(false,currentStage);
    }

    public void QuestComplete()
    {
            _QLController.QuestComplete();
    }
}   
