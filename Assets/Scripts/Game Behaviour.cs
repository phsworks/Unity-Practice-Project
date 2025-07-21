
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{



    public int MaxItems = 4;
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;

    }

    public Button WinButton;
    private int _itemsCollected = 0;
    public int Items
    {
        get
        { return _itemsCollected; }
        set
        {
            _itemsCollected = value;

            ItemText.text = "Items: " + Items;

            if (_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";

                WinButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more!";
            }
        }
    }

    private int _playerHP = 4;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;

            HealthText.text = "Health: " + HP;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
