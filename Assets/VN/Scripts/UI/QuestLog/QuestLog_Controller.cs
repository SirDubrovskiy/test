using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestLog_Controller : MonoBehaviour
{
    
    [SerializeField] GameObject QuestLogUI;

    [SerializeField] private GameObject QuestLogUpdatePrefab;

    [SerializeField] private RectTransform QuestLogParent;
    
    private int _currentStage;
    
    private List<GameObject> _stagesUI = new List<GameObject>();
    
    
    private Color stageCompleteColor = new Color(0f, 1f, 0f, 1f);
    private Color stageDefaultColor = new Color(1f, 1f, 1f, 1f);
    private Color stageFailColor = new Color(1f, 0f, 0f, 1f);
    
    public static QuestLog_Controller Instance { get; private set; }
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
    public void StartNewQuest(string questName, string QuestDes, Quests stages, int qID)
    {
        VisibilityQuestLog();
        Transform questNameTransform = QuestLogUI.transform.Find("QuestName");
        if (questNameTransform != null)
        {
            TextMeshProUGUI questNameTMP = questNameTransform.GetComponent<TextMeshProUGUI>();
            if (questNameTMP != null)
            {
                questNameTMP.text = questName;
            }
        }
        Transform questDesTransform = QuestLogUI.transform.Find("QuestDes");
        if (questDesTransform != null)
        {
            TextMeshProUGUI questDesTMP = questDesTransform.GetComponent<TextMeshProUGUI>();
            if (questDesTMP != null)
            {
                questDesTMP.text = QuestDes;
            }
        }
        QuestStageUpdate(stages, qID);
    }

    public void QuestStageUpdate(Quests questsStages, int questID)
    {
       foreach (QuestStage questStage in questsStages.quests[--questID].stages)
       {
           GameObject newSlot = Instantiate(QuestLogUpdatePrefab, QuestLogParent);
           
           _stagesUI.Add(newSlot);
        
           Transform newSlotTransformCon = newSlot.transform.Find("ContentText");
           TextMeshProUGUI newSlotTMPCon = newSlotTransformCon.GetComponent<TextMeshProUGUI>();
           newSlotTMPCon.text = questStage.description;
        
           Transform newSlotTransformInd = newSlot.transform.Find("IndexText");
           TextMeshProUGUI newSlotTMPInd = newSlotTransformInd.GetComponent<TextMeshProUGUI>();
           int stageID = questStage.stageID;
           stageID++;
        
           newSlotTMPInd.text = stageID.ToString(); 
           
           newSlot.SetActive(false);
       }
    }

    public void QuestCheck(bool hasQuest, int currentStage)
    {
        int newCurrentStage = currentStage - 1;
        
        for (int i = 0; i < _stagesUI.Count; i++)
        {
            if (_stagesUI[i] == null) continue;
            _stagesUI[i].gameObject.SetActive(i <= currentStage);
            
            
            Transform changingStateTransform = _stagesUI[i].transform.Find("ContentText");
            if (changingStateTransform == null) continue;
            
            TextMeshProUGUI stageTMP = changingStateTransform.GetComponent<TextMeshProUGUI>();
            if (stageTMP == null) continue;
            
            if (i < currentStage) 
                stageTMP.color = stageCompleteColor;
            else 
                stageTMP.color = stageDefaultColor;
        }
    }
    

    public void VisibilityQuestLog()
    {
        QuestLogUI.SetActive(!QuestLogUI.activeInHierarchy);
    }

    public void QuestComplete()
    {
        Transform questNameTransform = QuestLogUI.transform.Find("QuestName");
        if (questNameTransform != null)
        {
            TextMeshProUGUI questNameTMP = questNameTransform.GetComponent<TextMeshProUGUI>();
            if (questNameTMP != null)
            {
                questNameTMP.text = null;
            }
        }
        Transform questDesTransform = QuestLogUI.transform.Find("QuestDes");
        if (questDesTransform != null)
        {
            TextMeshProUGUI questDesTMP = questDesTransform.GetComponent<TextMeshProUGUI>();
            if (questDesTMP != null)
            {
                questDesTMP.text = null;
            }
        }
        while (QuestLogParent.childCount > 0)
            DestroyImmediate(QuestLogParent.GetChild(0).gameObject);
    }
}
