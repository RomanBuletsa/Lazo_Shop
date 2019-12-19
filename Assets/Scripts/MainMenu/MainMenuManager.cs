using System;
using Application;
using Data;
using SceneManagement;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public sealed class MainMenuManager : IManager
    {
        
        public void Start()
        {
            //ScenesLoader.UnloadScene(ApplicationScenes.MainMenu.ToString());
        }

        public void Stop()
        {
        }
    }
}
