using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magatama : MonoBehaviour
{
    [SerializeField]AudioSource magatamaSE;

    private void Start()
    {
        magatamaSE = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.2f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(magatamaSE.clip, transform.position);

            Destroy(gameObject);
        }
        GameManager.Instance.AddMagatama();
     
        
    }
}
