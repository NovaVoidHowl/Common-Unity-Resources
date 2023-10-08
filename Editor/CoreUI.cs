using System;
using UnityEditor;
using UnityEngine;

namespace uk.novavoidhowl.dev.common.ui
{
  public static class CoreUI
  {
    #if UNITY_EDITOR
    //////////////////////////////////////////
    //// Functions to render common UI elements
    ////

    // Function to render a horizontal separator
    public static void RenderHorizontalSeparator()
    {
      GUILayout.Space(2);
      GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(2));
      GUILayout.Space(2);
    }

    // render toggle button that switches the state of the boolean passed in, and if bool is true makes the button green, if false makes it red.
    // also takes 2 strings for the text to display when true and false
    public static void RenderToggleButton(ref bool boolToToggle, string trueText, string falseText)
    {
      if (boolToToggle)
      {
        GUI.backgroundColor = Color.green;
      }
      else
      {
        GUI.backgroundColor = Color.red;
      }

      if (GUILayout.Button(boolToToggle ? trueText : falseText))
      {
        boolToToggle = !boolToToggle;
      }

      GUI.backgroundColor = Color.white;
    }

    private static void RenderFoldoutStart()
    {
      EditorGUI.indentLevel++;
      EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
      GUILayout.Space(EditorGUI.indentLevel * 2);
      EditorGUILayout.BeginVertical();
      EditorGUI.indentLevel++;
      GUILayout.Space(2);
    }

    private static void RenderFoldoutEnd()
    {
      GUILayout.Space(5);
      EditorGUI.indentLevel--;
      EditorGUILayout.EndVertical();
      EditorGUILayout.EndHorizontal();
      EditorGUI.indentLevel--;
      GUI.backgroundColor = Color.white; // prevent bleed through from previous GUI.backgroundColor
    }

    public static void RenderFoldoutSection(string title, ref bool showSection, Action content, Color foldoutTitleBackgroundColor)
    {
      Rect foldoutRect = GUILayoutUtility.GetRect(
        GUIContent.none,
        EditorStyles.helpBox,
        GUILayout.ExpandWidth(true),
        GUILayout.Height(30f)
      );

      // Draw background
      GUIStyle bannerStyle = new GUIStyle(GUI.skin.box);
      bannerStyle.normal.background = Texture2D.whiteTexture;
      bannerStyle.normal.textColor = foldoutTitleBackgroundColor;
      GUI.backgroundColor = foldoutTitleBackgroundColor;
      GUI.Box(foldoutRect, GUIContent.none, bannerStyle);
      GUI.backgroundColor = Color.white;

      GUI.DrawTexture(
        new Rect(foldoutRect.x + 2f, foldoutRect.y + 5f, 16f, 16f),
        (
          showSection
            ? EditorGUIUtility.IconContent("IN Foldout on").image
            : EditorGUIUtility.IconContent("IN Foldout").image
        )
      );
      Rect labelRect = new Rect(foldoutRect.x + 18f, foldoutRect.y + 5f, foldoutRect.width - 18f, 16f);
      showSection = GUI.Toggle(labelRect, showSection, title, EditorStyles.boldLabel);
      if (Event.current.type == EventType.MouseDown && foldoutRect.Contains(Event.current.mousePosition))
      {
        showSection = !showSection;
        Event.current.Use();
      }

      if (showSection)
      {
        RenderFoldoutStart();

        GUI.backgroundColor = Color.white;
        content.Invoke();
        GUI.backgroundColor = foldoutTitleBackgroundColor;

        RenderFoldoutEnd();
      }
    }

    
    // Helper function to create a texture with a solid color
    public static Texture2D MakeTextureFromColour(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    // Alias for the MakeTextureWithColour function (US English spelling)
    public static Texture2D MakeTextureWithColor(int width, int height, Color col)
    {
        return MakeTextureWithColor(width, height, col);
    }

    // Helper function to convert hexadecimal color notation to Color
    public static Color HexToColour(string hex)
    {
        Color color = Color.white;
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }

    // Alias for the HexToColour function (US English spelling)
    public static Color HexToColor(string hex)
    {
        return HexToColor(hex);
    }





    #endif
  }
}
