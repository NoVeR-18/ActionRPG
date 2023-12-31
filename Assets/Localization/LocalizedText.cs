﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[DefaultExecutionOrder (311)]
public class LocalizedText : MonoBehaviour
{
    [SerializeField]
    private string key;

    private LocalizationManager localizationManager;
    private Text text;

    void Awake()
    {
        if (localizationManager == null)
        {
            localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        }
        if (text == null)
        {
            text = GetComponent<Text>();
        }
        localizationManager.OnLanguageChanged += UpdateText;
    }

    void Start()
    {
        UpdateText();
    }
    private void OnEnable()
    {
        UpdateText();
    }

    private void OnDestroy()
    {
        localizationManager.OnLanguageChanged -= UpdateText;
    }

    virtual protected void UpdateText()
    {
        if (gameObject == null) return;

        if (localizationManager == null)
        {
            localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        }
        if (text == null)
        {
            text = GetComponent<Text>();
        }
        text.text = localizationManager.GetLocalizedValue(key);
    }
}