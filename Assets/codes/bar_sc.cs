using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bar_sc : MonoBehaviour
{
    [SerializeField] private GameObject can1;
    [SerializeField] private GameObject can2;
    [SerializeField] private GameObject can3;

    [SerializeField] private GameObject olum_panel;
    [SerializeField] private GameObject sound_player;
    [SerializeField] private AudioClip fail;
    public void can_olay()
    {
        if (car_sc.can==3)
        {
            can1.SetActive(true);
            can2.SetActive(true);
            can3.SetActive(true);
        }
        else if (car_sc.can==2)
        {
            can1.SetActive(true);
            can2.SetActive(true);
            can3.SetActive(false);
        }
        else if (car_sc.can == 1)
        {
            can1.SetActive(true);
            can2.SetActive(false);
            can3.SetActive(false);
        }
        else if (car_sc.can == 0)
        {
            sound_player.GetComponent<AudioSource>().PlayOneShot(fail);
            Time.timeScale = 0f;
            olum_panel.SetActive(true);
        }
    }
}
