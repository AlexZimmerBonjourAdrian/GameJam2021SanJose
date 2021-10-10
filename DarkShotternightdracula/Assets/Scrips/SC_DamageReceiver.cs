using UnityEngine;

public class SC_DamageReceiver : MonoBehaviour, IEntity
{
    //This script will keep track of player HP
    public float playerHP = 100;
    public FPSControllerLPFP.FpsControllerLPFP playerController;

    public void ApplyDamage(float points)
    {
        playerHP -= points;
        print(playerHP);
        if(playerHP <= 0)
        {
            //Player is dead
            playerController.canMove = false;
            playerHP = 0;

        }
    }
}