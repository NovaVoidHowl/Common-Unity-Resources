using System;
using UnityEditor;
using UnityEngine;

namespace uk.novavoidhowl.dev.common.ui
{
  public static class CoreUIHelpers
  {
    #if UNITY_EDITOR
    //////////////////////////////////////////
    //// Helper functions   
    ////
    
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
    public static Texture2D MakeTextureFromColor(int width, int height, Color col)
    {
        return MakeTextureFromColour(width, height, col);
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
        return HexToColour(hex);
    }

    #endif
  }
}
