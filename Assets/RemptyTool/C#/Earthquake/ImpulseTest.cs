using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ImpulseTest : MonoBehaviour
{
    public Transform player;

    public IEnumerator Shake(float duration, float magnitude)
    {   
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            //float y = Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(player.position.x+x, player.position.y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}