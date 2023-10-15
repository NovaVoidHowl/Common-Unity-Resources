// this whole file is only to be used in edit mode
#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace uk.novavoidhowl.dev.common
{
  [InitializeOnLoad]
  public class NVH_Common_Init
  {
    static NVH_Common_Init()
    {
      AddSymbolIfNeeded();
    }

    [DidReloadScripts]
    private static void OnScriptsReloaded()
    {
      AddSymbolIfNeeded();
    }

    private static void AddSymbolIfNeeded()
    {
      string symbol = "NVH_COMMON_EXISTS";
      string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(
        EditorUserBuildSettings.selectedBuildTargetGroup
      );
      if (!defines.Contains(symbol))
      {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(
          EditorUserBuildSettings.selectedBuildTargetGroup,
          (defines + ";" + symbol)
        );
        Debug.Log("[NavMeshFollowerSetup_Ini] Added NVH_COMMON_EXISTS Scripting Symbol.");
      }
      else
      {
        Debug.Log("[NavMeshFollowerSetup_Ini] NVH_COMMON_EXISTS Scripting Symbol already exists.");
      }
    }
  }
}

#endif