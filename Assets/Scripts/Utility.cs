﻿using UnityEngine;

public class Utility : MonoBehaviour
{
    public static void SetCanvasGroupEnabled(CanvasGroup group, bool enabled)
    {
        group.alpha = (enabled ? 1.0f : 0.0f);
        group.interactable = enabled;
        group.blocksRaycasts = enabled;
    }
}