using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Scripts.Classes
{
    class Character
    {
        private GameObject sceneObject;
        private string name;

        public Character(GameObject g)
        {
            sceneObject = g;
            name = g.name;
        }

        public GameObject SceneObject
        {
            get
            {
                return sceneObject;
            }
            /* set
            {
                sceneObject = value;
            } */
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
