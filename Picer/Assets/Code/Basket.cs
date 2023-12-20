using UnityEngine;
using TMPro;
public class Basket : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    public AudioSource As;
    public AudioClip source;
    private void Start()
    {
        Progress.Inst.FaindText();
        Progress.Inst.Save();
    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    private void RandomSongs()
    {
        if (Progress.Inst.SongWorked)
        {
            As = Progress.Inst.audioMassive[0];
            source = Progress.Inst.audioMassive[0].clip;
        }
        if (Progress.Inst.SongWorked)
        {
            As.PlayOneShot(source);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            Progress.Inst.coins += 1;
            if (Progress.Inst.coins > Progress.Inst.record)
            {
                Progress.Inst.record = Progress.Inst.coins;
            }
            Progress.Inst.Save();
            textScore.text = "Score: " + Progress.Inst.coins.ToString();
            RandomSongs();
            Progress.Inst.UpdateText();
            Destroy(collision.gameObject);
        }
    }
}
