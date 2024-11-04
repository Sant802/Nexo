using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public SpriteRenderer NewGameText;             // Imagen de "New Game" por defecto
    public SpriteRenderer NewGameTextSelected;     // Imagen de "New Game" seleccionada
    public SpriteRenderer ContinueText;            // Imagen de "Continue" por defecto
    public SpriteRenderer ContinueTextSelected;    // Imagen de "Continue" seleccionada

    private int selectedIndex = 1; // 1 = New Game, 0 = Continue

    void Start()
    {
        UpdateMenuSelection();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex = (selectedIndex == 0) ? 1 : 0;
            UpdateMenuSelection();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex = (selectedIndex == 1) ? 0 : 1;
            UpdateMenuSelection();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteSelection();
        }
    }

    void UpdateMenuSelection()
    {
        // Activar la visibilidad de la imagen seleccionada y desactivar la no seleccionada
        NewGameText.enabled = (selectedIndex == 0) ? true : false;
        NewGameTextSelected.enabled = (selectedIndex == 0) ? false : true;

        ContinueText.enabled = (selectedIndex == 1) ? true : false;
        ContinueTextSelected.enabled = (selectedIndex == 1) ? false : true;
    }

    void ExecuteSelection()
    {
        if (selectedIndex == 1)
        {
            // Cambiar a la escena de New Game
            SceneManager.LoadScene("NewGame");
        }
        else if (selectedIndex == 0)
        {
            // Cambiar a la escena de Continue
            SceneManager.LoadScene("Continue");
        }
    }
}
