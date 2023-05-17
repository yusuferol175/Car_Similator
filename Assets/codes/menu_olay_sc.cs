using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_olay_sc : MonoBehaviour
{
    [SerializeField] private GameObject lock1;
    [SerializeField] private GameObject lock2;

    [SerializeField] private GameObject level_panel;
    [SerializeField] private GameObject sound_back;
    [SerializeField] private GameObject shop_panel;
    [SerializeField] private GameObject coin_im;

    [SerializeField] private Button mustang_s;
    [SerializeField] private Button viper_s;
    [SerializeField] private Button lambo_s;
    [SerializeField] private Button viper_b;
    [SerializeField] private Button lambo_b;

    [SerializeField] private Button sound_button;
    [SerializeField] private Sprite ses_acik;
    [SerializeField] private Sprite ses_kapali;


    [SerializeField] private Button level2;
    [SerializeField] private Button level3;
    [SerializeField] private Button menu_button;

    [SerializeField] private Button sol_button;
    [SerializeField] private Button sag_button;
    
    [SerializeField] private Text l2text;
    [SerializeField] private Text l3text;
    [SerializeField] private Text coin_count;

    [SerializeField] private List<GameObject> cars = new List<GameObject>();

    void Start()
    {
        
        coin_count.text = "X " + PlayerPrefs.GetInt("coin");


        if (PlayerPrefs.GetInt("sound") == 0)
        {
            sound_back.GetComponent<AudioSource>().Play();
            sound_button.GetComponent<Image>().sprite = ses_acik;
        }
        else if (PlayerPrefs.GetInt("sound") == 1)
        {
            sound_back.GetComponent<AudioSource>().Stop();
            sound_button.GetComponent<Image>().sprite = ses_kapali;
        }
        menu_button.gameObject.SetActive(false);

        level_panel.SetActive(false);
        shop_panel.SetActive(false);
        if (PlayerPrefs.GetInt("_level") == 0)
        {
            level2.enabled = false;
            level3.enabled = false;

        }
        else if(PlayerPrefs.GetInt("_level")==1)
        {
            level2.enabled = true;
            lock1.SetActive(false);
            l2text.text = "2";
        }
        else if (PlayerPrefs.GetInt("_level") == 2)
        {
            level3.enabled = true;
            lock1.SetActive(false);
            lock2.SetActive(false);
            l2text.text = "2";
            l3text.text = "3";
        }
    }

    public void play_but()
    {
        level_panel.SetActive(true);
        menu_button.gameObject.SetActive(true);
    }
    public void menu_but()
    {
        level_panel.SetActive(false);
        shop_panel.SetActive(false);
        menu_button.gameObject.SetActive(false);
    }
    public void level_but(Object sender)
    {
        GameObject tiklanan = sender as GameObject;
        PlayerPrefs.SetInt("level", int.Parse(tiklanan.tag));
        SceneManager.LoadScene("oyun");
    }
    public void sound_but()
    {
        if (PlayerPrefs.GetInt("sound")==0)
        {
            sound_back.GetComponent<AudioSource>().Stop();
            PlayerPrefs.SetInt("sound", 1);
            sound_button.GetComponent<Image>().sprite = ses_kapali;
        }
        else if (PlayerPrefs.GetInt("sound") == 1)
        {
            sound_back.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("sound", 0);
            sound_button.GetComponent<Image>().sprite = ses_acik;
        }
    }
    public void shop()
    {
        shop_panel.SetActive(true);
        menu_button.gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("viper_buy")==1)
        {
            viper_b.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lambo_buy") == 1)
        {
            lambo_b.gameObject.SetActive(false);
        }


        if (PlayerPrefs.GetString("skin_id") == "m")
        {
            mustang_s.gameObject.SetActive(false);
            viper_s.gameObject.SetActive(true);
            lambo_s.gameObject.SetActive(true);

        }
        else if (PlayerPrefs.GetString("skin_id") == "v")
        {
            mustang_s.gameObject.SetActive(true);
            viper_s.gameObject.SetActive(false);
            lambo_s.gameObject.SetActive(true);

        }
        else if (PlayerPrefs.GetString("skin_id") == "l")
        {
            mustang_s.gameObject.SetActive(true);
            viper_s.gameObject.SetActive(true);
            lambo_s.gameObject.SetActive(false);

        }
        
        if (PlayerPrefs.GetInt("active_car") == 0)
        {
            sol_button.gameObject.SetActive(false);
            active_car_select();
        }
        else if (PlayerPrefs.GetInt("active_car") == 1)
        {
            sol_button.gameObject.SetActive(true);
            sag_button.gameObject.SetActive(true);
            active_car_select();
        }
        else if (PlayerPrefs.GetInt("active_car") == 2)
        {
            sag_button.gameObject.SetActive(false);
            active_car_select();
        }
        
        
    }
    public void sol_but()
    {
        if (PlayerPrefs.GetInt("active_car")==0)
        {
            PlayerPrefs.SetInt("active_car",0);
        }
        else
        {
            PlayerPrefs.SetInt("active_car", PlayerPrefs.GetInt("active_car") - 1);
        }

        if (PlayerPrefs.GetInt("active_car") == 0)
        {
            sol_button.gameObject.SetActive(false);
            active_car_select();

        }
        else if (PlayerPrefs.GetInt("active_car") == 1)
        {
            sag_button.gameObject.SetActive(true);
            sol_button.gameObject.SetActive(true);
            active_car_select();
        }
        else if (PlayerPrefs.GetInt("active_car") == 2)
        {
            sag_button.gameObject.SetActive(false);
            active_car_select();
        }
    }
    public void sag_but()
    {
        if (PlayerPrefs.GetInt("active_car") == 2)
        {
            PlayerPrefs.SetInt("active_car", 2);
        }
        else
        {
            PlayerPrefs.SetInt("active_car", PlayerPrefs.GetInt("active_car") + 1);
        }

        if (PlayerPrefs.GetInt("active_car") == 0)
        {
            sol_button.gameObject.SetActive(false);
            active_car_select();

        }
        else if (PlayerPrefs.GetInt("active_car") == 1)
        {
            sag_button.gameObject.SetActive(true);
            sol_button.gameObject.SetActive(true);
            active_car_select();
        }
        else if (PlayerPrefs.GetInt("active_car") == 2)
        {
            sag_button.gameObject.SetActive(false);
            active_car_select();
        }
    }
    private void active_car_select()
    {
        foreach (var car in cars)
        {
            car.SetActive(false);
        }
        cars[PlayerPrefs.GetInt("active_car")].SetActive(true);
    }
    public void araba_select(Object sender)
    {
        GameObject tiklanan = sender as GameObject;
        PlayerPrefs.SetString("skin_id", tiklanan.tag);

        if (PlayerPrefs.GetString("skin_id")=="m")
        {
            mustang_s.gameObject.SetActive(false);
            viper_s.gameObject.SetActive(true);
            lambo_s.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetString("skin_id") == "v")
        {
            mustang_s.gameObject.SetActive(true);
            viper_s.gameObject.SetActive(false);
            lambo_s.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetString("skin_id") == "l")
        {
            mustang_s.gameObject.SetActive(true);
            viper_s.gameObject.SetActive(true);
            lambo_s.gameObject.SetActive(false);
        }
    }
    public void viper_buy()
    {
        if (PlayerPrefs.GetInt("coin")>10)
        {
            PlayerPrefs.SetInt("viper_buy", 1);
            viper_b.gameObject.SetActive(false);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin")-10);
            coin_count.text = "X " + PlayerPrefs.GetInt("coin");
        }
        
    }
    public void lambo_buy()
    {
        if (PlayerPrefs.GetInt("coin") > 10)
        {
            PlayerPrefs.SetInt("lambo_buy", 1);
            lambo_b.gameObject.SetActive(false);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 10);
            coin_count.text = "X " + PlayerPrefs.GetInt("coin");
        }
    }

}
