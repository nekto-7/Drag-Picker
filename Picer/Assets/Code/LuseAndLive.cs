using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LuseAndLive : MonoBehaviour
{
    [SerializeField] private int HP = 3;
    [SerializeField] private TextMeshProUGUI textHP;
    public AudioSource As;
    public AudioClip source;
    private void Start()
    {
        textHP.text = "HP - " + HP.ToString();
    }
    private void RandomSongs()
    {
        if (Progress.Inst.SongWorked)
        {
            As = Progress.Inst.audioMassive[1];
            source = Progress.Inst.audioMassive[1].clip;
        }
        if (Progress.Inst.SongWorked)
        {
            As.PlayOneShot(source);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Score")
        {
            HP--;
            textHP.text = "HP - " + HP.ToString();
            RandomSongs();
            if (HP <= 0) 
            {
                SceneManager.LoadScene(0);
            }

        }
    }
}
