using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Roronoa_TXT_RPG;

namespace Roronoa_TXT_RPG
{
    class SceneManager
    {
        public static SceneManager? instance { get; private set; }

        private Scene? _curScene;

        public static void InitSceneManager()
        {
            if (instance == null)
            {
                instance = new SceneManager();
                instance.SceneChange(SCENE_TYPE.SCENE_LOBY);
            }
        }

        public void SceneChange(SCENE_TYPE sceneType)
        {
            switch (sceneType)
            {
                case SCENE_TYPE.SCENE_LOBY:
                    _curScene = new SceneLoby();
                    break;
                case SCENE_TYPE.SCENE_STATUS:
                    _curScene = new SceneStatus();
                    break;
                case SCENE_TYPE.SCENE_BATTLE:
                    _curScene = new SceneBattle();
                    break;
                case SCENE_TYPE.SCENE_QUEST:
                    _curScene = new SceneQuest();
                    break;
            }
        }
        
        public void SceneUpdate()
        {
            if (_curScene != null)
                _curScene.SceneUpdate();
        }
    }
}
