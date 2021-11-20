using SALT;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace InfiniteJump
{
    public class Main : ModEntryPoint
    {
        // THE EXECUTING ASSEMBLY
        public static Assembly execAssembly;

        // Called before MainScript.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            // Gets the Assembly being executed
            execAssembly = Assembly.GetExecutingAssembly();
            HarmonyInstance.PatchAll(execAssembly);
        }


        // Called before MainScript.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            UserInputService.Instance.InputBegan += InputBegan;
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {

        }

        private static List<KeyCode> jumpKeys = new List<KeyCode>
        {
            KeyCode.Space,
            KeyCode.W,
            KeyCode.UpArrow
        };

        public void InputBegan(UserInputService.InputObject inputObject, bool wasProcessed)
        {
            if (jumpKeys.Contains(inputObject.keyCode))
            {
                PlayerScript.player.canJump = true;
                PlayerScript.player.JumpTrigger();
            }
        }
    }
}