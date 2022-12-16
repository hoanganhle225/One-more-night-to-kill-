using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenDie : MonoBehaviour
{    
	public GameObject healthBoss;
    bool existed = true;
    // Start is called before the first frame update
    void Start()
    {
		healthBoss.SetActive(false);  
    }

    
	public void Update()
    {
        existed = GameObject.FindGameObjectWithTag("Enemy");
        if(!existed)
        {
            healthBoss.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
