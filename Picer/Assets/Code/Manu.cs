using UnityEngine;
using UnityEngine.SceneManagement;

public class Manu : MonoBehaviour
{
    public void GoToManu()
    {
        Progress.Inst.Save();
        Progress.Inst.coins = 0;
        Progress.Inst.UotputSave();
        SceneManager.LoadScene(0);
        Progress.Inst.UpdateText();
    }
    public void GoToGame()
    {
        Progress.Inst.Save();
        Progress.Inst.coins = 0;
        Progress.Inst.UotputSave();
        SceneManager.LoadScene(1);
        Progress.Inst.UpdateText();
    }
}
