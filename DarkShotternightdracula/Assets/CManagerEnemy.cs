using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CManagerEnemy : MonoBehaviour
{
    private static CManagerEnemy _inst;
    /*public static CManagerEnemy Inst
    {
        get
        {
            if (_inst == null)
            {
                Inst = new GameObject("Game Manager");
                Inst.AddComponent<CManagerEnemy>();
                
                Inst = new GameObject("Game Manager");
                Inst
                
            }
            return _inst;
        }

    }
*/
   

    // Start is called before the first frame update
    void Start()
    {
        _inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
