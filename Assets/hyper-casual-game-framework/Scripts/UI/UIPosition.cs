using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UIPosition", menuName = "Assets/UIPosition")]
public class UIPosition : ScriptableObject
{
    public Vector2 showPosition;
    public Vector2 hidePosition;
}
