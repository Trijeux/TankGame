// Script by : Nanatchy

using UnityEngine;
public class TargetPlayer : MonoBehaviour
{
    #region Attributs
    
    public bool playerIsHere = false;
    
    #endregion

    #region Methods

    #endregion

    #region Behaviors

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsHere = false;
        }
    }
    
    
    #endregion
}
