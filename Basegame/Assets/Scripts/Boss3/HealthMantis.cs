using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMantis : MonoBehaviour
{
    public Mantis mantis;
    public Transform transfHealthMantis;
    private Slider slider;
    float fillvalue;
    void Start()
    {
        slider = GetComponent<Slider>();
        // transfHealthMantis = GameObject.FindGameObjectWithTag("TransformHealthMantis").GetComponent<Transform>();
        // mantis = GameObject.FindGameObjectWithTag("Mantis").GetComponent<Mantis>();
    }

    // Update is called once per frame
    void Update()
    {
        // cố định thanh máu nằm ở trên đầu Mantis
        transform.position = transfHealthMantis.position;
        // set thanh máu theo máu hiện tại của Mantis
        fillvalue = mantis.currentHealth / mantis.maxHealth;
        slider.value = fillvalue;
        // Boss chết thì tự hủy thanh máu
        if (slider.value <= 0){
            Destroy(this.gameObject);
        }
    }
}
