using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterController : MonoBehaviour
{
    public GameObject Player;

    public Rigidbody rigidBody;

    public RayCasts rayCasts;
    public ColourChangeGround colourChangeGround;
    public InstantiatePlatform instantiatePlatform;

    public List<Color> colours = new List<Color>();
    public int randomColour;

    public float speed;

    public bool moved;

    private void Awake()
    {
        colours.Add(Color.red);
        colours.Add(Color.blue);
        colours.Add(Color.yellow);
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<Renderer>().material.color = Color.blue;
        rayCasts = Player.GetComponentInParent<RayCasts>();
        colourChangeGround = instantiatePlatform.colourChangeGround;
        rigidBody = Player.GetComponentInParent<Rigidbody>();
        speed = 1.5f;
        randomColour = UnityEngine.Random.Range(0, colours.Count);
        Player.GetComponent<Renderer>().material.color = colours[randomColour];
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Jump();
        
        if(moved == true)
        {
            Debug.Log(moved);
            randomColour = UnityEngine.Random.Range(0, colours.Count);
            Player.GetComponent<Renderer>().material.color = colours[randomColour];
            instantiatePlatform.InstantiatePlatforms();
            moved = false;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && rayCasts.canLeft == true)
        {
            Debug.Log("1 pressed");
            if (rayCasts.leftHit.transform.gameObject.GetComponent<Renderer>().material.color == Player.GetComponent<Renderer>().material.color)
            {
                Debug.Log("Jumped");
                transform.position = Vector3.MoveTowards(transform.position, rayCasts.leftHit.point, 100);
                moved = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && rayCasts.canLeft == true)
        {
            Debug.Log("2 pressed");
            if (rayCasts.fowardHit.transform.gameObject.GetComponent<Renderer>().material.color == Player.GetComponent<Renderer>().material.color)
            {
                Debug.Log("Jumped");
                transform.position = Vector3.MoveTowards(transform.position, rayCasts.fowardHit.point, 100);
                moved = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && rayCasts.canLeft == true)
        {
            Debug.Log("3 pressed");
            if (rayCasts.rightHit.transform.gameObject.GetComponent<Renderer>().material.color == Player.GetComponent<Renderer>().material.color)
            {
                Debug.Log("Jumped");
                transform.position = Vector3.MoveTowards(transform.position, rayCasts.rightHit.point, 100);
                moved = true;
            }
        }
    }
}
