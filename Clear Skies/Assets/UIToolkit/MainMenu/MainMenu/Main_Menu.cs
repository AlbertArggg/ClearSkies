using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Main_Menu : MonoBehaviour
{
    // UI main, UI doc
    private GameObject _parentGameObject;
    private UIDocument _uiDocument;
    
    // UI Main Menu Buttons [Start, Settings, Statistics, Load-outs, Quit]
    private Button _btnStart, _btnSettings, _btnStatistics, _btnLoadouts, _btnQuit;
    
    // UI Game objects
    private GameObject _mainMenuUI, _settingsUI, _statisticsUI, _loadoutsUI, _quitUI;
    
    // Current Active Menu in scene
    private GameObject _activeMenu;
    
    private void Awake()
    {
        // get UI Document component
        GetUIDocument();
        
        // get parent object that holds all UI menus
        _parentGameObject = gameObject.GetParentObject("UI");
        
        // gets main menu, load game menu, settings menu....
        GetRequiredUIObjectsInScene();
    }
    
    private void OnEnable()
    {
        // get new game button and implement click event
        _btnStart = GetButtonFromUiDoc("btn-play");
        _btnStart.clicked += BtnClickEvent_Start;

        // get load game button and implement click event
        _btnSettings = GetButtonFromUiDoc("btn-settings");
        _btnSettings.clicked += BtnClickEvent_Settings;

        // get settings button and implement click event
        _btnStatistics = GetButtonFromUiDoc("btn-statistics");
        _btnStatistics.clicked += BtnClickEvent_Statistics;

        // get statistics button and implement click event
        _btnLoadouts = GetButtonFromUiDoc("btn-loadouts");
        _btnLoadouts.clicked += BtnClickEvent_Loadouts;

        // get quit game button and implement click event
        _btnQuit = GetButtonFromUiDoc("btn-quit");
        _btnQuit.clicked += BtnClickEvent_Quit;
    }
    
    private void GetUIDocument()
    {
        _uiDocument = GetComponent<UIDocument>();
        if (_uiDocument == null) 
            ErrorLogs.LogErrorInConsole($"Could not locate Component \"<UIDocument>\" in Game object", LogTypes.Error);
    }
    
    private void GetRequiredUIObjectsInScene()
    {
        // get all sub menus in scene
        _mainMenuUI = _parentGameObject.FindChildByName("MainMenu_UI");
        _activeMenu = _mainMenuUI;
        
        _settingsUI = _parentGameObject.FindChildByName("Settings_UI");
        _settingsUI.GetComponent<Settings_Menu>().SetMainMenuObject(this.gameObject);
        _settingsUI.SetActive(false);
        
        _statisticsUI = _parentGameObject.FindChildByName("Statistics_UI");
        _statisticsUI.GetComponent<Statistics_Menu>().SetMainMenuObject(this.gameObject);
        _statisticsUI.SetActive(false);
        
        _loadoutsUI = _parentGameObject.FindChildByName("Loadouts_UI");
        _loadoutsUI.GetComponent<Loadouts_Menu>().SetMainMenuObject(this.gameObject);
        _loadoutsUI.SetActive(false);

        _quitUI = _parentGameObject.FindChildByName("Quit_UI");
        _quitUI.GetComponent<Quit_Menu>().SetMainMenuObject(this.gameObject);
        _quitUI.SetActive(false);
    }
    
    // Get Buttons
    private Button GetButtonFromUiDoc(string btn_name) 
    { 
        Button btn = _uiDocument.rootVisualElement.Q<Button>(btn_name);
        if (btn == null) { ErrorLogs.LogErrorInConsole($"Could not locate button \"{btn_name}\" in UI Doc", LogTypes.Error); }
        return btn;
    }
    
    // handle button click events
    private void BtnClickEvent_Start()
    {
        ErrorLogs.LogErrorInConsole("Main Menu Button Click Event \"New game\"", LogTypes.Log);
    }
    private void BtnClickEvent_Settings()
    {
        ErrorLogs.LogErrorInConsole("Main Menu Button Click Event \"Settings\"", LogTypes.Log);

        _activeMenu.SetActive(false);
        _activeMenu = _settingsUI;
        _settingsUI.SetActive(true);
    }
    private void BtnClickEvent_Statistics()
    {
        ErrorLogs.LogErrorInConsole("Main Menu Button Click Event \"Statistics\"", LogTypes.Log);

        _activeMenu.SetActive(false);
        _activeMenu = _statisticsUI;
        _statisticsUI.SetActive(true);
    }
    private void BtnClickEvent_Loadouts()
    {
        ErrorLogs.LogErrorInConsole("Main Menu Button Click Event \"Loadouts\"", LogTypes.Log);

        _activeMenu.SetActive(false);
        _activeMenu = _loadoutsUI;
        _loadoutsUI.SetActive(true);
    }
    private void BtnClickEvent_Quit()
    {
        ErrorLogs.LogErrorInConsole("Main Menu Button Click Event \"Quit\"", LogTypes.Log);

        _activeMenu.SetActive(false);
        _activeMenu = _quitUI;
        _quitUI.SetActive(true);
    }
}
