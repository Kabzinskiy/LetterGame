using Generator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelController : MonoBehaviour
{
    [SerializeField] private ButtonPanel buttonPanel;
    [SerializeField] private LettersPanel lettersPanel;
    private const int MaxCount = 50;
    private const int StartData = 5;
    private int width = StartData;
    private int height = StartData; 
    private Generator.Generator generator;

    void Start()
    {
        generator = new(width, height);
        buttonPanel.MaxCount = MaxCount;
        lettersPanel.SetSizes(width, height);
        lettersPanel.SetLetters(generator.GenerateLetters());
        lettersPanel.OnShuffleStart += () => { buttonPanel.BlockInput(true); };
        lettersPanel.OnShuffleEnd += () => { buttonPanel.BlockInput(false); };

        buttonPanel.OnHeightChange += (int height) => 
        { 
            this.height = height;
            generator = new(width, this.height);
            lettersPanel.SetSizes(width, this.height);
            buttonPanel.SetDefaultData(width, this.height);
            lettersPanel.SetLetters(generator.GenerateLetters());
        };

        buttonPanel.OnWidthChange += (int width) =>
        {
            this.width = width;
            generator = new(this.width, height);
            lettersPanel.SetSizes(this.width, height);
            buttonPanel.SetDefaultData(this.width, height);
            lettersPanel.SetLetters(generator.GenerateLetters());
        };


        buttonPanel.OnGenerateButtonClick += () =>
        {
            lettersPanel.SetLetters(generator.GenerateLetters());
        };

        buttonPanel.OnShuffleButtonClick += () => 
        {
            lettersPanel.Shuffle(generator.GetSwapLetterPairs());
        };
    }   


}
