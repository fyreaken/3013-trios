using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseBehavior : MonoBehaviour
{
    private PlayerInput playerControls;
    private InputAction menu;
    private InputActionMap ui;
    private InputActionMap onfoot;

    [SerializeField] public GameObject CrosshairUI;
    [SerializeField] public GameObject PauseUI;
    [SerializeField] public GameObject DeathUI;

    [SerializeField] private bool isGamePaused;

    void Awake(){
        playerControls = new PlayerInput();
    }

    private void OnEnable(){
        Cursor.lockState = CursorLockMode.Locked;
        menu = playerControls.Menu.Escape;
        ui = playerControls.UI;
        onfoot = playerControls.OnFoot;
        menu.Enable();
        ui.Disable();
        onfoot.Disable();

        menu.performed += Pause;
    }

    private void OnDisable(){
        menu.Disable();
        ui.Enable();
        onfoot.Enable();
    }

    void Pause(InputAction.CallbackContext context){
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            ActivateMenu();
        }
        else {
            DeactivateMenu();
        }
    }

    void ActivateMenu(){ //allows pressing ESC to pause the game IF DeathUI isn't active
        if (!DeathUI.activeSelf){
            Time.timeScale = 0;
            AudioListener.pause = true;
            CrosshairUI.SetActive(false);
            PauseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void DeactivateMenu(){ //allows pressing ESC to un-pause the game IF DeathUI isn't active
        if (!DeathUI.activeSelf){
            Time.timeScale = 1;
            AudioListener.pause = false;
            CrosshairUI.SetActive(true);
            PauseUI.SetActive(false);
            isGamePaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Restart(){ //reloads the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame(){ //loads the main menu scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
