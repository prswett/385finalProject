using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamager : MonoBehaviour {

    public float damage = 5f;

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("OnSpikes");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine("OnSpikes");
        }
    }

    private IEnumerator OnSpikes()
    {
        while (true)
        {
			PlayerStatistics.health -= ((PlayerStatistics.maxHealth / 100) * 5);
            yield return new WaitForSeconds(1f);
        }
    }
}
