using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader <T>
{
    public static T ReadJSONIntoClass(TextAsset JSONText)
    {
        return JsonUtility.FromJson<T>(JSONText.text);
    }
}
