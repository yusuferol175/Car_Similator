using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class car_sc : MonoBehaviour
{
    public static int can;
    private bool hareket;
    
    [SerializeField] private int movementSpeed;
    [SerializeField] private int horizontalSpeed;
    [SerializeField] private GameObject bar;
    [SerializeField] private Text coin;
    [SerializeField] private GameObject level_al;
    [SerializeField] private GameObject olum_panel;

    [SerializeField] private GameObject sound_player;
    [SerializeField] private GameObject sound_back;
    [SerializeField] private AudioClip get_coin;
    [SerializeField] private AudioClip accident;
    [SerializeField] private AudioClip success;
    

    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    [SerializeField] private Sprite mustang;
    [SerializeField] private Sprite viper;
    [SerializeField] private Sprite lambo;
    public void menu_but_olm()
    {
        SceneManager.LoadScene("menu");
    }
    public void restart_game()
    {
        SceneManager.LoadScene("oyun");
    }
    public void menu_but()
    {
        if (PlayerPrefs.GetInt("level") == 2)
        {
            
            PlayerPrefs.SetInt("level", 0);
            SceneManager.LoadScene("menu");
        }
        else
        {
            if (PlayerPrefs.GetInt("_level") == 2)
            {
                PlayerPrefs.SetInt("_level", 2);
            }
            else
            {
                PlayerPrefs.SetInt("_level", PlayerPrefs.GetInt("_level") + 1);
            }
            
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            SceneManager.LoadScene("menu");
        }
    }
    public void next_but()
    {
        if (PlayerPrefs.GetInt("level")==2)
        {
            PlayerPrefs.SetInt("level",0);
            SceneManager.LoadScene("menu");
        }
        else
        {
            if (PlayerPrefs.GetInt("_level") == 2)
            {
                PlayerPrefs.SetInt("_level", 2);
            }
            else
            {
                PlayerPrefs.SetInt("_level", PlayerPrefs.GetInt("_level") + 1);
            }
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            SceneManager.LoadScene("oyun");
        }
        
    }
    public void gas_but_down()
    {
        movementSpeed = 5;
        hareket = true;
       
    }
    public void gas_but_up()
    {
        hareket = false;
        
    }
    void Start()
    {
        
        if (PlayerPrefs.GetString("skin_id") == "m")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = mustang;
        }
        else if(PlayerPrefs.GetString("skin_id") == "v")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = viper;
        }
        else if (PlayerPrefs.GetString("skin_id") == "l")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = lambo;
        }
        olum_panel.SetActive(false);
        Time.timeScale = 1f;
        Instantiate(levels[PlayerPrefs.GetInt("level")]);
        can = 3;
        coin.text = "X" + PlayerPrefs.GetInt("coin").ToString();
        level_al.SetActive(false);
        if (PlayerPrefs.GetInt("sound")==1)
        {
            gameObject.GetComponent<AudioSource>().volume = 0f;
            sound_player.GetComponent<AudioSource>().volume = 0f;
            sound_back.GetComponent<AudioSource>().volume = 0f;
        }

    }

    void Update()
    {
        if (hareket)
        {
            if (gameObject.GetComponent<AudioSource>().isPlaying == false)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            
            gameObject.transform.Translate(0, movementSpeed * Time.deltaTime, 0);
            float yatayhareket = Input.acceleration.x;

            gameObject.transform.Translate(yatayhareket * Time.deltaTime * horizontalSpeed, 0, 0);
        }
        else
        {
            if (gameObject.GetComponent<AudioSource>().isPlaying==true)
            {
                gameObject.GetComponent<AudioSource>().Stop();
            }
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            sound_player.GetComponent<AudioSource>().PlayOneShot(accident);
            Destroy(collision.gameObject);
            can--;
            bar.GetComponent<bar_sc>().can_olay();
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            sound_player.GetComponent<AudioSource>().PlayOneShot(get_coin);
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
            coin.text ="X"+ PlayerPrefs.GetInt("coin").ToString();
        }        
        if (collision.gameObject.CompareTag("finish"))
        {
            sound_player.GetComponent<AudioSource>().PlayOneShot(success);
            level_al.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
