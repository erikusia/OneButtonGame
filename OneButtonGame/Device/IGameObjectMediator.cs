using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Acter;

namespace OneButtonGame.Device
{
    interface IGameObjectMediator
    {
        //ゲームオブジェクトの追加
        void AddGameObject(GameObject gameObject);

        //プレイヤーが死んでいるか？
        GameObject GetPlayer();

        //プレイヤーの取得
        bool IsPlayerDead();

        void AddActor(GameObject gameObject);
    }
}
