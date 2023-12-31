using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

[CustomPropertyDrawer(typeof(SeparatorAttribute))]
public class SeparatorDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        //base.OnGUI(position);

        SeparatorAttribute separatorAttribute
            = attribute as SeparatorAttribute;

        Rect separatorRect = new Rect(position.xMin,
            position.yMin + separatorAttribute.Spacing,
            position.width,
            separatorAttribute.Height);

        EditorGUI.DrawRect(separatorRect, Color.white);

    }

    public override float GetHeight()
    {
        SeparatorAttribute separator
            = attribute as SeparatorAttribute;

        return separator.Spacing + separator.Height + separator.Spacing;

        //return base.GetHeight();
    }


}
