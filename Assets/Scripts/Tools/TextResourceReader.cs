using UnityEngine;

public class TextResourceReader
{
    public static string Read(string textFilePath)
    {
        TextAsset textResource = Resources.Load(textFilePath) as TextAsset;
        return textResource ? textResource.text : null;
    }
}