using Game.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class LogModuleCompileConfigWindow : EditorWindow
    {
        private static char[] UnityDefineSeparators;
        private static int MinPDefineLabelWidth;
        private static int AddRemoveButtonWidth;
        private static string[] LogDefines;

        private Vector2 _aciveDefinesAreaScrollPos;
        private Vector2 _userDefinesAreaScrollPos;
        private BuildTargetGroup _buildTargetGroup = BuildTargetGroup.Standalone;

        static LogModuleCompileConfigWindow()
        {
            try
            {
                UnityDefineSeparators = new char[] { ';' };
                MinPDefineLabelWidth = 320;
                AddRemoveButtonWidth = 25;
                LogDefines = new string[]
                {
                    LogModule.EnableLogInfoDefine,
                    LogModule.EnableLogWarningDefine,
                    LogModule.EnableLogErrorDefine,
                    LogModule.EnableLogAssertDefine,
                    LogModule.EnableLogExceptionDefine
                };
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        [MenuItem(nameof(LogModuleCompileConfigWindow), menuItem = "Config/" + nameof(LogModuleCompileConfigWindow))]
        private static void OpenWindow()
        {
            GetWindow(typeof(LogModuleCompileConfigWindow),false, nameof(LogModuleCompileConfigWindow));
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal(GUILayout.Height(300));

            DrawActiveDefinesGUI();
            DrawUserDefinesGUI();

            EditorGUILayout.EndHorizontal();

            DrawLogingDefines();
        }

        private void DrawActiveDefinesGUI()
        {
            var activeDefines = EditorUserBuildSettings.activeScriptCompilationDefines;

            EditorGUILayout.BeginVertical(GUILayout.Width(MinPDefineLabelWidth));
            EditorGUILayout.LabelField("ACTIVE DEFINES");
 
            _aciveDefinesAreaScrollPos = EditorGUILayout.BeginScrollView(_aciveDefinesAreaScrollPos);

            foreach (var define in activeDefines)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.TextField(define);
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();

            EditorGUILayout.EndVertical();
        }

        private void DrawUserDefinesGUI()
        {
            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("USER DEFINES", GUILayout.Width(85));
            _buildTargetGroup = (BuildTargetGroup) EditorGUILayout.EnumPopup(_buildTargetGroup);
            var definesRaw = PlayerSettings.GetScriptingDefineSymbolsForGroup(_buildTargetGroup);
            var defines = definesRaw.Split(UnityDefineSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (GUILayout.Button("+", GUILayout.Width(AddRemoveButtonWidth)))
                SwitchUserDefine(_buildTargetGroup, "NEW_DEFINE_" + DateTime.Now.Ticks, true, defines);
            EditorGUILayout.EndHorizontal();

            _userDefinesAreaScrollPos = EditorGUILayout.BeginScrollView(_userDefinesAreaScrollPos);

            for (var i = 0; i < defines.Length; i++)
            {
                var define = defines[i];
                EditorGUILayout.BeginHorizontal();
                var newDefineName = EditorGUILayout.DelayedTextField(define).ToUpperInvariant();

                if (newDefineName != define && !defines.Any(d => d == newDefineName))
                {
                    defines[i] = newDefineName;
                    SetUserDefines(_buildTargetGroup, defines);
                }

                if (GUILayout.Button("-", GUILayout.Width(AddRemoveButtonWidth)))
                    SwitchUserDefine(_buildTargetGroup, defines[i], false, defines);

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }

        private void DrawLogingDefines()
        {
            var definesRaw = PlayerSettings.GetScriptingDefineSymbolsForGroup(_buildTargetGroup);
            var defines = definesRaw.Split(UnityDefineSeparators, StringSplitOptions.RemoveEmptyEntries);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("LOG DEFINES", GUILayout.Width(80));
            _buildTargetGroup = (BuildTargetGroup)EditorGUILayout.EnumPopup(_buildTargetGroup);
            if (GUILayout.Button("ON", GUILayout.Width(40)))
                SwitchUserDefineSet(_buildTargetGroup, LogDefines, true, defines);
            if (GUILayout.Button("OFF", GUILayout.Width(40)))
                SwitchUserDefineSet(_buildTargetGroup, LogDefines, false, defines);
            EditorGUILayout.EndHorizontal();

            foreach (var define in LogDefines)
                DrawDefineToggle(_buildTargetGroup, define, defines);
        }

        private void DrawDefineToggle(BuildTargetGroup group, string define, IEnumerable<string> allDefines)
        {
            var exists = allDefines.Contains(define);
            var value = EditorGUILayout.ToggleLeft(define, exists);
            if (exists != value)
                SwitchUserDefine(group, define, value, allDefines);
        }

        private void SwitchUserDefine(BuildTargetGroup targetGroup, string defineToSwitch, bool newValue, IEnumerable<string> allDefines)
        {
            if (newValue)
            {
                if (allDefines.Contains(defineToSwitch)) 
                    return;

                SetUserDefines(targetGroup, allDefines.Concat(new string[] { defineToSwitch }));
            }
            else
            {
                if (!allDefines.Contains(defineToSwitch)) 
                    return;

                SetUserDefines(targetGroup, allDefines.Except(new string[] { defineToSwitch }));
            }
        }

        private void SwitchUserDefineSet(BuildTargetGroup targetGroup, IEnumerable<string> definesToSwitch, bool newValue, IEnumerable<string> allDefines)
        {
            if (newValue)
            {
                var missingDefines = definesToSwitch.Except(allDefines);
                SetUserDefines(targetGroup, allDefines.Concat(missingDefines));
            }
            else
            {
                var resultDefines = allDefines.Except(definesToSwitch);
                SetUserDefines(targetGroup, resultDefines);
            }
        }

        private void SetUserDefines(BuildTargetGroup targetGroup, IEnumerable<string> defines)
        {
            var definesRaw = string.Join(";", defines);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, definesRaw);
        }
    }
}
