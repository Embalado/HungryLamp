using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public int ID;
    public GameObject sprite;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerMovement.CanLoad == true)
        {
            if (ID == 1)
            {

                if (PlayerPrefs.GetInt("Key-1") == 1)
                {
                    sprite.SetActive(true);
                    Destroy(gameObject);
                   
                }

            }
            else if (ID == 2)
            {
                if (PlayerPrefs.GetInt("Key-2") == 1)
                {
                    sprite.SetActive(true);
                    Destroy(gameObject);
                   
                }

            }
            else if (ID == 3)
            {

                if (PlayerPrefs.GetInt("Key-3") == 1)
                {
                    sprite.SetActive(true);
                    Destroy(gameObject);
                    
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.6f, 0.0f, Space.Self);
    }
    private void OnTriggerEnter(Collider n)
    {
        if (n.gameObject.tag == "Player")
        {
            if (ID == 1)
            {

                PlayerPrefs.SetInt("Key-1Aux", 1);

            }
            else if (ID == 2)
            {

                PlayerPrefs.SetInt("Key-2Aux", 1);

            }
            else if (ID == 3)
            {


                PlayerPrefs.SetInt("Key-3Aux", 1);
            }
            sprite.SetActive(true);
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        

    }
}
