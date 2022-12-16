using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Enemy : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Transform Enemy_Transform;

	void Start()
    {
		slider = GetComponent<Slider>();      
        // Enemy_Transform = GameObject.FindGameObjectWithTag("Transform_Health_Enemy_1").GetComponent<Transform>();
    }

	void Update()
    {
		transform.position = new Vector3(Enemy_Transform.position.x, Enemy_Transform.position.y, 0);
    }

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

	}

	public void SetHealth(int health)
	{
		slider.value = health;
		if (slider.value <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
