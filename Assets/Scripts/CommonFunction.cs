using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CommonFunction
{
    public static void SetObjectInFront(Transform focus)
    {
        Transform parentGameObject = focus.parent;
        int siblingNum = parentGameObject.childCount;
        focus.SetSiblingIndex(siblingNum - 1);
    }

}
