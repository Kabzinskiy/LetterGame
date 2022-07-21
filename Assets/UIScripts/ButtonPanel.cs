using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField] private InputField InputWidth;
    [SerializeField] private InputField InputHeight;
    [SerializeField] private Button GenerateButton;
    [SerializeField] private Button ShuffleButton;
    [SerializeField] private GameObject Blocker;
    public int MaxCount { get; set; }
    private int defaultWidth;
    private int defaultHeight;
    

    public Action<int> OnWidthChange;
    public Action<int> OnHeightChange;
    public Action OnGenerateButtonClick;
    public Action OnShuffleButtonClick;

    void Start()
    {
        BlockInput(false);
        InputWidth.onValueChanged.AddListener(CheckWidth);
        InputHeight.onValueChanged.AddListener(CheckHeight);
        GenerateButton.onClick.AddListener(GenerateButtonInvoke);
        ShuffleButton.onClick.AddListener(() => { OnShuffleButtonClick?.Invoke(); });
    }

    /// <summary>
    /// Method for setting default data.
    /// </summary>
    /// <param name="width">Default width.</param>
    /// <param name="height">Default height.</param>
    public void SetDefaultData(int width, int height) 
    {
        defaultWidth = width;
        defaultHeight = height;
        InputWidth.text = defaultWidth.ToString();
        InputHeight.text = defaultHeight.ToString();
    }

    /// <summary>
    /// Input blocking function.
    /// </summary>
    /// <param name="value">"True" if you want to block.</param>
    public void BlockInput(bool value) => Blocker.gameObject.SetActive(value);

    private void GenerateButtonInvoke()=> OnGenerateButtonClick?.Invoke();
    private void CheckWidth(string width) 
    {
        if(int.TryParse(width, out int result) && result > 0 && result != defaultWidth)
        {
            result = result > MaxCount ? MaxCount : result;
            OnWidthChange?.Invoke(result);
        }
        else
        {
            InputWidth.text = defaultWidth.ToString();
        }        
    }

    private void CheckHeight(string height)
    {
        if(int.TryParse(height, out int result) && result > 0 && result != defaultHeight)
        {
            result = result > MaxCount ? MaxCount : result;
            OnHeightChange?.Invoke(result);
        }
        else
        {
            InputHeight.text = defaultHeight.ToString();
        }
    }


}
