using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChochinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //anim
        Invoke(nameof(ChochinDestroy), 5f);
    }

    void ChochinDestroy()
    {
        GameManager.Instance._isChouchinSpawnning = false;
        Destroy(gameObject);
    }
}
