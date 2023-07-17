using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneretor : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy = null;
    [SerializeField] float _interval = 1f;

    float _timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
           
        }
    }

    IEnumerator OmenGene(float interval)
    {
        yield return new WaitForSeconds(interval);
        GameObject tyotin = GameObject.FindWithTag("Tyotin");

        if (!tyotin)
        {
            GameObject enemy = Instantiate(_enemy[0], this.transform.position, this.transform.rotation);

        }
    }
}
