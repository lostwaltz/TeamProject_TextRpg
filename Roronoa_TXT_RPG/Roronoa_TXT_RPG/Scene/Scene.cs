using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum SCENE_TYPE { SCENE_LOBY, SCENE_STATUS, SCENE_BATTLE, SCENE_END }


namespace Roronoa_TXT_RPG
{
    internal abstract class Scene
    {
        protected int selectcNumber = -1;
         
        abstract public void SceneUpdate(); // 순수 가상 함수
    }
}

