using System.Collections;
using System.Collections.Generic;
using System.Linq;  // FirstOrDefault
using UnityEngine;

public enum UIVisibility
{
    Show,
    Hide
};

public static class UIUtils
{
    public static void Move(
        this List<UIPosition> uiPositions,
        string uiName,
        UIVisibility uIVisibility = UIVisibility.Show)
    {
        UIPosition uiPosition = uiPositions.FirstOrDefault(x => x.name == uiName);
        if (uiPosition == null)
        {
            return;
        }

        GameObject go = GameObject.Find(uiName);
        if (go == null)
        {
            return;
        }

        if (uIVisibility == UIVisibility.Show)
        {
            go.GetComponent<RectTransform>().anchoredPosition = uiPosition.showPosition;
        }
        else    // Hide
        {
            go.GetComponent<RectTransform>().anchoredPosition = uiPosition.hidePosition;
        }
    }

    public static void HideAll(this List<UIPosition> uiPositions)
    {
        foreach (UIPosition uiPosition in uiPositions)
        {
            GameObject go = GameObject.Find(uiPosition.name);
            if (go != null)
            {
                go.GetComponent<RectTransform>().anchoredPosition = uiPosition.hidePosition;
            }
        }
    }
}
