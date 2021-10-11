using UnityEngine;
using UnityEngine.UI;

public class SC_DamageReceiver : MonoBehaviour, IEntity
{
    //This script will keep track of player HP
    public float playerHP = 100;
    public FPSControllerLPFP.FpsControllerLPFP playerController;
    public Text finDelJuego;
    public GameObject player;
    public Camera secundaryCam;
    public void ApplyDamage(float points)
    {
        playerHP -= points;
        print(playerHP);
       
            if (playerHP <= 0)
            {
                //Player is dead
                playerController.canMove = false;
         Destroy(GameObject.Find("Assault_Rifle_01_Arms"));
            secundaryCam.enabled = true;
                print("MUERTO");
                playerHP = 0;
                finDelJuego.gameObject.SetActive(true);
            }
        
       
    }
}