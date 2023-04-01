using UnityEngine;

public class GameStart : MonoBehaviour
{

    [SerializeField] GameObject StartScreenUI;

    private static bool _isGameOnStart = true;
    public static bool IsGameOnStart
    {
        get
        {
            return _isGameOnStart;
        }

        set
        {
            _isGameOnStart = value;
        }
    }

    private void Start()
    {
        GameStateChanger.PauseGame();
        ShowStartScreenUI();
    }

    private void Update()
    {
        if(Input.touchCount > 0 && _isGameOnStart)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                GameStateChanger.ResumeGame();
                HideStartScreenUI();
            }
            
        }
    }

    public void ShowStartScreenUI()
    {
        StartScreenUI.SetActive(true);
    }
    public void HideStartScreenUI()
    {
        StartScreenUI.SetActive(false);
    }


}
