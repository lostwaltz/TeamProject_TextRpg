using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Roronoa_TXT_RPG;
using static System.Formats.Asn1.AsnWriter;

namespace Roronoa_TXT_RPG
{
    enum SCENE_TYPE { SCENE_LOBY, SCENE_STATUS, SCENE_BATTLE, SCENE_QUEST, SCENE_END }

    class SceneManager
    {
        public static SceneManager? instance { get; private set; }

        private Scene? _curScene;
        private Scene[] _sceneList = new Scene[(int)SCENE_TYPE.SCENE_END];

        public static void InitSceneManager()
        {
            if (instance == null)
            {
                instance = new SceneManager();
                instance._sceneList[(int)SCENE_TYPE.SCENE_LOBY] = new SceneLoby();
                instance._sceneList[(int)SCENE_TYPE.SCENE_STATUS] = new SceneStatus();
                instance._sceneList[(int)SCENE_TYPE.SCENE_BATTLE] = new SceneBattle();
                instance._sceneList[(int)SCENE_TYPE.SCENE_QUEST] = new SceneQuest();

                instance.SceneChange(SCENE_TYPE.SCENE_LOBY);
            }
        }

        public void SceneChange(SCENE_TYPE sceneType)
        {
            _curScene = _sceneList[(int)sceneType];
        }
        
        public void SceneUpdate()
        {
            if (_curScene != null)
                _curScene.SceneUpdate();
        }
    }
}
