using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ColourChangeGround : MonoBehaviour
{
    public int randomColour; //this is an int 

    public List<Color> colours = new List<Color>(); //creates list of colours

    public void Awake()
    {
        //Adding these 3 colours to the list
        colours.Add(Color.red); 
        colours.Add(Color.blue);
        colours.Add(Color.yellow);
    }

    // Start is called before the first frame update
    public void Start()
    {
        while (colours.Count > 0)
        {
            foreach (Transform child in transform)
            {
                Renderer renderer = child.GetComponent<Renderer>(); //gets the renderer frin the childre // problem is its only getting the renderer from the first child
                randomColour = UnityEngine.Random.Range(0, colours.Count); //sets the int to a random range from 0 to the amount of colours left
                renderer.material.color = colours[randomColour]; //sets the renderer to the random colour which is chose above in the int
                colours.Remove(colours[randomColour]); //then it removes the colour from the list so it can no longer be selected again

                Debug.Log(child.GetComponent<Renderer>().material.color);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
