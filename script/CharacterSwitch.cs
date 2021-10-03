using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterSwitch : MonoBehaviour
{
    public TextMeshProUGUI JojoButton, PinkButton, DreamButton, VrButton, MaskButton, FroggerButton,MayuhButton;
    public GameObject jojoCharacter, pinkguycharacter,DreamtCharacter,MaskDudeCharacter,VRManCharacter,FroggerCharacter,MayuhCharacter;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Update()
    {
        string CharacterSelected = PlayerPrefs.GetString("CharacterSelected");
        switch (CharacterSelected)
        {

            case "JoJo":
                /// jojoCharacter.GetComponent<SpriteRenderer>().enabled = true;
                ///pinkguycharacter.GetComponent<SpriteRenderer>().enabled = false;
                jojoCharacter.SetActive(true);
                pinkguycharacter.SetActive(false);
                DreamtCharacter.SetActive(false);
                MaskDudeCharacter.SetActive(false);
                VRManCharacter.SetActive(false);
                FroggerCharacter.SetActive(false);
                MayuhCharacter.SetActive(false);
                JojoButton.text = "Selected";
                PinkButton.text = "Select";
                DreamButton.text = "Select";
                VrButton.text = "Select";
                MaskButton.text = "Select";
                FroggerButton.text = "Select";
                MayuhButton.text = "Select";
                break;

            case "PinkGuy":
                jojoCharacter.SetActive(false);
                pinkguycharacter.SetActive(true);
                DreamtCharacter.SetActive(false);
                MaskDudeCharacter.SetActive(false);
                VRManCharacter.SetActive(false);
                FroggerCharacter.SetActive(false);
                MayuhCharacter.SetActive(false);
                JojoButton.text = "Select";
                PinkButton.text = "Selected";
                DreamButton.text = "Select";
                VrButton.text = "Select";
                MaskButton.text = "Select";
                FroggerButton.text = "Select";
                MayuhButton.text = "Select";
                // pinkguycharacter.GetComponent<SpriteRenderer>().enabled = true;
                // jojoCharacter.GetComponent<SpriteRenderer>().enabled = true;

                break;
            case "Dreamt":
                jojoCharacter.SetActive(false);
                pinkguycharacter.SetActive(false);
                DreamtCharacter.SetActive(true);
                MaskDudeCharacter.SetActive(false);
                VRManCharacter.SetActive(false);
                FroggerCharacter.SetActive(false);
                MayuhCharacter.SetActive(false);
                JojoButton.text = "Select";
                PinkButton.text = "Select";
                DreamButton.text = "Selected";
                VrButton.text = "Select";
                MaskButton.text = "Select";
                FroggerButton.text = "Select";
                MayuhButton.text = "Select";
                break;

            case "MaskDude":
                jojoCharacter.SetActive(false);
                pinkguycharacter.SetActive(false);
                DreamtCharacter.SetActive(false);
                MaskDudeCharacter.SetActive(true);
                VRManCharacter.SetActive(false);
                FroggerCharacter.SetActive(false);
                MayuhCharacter.SetActive(false);
                JojoButton.text = "Select";
                PinkButton.text = "Select";
                DreamButton.text = "Select";
                VrButton.text = "Select";
                MaskButton.text = "Selected";
                FroggerButton.text = "Select";
                MayuhButton.text = "Select";


                break;
            case "VRMan":
                jojoCharacter.SetActive(false);
                pinkguycharacter.SetActive(false);
                DreamtCharacter.SetActive(false);
                MaskDudeCharacter.SetActive(false);
                VRManCharacter.SetActive(true);
                FroggerCharacter.SetActive(false);
                MayuhCharacter.SetActive(false);
                JojoButton.text = "Select";
                PinkButton.text = "Select";
                DreamButton.text = "Select";
                VrButton.text = "Selected";
                MaskButton.text = "Select";
                FroggerButton.text = "Select";
                MayuhButton.text = "Select";
                break;

            case "Frogger":
                jojoCharacter.SetActive(false);
                pinkguycharacter.SetActive(false);
                DreamtCharacter.SetActive(false);
                MaskDudeCharacter.SetActive(false);
                VRManCharacter.SetActive(false);
                MayuhCharacter.SetActive(false);
                FroggerCharacter.SetActive(true);
                JojoButton.text = "Select";
                PinkButton.text = "Select";
                DreamButton.text = "Select";
                VrButton.text = "Select";
                MaskButton.text = "Select";
                FroggerButton.text = "Selected";
                MayuhButton.text = "Select";
                break;

            case "Mayuh":

                jojoCharacter.SetActive(false);
                pinkguycharacter.SetActive(false);
                DreamtCharacter.SetActive(false);
                MaskDudeCharacter.SetActive(false);
                VRManCharacter.SetActive(false);
                MayuhCharacter.SetActive(true);
                FroggerCharacter.SetActive(false);
                JojoButton.text = "Select";
                PinkButton.text = "Select";
                DreamButton.text = "Select";
                VrButton.text = "Select";
                MaskButton.text = "Select";
                FroggerButton.text = "Select";
                MayuhButton.text = "Selected";

                break;

        }
    }
    // Update is called once per frame

}
