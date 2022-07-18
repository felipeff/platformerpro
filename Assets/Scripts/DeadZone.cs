using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                CharacterController cc = other.GetComponent<CharacterController>();

                if (cc != null)
                {
                    other.transform.position = _respawnPoint.transform.position;
                    cc.enabled = false;
                    player.RemoveLife();
                    StartCoroutine(CCEnableRoutine(cc));
                }
                    
            }
        }
    }


    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
