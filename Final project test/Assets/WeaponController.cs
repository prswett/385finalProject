using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    // Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			EnemyHealth health = other.GetComponent<EnemyHealth> ();
            // calculating the damage the enemy will take depending on the weapon
            string cT = this.gameObject.tag;
            if(cT == "sword")
            {
                health.takeDamage(2);
            }
            else if (cT == "spear")
            {
                health.takeDamage(3);
            }
            else if (cT == "axe")
            {
                health.takeDamage(5);
            }
            else if (cT == "dagger")
            {
                health.takeDamage(1);
            }
            else
            {
                health.takeDamage(1);
            }
        }
	}
}
