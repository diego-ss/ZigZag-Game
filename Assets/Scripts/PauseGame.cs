using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    private Text txtPause;

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            txtPause.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            txtPause.enabled = false;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
