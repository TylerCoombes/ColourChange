using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlatform : MonoBehaviour
{
    public GameObject platform;
    public GameObject Player;

    public Vector3 currentPos;
   
    public CharacterController characterController;
    public ColourChangeGround colourChangeGround;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        characterController = Player.GetComponent<CharacterController>();
        currentPos = new Vector3(0.0f, 0.0f, -3f);
        Instantiate(platform, currentPos += new Vector3(0, 0, 5), Quaternion.identity);

        colourChangeGround = platform.GetComponent<ColourChangeGround>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiatePlatforms()
    {
        Instantiate(platform, Player.transform.position + new Vector3(0, 0, 4), Quaternion.identity);
    }
}
