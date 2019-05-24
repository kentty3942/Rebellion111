using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comonn : MonoBehaviour
{
    public enum JoyStickConfig
    {
        joystickHorizontal,
        joystickVertical,

        joystick1LeftHorizontal,
        joystick1LeftVertical,

        joystick1rightVertical,
        joystick1rightHorizontal,
        Num,
    }

    public const string joystickHorizontal = "joystickHorizontal";
    public const string joystickVertical = "joystickVertical";

    public const string joystick1LeftHorizontal = "joystick1LeftHorizontal";
    public const string joystick1LeftVertical = "joystick1LeftVertical";

    public const string joystick1rightHorizontal = "joystick1rightHorizontal";
    public const string joystick1rightVertical = "joystick1rightVertical";

    public string TagPlayer = "Player";
    public string TagGround = "Ground";

    public const float Speed = 5f;
}
