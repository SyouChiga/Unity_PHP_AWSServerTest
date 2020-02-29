using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class TestCMD
{
    public static void TestFunction()
    {
        Debug.Log("HELLO WORLD");
    }
    public static void Build()
    {
        var output = "";
        bool isDevelopment = false;
        var args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-outputPath":
                    output = args[i + 1];   //出力先の設定
                    break;
                case "-development":
                    isDevelopment = true;   //Developmentビルドにする
                    break;
                default:
                    break;
            }
        }

        var option = new UnityEditor.BuildPlayerOptions();
        option.locationPathName = output;
        option.scenes =  new string[] {"Assets/Scenes/Game.unity"};
        if (isDevelopment)
        {
            //optionsはビットフラグなので、|で追加していくことができる
            option.options = BuildOptions.Development | BuildOptions.AllowDebugging;
        }
        option.target = BuildTarget.StandaloneWindows64; //ビルドターゲットを設定. 今回はWin64
        var result = BuildPipeline.BuildPlayer(option);
        if (result.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            Debug.Log("BUILD SUCCESS");
        }
        else
        {
            Debug.LogError("BUILD FAILED");
        }
    }
}
#endif