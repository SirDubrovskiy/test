using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Naninovel;
using System.Threading.Tasks;

public class MG_Memory_CardController : MonoBehaviour
{
    [SerializeField] MG_Memory_Card cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    private List<Sprite> spritePairs;

    private MG_Memory_Card _firstCard;
    private MG_Memory_Card _secondCard;

    private int _matchCount;

    [SerializeField] private string scriptName;
    [SerializeField] private string startLabel;

    
    
    public void StartMiniGame()
    {
            PrepareSpritePairs();
            CreateCard();
    }

    public void StopMiniGame()
    {
        while (gridTransform.childCount > 0)
        {
            DestroyImmediate(gridTransform.GetChild(0).gameObject);
        }
        
    }

    public void PrepareSpritePairs()
    {
        spritePairs = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }

        Shuffle(spritePairs);
    }

    public void Shuffle(List<Sprite> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);

            Sprite temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void CreateCard()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        {
            MG_Memory_Card card = Instantiate(cardPrefab, gridTransform);
            card.SetCardImage(spritePairs[i]);
            card.cardController = this;
        }
    }


    public void SelectCard(MG_Memory_Card card)
    {
        if (card.isSelected == false)
        {
            card.ShowCard();

            if (_firstCard == null)
            {
                _firstCard = card;
                return;
            }

            if (_secondCard == null)
            {
                _secondCard = card;
                StartCoroutine(CardMatch(_firstCard, _secondCard));
                _firstCard = null;
                _secondCard = null;
            }
        }
    }

    IEnumerator CardMatch(MG_Memory_Card Acard, MG_Memory_Card BCard)
    {
        yield return new WaitForSeconds(0.2f);
        if (Acard.CardSprite == BCard.CardSprite)
        {
            _matchCount++;
            if (_matchCount >= spritePairs.Count / 2)
            {
                StopMiniGame();
                _matchCount = 0;
                MiniGamesManager.Instance.FinishedMinigame();
            }
        }

        else
        {
            Acard.HideCard();
            BCard.HideCard();
        }
    }

    public async void OnMiniGameFinished(string sceneName)
    {
        var player = Engine.GetService<IScriptPlayer>();
        var scriptManager = Engine.GetService<IScriptManager>();
        var script = scriptManager.GetScript(sceneName);
        
        await player.PreloadAndPlayAsync(script);
    }
}


