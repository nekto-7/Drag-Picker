using UnityEngine;
using TMPro;
public class Progress : MonoBehaviour
{
    // score
    public int coins = 0;
    public int record = 0;
    // song
    public bool flag = true;
    public bool SongWorked = true;
    public AudioSource[] audioMassive;
    //  text
    public TextMeshProUGUI  rec;
    private GameObject[] G2;
    //
    public static Progress Inst;
    private void Awake()
    {
        FaindText();
        if (Inst != null && Inst != this)
        {
            Destroy(gameObject);
            return;
        }
        Inst = this;
        DontDestroyOnLoad(gameObject);
        UotputSave();
        Save();
    }

    public void FaindText()
    {
        G2 = GameObject.FindGameObjectsWithTag("R");
        if (G2.Length > 0 && G2[0] != null)
        {
            rec = G2[0].GetComponent<TextMeshProUGUI>();
        }

        UpdateText();
    }
    public void UpdateText()
    {
        UotputSave();
       
        if (rec != null)
        {
            rec.text = "Record: " + PlayerPrefs.GetInt("Record").ToString();
        }
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Record", record);
    }
    public void SwitchFlag()
    {
        if (SongWorked) { SongWorked = false; }
        else { SongWorked = true; }
        SaveSettings();
    }
    public void SaveSettings()
    {
        int SongValue = SongWorked ? 1 : 0;
        PlayerPrefs.SetInt("SongValue", SongValue);
    }
    public void UotputSave()
    {
        if (PlayerPrefs.HasKey("Record"))
        {
            record = PlayerPrefs.GetInt("Record");
        }
        //
        if (PlayerPrefs.HasKey("SongValue"))
        {
            int songValue = PlayerPrefs.GetInt("SongValue");
            SongWorked = songValue == 1 ? true : false;
        }
    }
}

