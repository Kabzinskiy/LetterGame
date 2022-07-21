using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Panels;
using System.Linq;
using SwapAnimator;
using Unity.VisualScripting;

public class LettersPanel : MonoBehaviour
{
    public Action OnShuffleStart;
    public Action OnShuffleEnd;

    private int width;
    private int height;
    private GridLayoutGroup grid;
    private RectTransform rectTransform;
    private PanelTextCreator panelTextCreator = new();
    private List<PanelText> elements;
    private SwapAnimator.SwapAnimator swapAnimator;    
    private int MinStep => GetMinStep();
    private int FontTextSize => MinStep;

    void Awake()
    {
        grid = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        swapAnimator = new(this);
        swapAnimator.OnAnimationStart += ()=> { OnShuffleStart?.Invoke(); };
        swapAnimator.OnAnimationEnd += () => { OnShuffleEnd?.Invoke(); };
    }

    /// <summary>
    /// The function sets the sizes of the grid fields.
    /// Be sure to set the values before submitting them.
    /// </summary>
    /// <param name="width">Number of letters by width.</param>
    /// <param name="height">Number of letters by height.</param>
    public void SetSizes(int width, int height) 
    {
        this.width = width;
        this.height = height;
        grid.constraintCount = width;
        Vector2 gridSettings = new Vector2(MinStep, MinStep);
        grid.cellSize = gridSettings;
        grid.spacing = gridSettings;
    }

    /// <summary>
    /// The function clears the previous elements and creates new ones.
    /// </summary>
    /// <param name="letters">Letters for the grid.</param>
    public void SetLetters(Dictionary<int, char> letters) 
    {
        ClearMono(grid);
        elements = new List<PanelText>();
        foreach(var letter in letters)
        {
            var textElement = CreatePanelTextElement(grid);
            textElement.Text.fontSize = FontTextSize;
            textElement.Id = letter.Key;
            textElement.Text.text = letter.Value.ToString();     
            elements.Add(textElement);
        }
    }


    /// <summary>
    /// Letter shuffling animation function.
    /// </summary>
    /// <param name="letterPairs">Formed pairs of letters.</param>
    public void Shuffle(Dictionary<int, int> letterPairs)
    {
        foreach(var pair in letterPairs)
        {
            swapAnimator.SwapElements(elements.First(x=>x.Id == pair.Key).GameObject, elements.First(x => x.Id == pair.Value).GameObject);
        }
    }

    private void ClearMono(MonoBehaviour mono) 
    {
        for(int i = 0; i < mono.transform.childCount; ++i)
        {
            Destroy(mono.transform.GetChild(i)?.gameObject);
        }        
    }


    private int GetMinStep() 
    {        
        var width = rectTransform.rect.width;
        var height = rectTransform.rect.height;
        var minWidthStep = Convert.ToInt32(Math.Floor(width / (this.width * 2)));
        var minHeightStep = Convert.ToInt32(Math.Floor(height / (this.height * 2)));
        return minWidthStep <= minHeightStep ? minWidthStep : minHeightStep;
    }

    private PanelText CreatePanelTextElement(MonoBehaviour monoBehaviour) => panelTextCreator.Create(monoBehaviour) as PanelText; 

}
