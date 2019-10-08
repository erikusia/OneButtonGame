﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;//Assert用

namespace OneButtonGame.Device
{
    class Renderer
    {
        private ContentManager contentManager; //コンテンツ管理者
        private GraphicsDevice graphicsDevice; //グラフィック機器
        private SpriteBatch spriteBatch; //スプライト一括描画用オブジェクト
        private SpriteBatch spriteBatch2; //スプライト一括描画用オブジェクト
        private RenderTarget2D target2D;//2D用レンダーターゲット
        private Vector2 textureCenter;

        //複数画像管理用変数の宣言と生成
        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="content">Game1クラスのコンテンツ管理者</param>
        /// <param name="graphics">Game1クラスのグラフィック機器</param>
        public Renderer(ContentManager content, GraphicsDevice graphics)
        {
            contentManager = content;
            graphicsDevice = graphics;
            spriteBatch = new SpriteBatch(graphicsDevice);
            spriteBatch2 = new SpriteBatch(graphicsDevice);
        }

        /// <summary>
        /// 画像の読み込み
        /// </summary>
        /// <param name="assetName">アセット名（ファイルの名前）</param>
        /// <param name="filepath">画像へのファイルパス</param>
        public void LoadContent(string assetName, string filepath = "./")
        {
            //すでにキー（assetName：アセット名）が登録されているとき
            if (textures.ContainsKey(assetName))
            {
#if DEBUG //DEBUGモードの時のみ下記エラー分をコンソールへ表示
                Console.WriteLine(assetName + "はすでに読み込まれています。\n プログラムを確認してください。");
#endif

                //それ以上読み込まないのでここで終了
                return;
            }
            //画像の読み込みとDictionaryへアセット名と画像を登録
            textures.Add(assetName, contentManager.Load<Texture2D>(filepath + assetName));

        }

        /// <summary>
        /// アンロード
        /// </summary>
        public void Unload()
        {
            textures.Clear();//Dictionaryの情報をクリア
        }

        /// <summary>
        /// 描画開始
        /// </summary>
        public void Begin()
        {
            spriteBatch.Begin();
            spriteBatch2.Begin();
        }

        /// <summary>
        /// 描画終了
        /// </summary>
        public void End()
        {
            spriteBatch.End();
            spriteBatch2.End();
        }

        /// <summary>
        /// 画像の描画（画像サイズはそのまま）
        /// </summary>
        /// <param name="assetName">アセット名</param>
        /// <param name="position">位置</param>
        /// <param name="alpha">透明値（1.0f：不透明 0.0f：透明）</param>
        public void DrawTexture(string assetName, Vector2 position, float alpha = 1.0f)
        {
            //デバッグモードの時のみ、画像描画前のアセット名チェック
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体できていません");

            spriteBatch.Draw(textures[assetName], position, Color.White * alpha);
            spriteBatch2.Draw(textures[assetName], position, Color.White * alpha);
        }

        /// <summary>
        /// 画像の描画（画像を指定範囲内だけ描画）
        /// </summary>
        /// <param name="assetName">アセット名</param>
        /// <param name="position">位置</param>
        /// <param name="rect">指定範囲</param>
        /// <param name="alpha">透明値</param>
        public void DrawTexture(string assetName, Vector2 position, Rectangle rect, float alpha = 1.0f)
        {
            //デバッグモードの時のみ、画像描画前のアセット名チェック
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体できていません");

            spriteBatch.Draw(
                textures[assetName], //テクスチャ
                position,            //位置
                rect,                //指定範囲（矩形で指定：左上の座標、幅、高さ）
                Color.White * alpha);//透明値

            spriteBatch2.Draw(
               textures[assetName], //テクスチャ
               position,            //位置
               rect,                //指定範囲（矩形で指定：左上の座標、幅、高さ）
               Color.White * alpha);//透明値
        }

        public void DrawTexture(string assetName, Vector2 position, Color color, float alpha = 1.0f)
        {
            //デバッグモード時のみ、画像描画前のアセット名チェック
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、" +
                "画像の読み込み自体できていません");

            spriteBatch.Draw(textures[assetName], position, color * alpha);
            spriteBatch2.Draw(textures[assetName], position, color * alpha);
        }

        /// <summary>
        /// 数字の描画
        /// </summary>
        /// <param name="assetName">数字画像の名前</param>
        /// <param name="position">位置</param>
        /// <param name="number">表示したい整数値</param>
        /// <param name="alpha">透明値</param>
        public void DrawNumber(
            string assetName,
            Vector2 position,
            int number,
            float alpha = 1.0f)
        {
            //デバッグモード時のみ、画像描画前のアセット名をチェック
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、" +
                "画像の読み込み自体できません");

            //マイナスの数は0
            if (number < 0)
            {
                number = 0;
            }

            int width = 32;//画像横幅

            //数字を文字列化し、1文字ずつ取り出す
            foreach (var n in number.ToString())
            {
                //文字のテクスチャが数字１つにつき幅３２高さ６４
                //文字と文字を引き算し、整数値を取得している
                spriteBatch.Draw(
                    textures[assetName],
                    position,
                    new Rectangle((n - '0') * width, 0, width, 64),
                    Color.White);

                spriteBatch2.Draw(
                    textures[assetName],
                    position,
                    new Rectangle((n - '0') * width, 0, width, 64),
                    Color.White);

                //１文字描画したら１桁分右にずらす
                position.X += width;
            }
        }

        public void DrawNumber(
            string assetName,
            Vector2 position,
            float number,
            float alpha = 1.0f)
        {
            //マイナスは0へ
            if (number < 0.0f)
            {
                number = 0.0f;
            }

            int width = 32;//数字画像１つ分の横幅
            //少数部は２桁まで、整数部が１桁の時は０で埋める
            foreach (var n in number.ToString("00"))
            {
                //少数の「.」か？
                if (n == '.')
                {
                    spriteBatch.Draw(
                        textures[assetName],
                        position,
                        new Rectangle(10 * width, 0, width,
                        64),//ピリオドは１０番目
                        Color.White * alpha);

                    spriteBatch2.Draw(
                        textures[assetName],
                        position,
                        new Rectangle(10 * width, 0, width,
                        64),//ピリオドは１０番目
                        Color.White * alpha);
                }
                else
                {
                    //数字の描画
                    spriteBatch.Draw(
                        textures[assetName],
                        position,
                        new Rectangle((n - '0') * width, 0, width, 64),
                        Color.White * alpha);

                    spriteBatch2.Draw(
                        textures[assetName],
                        position,
                        new Rectangle((n - '0') * width, 0, width, 64),
                        Color.White * alpha);
                }

                //１文字描画したら１桁分右にずらす
                position.X += width;
            }
        }

        public void LoadContent(string assetName, Texture2D texture)
        {
            //すでにキー（assetName:アセット名）が登録されているとき
            if (textures.ContainsKey(assetName))
            {
#if DEBUG  //DEBUGモードの時のみ下記エラー分をコンソールへ表示
                Console.WriteLine(assetName + "はすでに読み込まれています。\n" + " プログラムを確認してください。");

#endif

                //それ以上読み込まないのでここで終了
                return;
            }

            textures.Add(assetName, texture);
        }



        public void DrawTexture(
            string assetname,
            Vector2 position,
            Rectangle? rect,//nullを受け入られるよう「？」で
            float rotate,
            Vector2 rotatePosition,
            Vector2 scale,
            SpriteEffects effects = SpriteEffects.None,
            float depth = 0.0f,
            float alpha = 1.0f)
        {
            spriteBatch.Draw(
                textures[assetname],//テクスチャ
                position, //位置
                rect, //切り取り範囲
                Color.White * alpha,　//透明値
                rotate,　　　　　　　//回転角度
                rotatePosition,      //回転軸
                scale,               //拡大縮小
                effects,             //表示反転効果
                depth                //スプライト深度
                );
        }

        public void DrawTexture2(
            string assetname,
            Vector2 position,
            Rectangle? rect,//nullを受け入られるよう「？」で
            float rotate,
            Vector2 rotatePosition,
            float scale,
            SpriteEffects effects = SpriteEffects.None,
            float depth = 0.0f,
            float alpha = 1.0f)
        {
            spriteBatch2.Draw(
            textures[assetname],//テクスチャ
                position, //位置
                rect, //切り取り範囲
                Color.White * alpha,　//透明値
                rotate,　　　　　　　//回転角度
                rotatePosition,      //回転軸
                scale,               //拡大縮小
                effects,             //表示反転効果
                depth
                );
        }



        /// <summary>
        /// レンダーターゲットの初期化
        /// テクスチャサイズの設定
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void InitializeRenderTarget(int width, int height)
        {
            target2D = new RenderTarget2D(graphicsDevice, width, height);
        }


        public void BeginRenderTarget()
        {
            //描画するレンダーターゲットを設定
            graphicsDevice.SetRenderTarget(target2D);
            //描画先のレンダーターゲットの内容を消す
            graphicsDevice.Clear(Color.Transparent);
            //レンダーターゲットへの描画開始
            spriteBatch.Begin();
        }

        public void EndRenderTarget()
        {
            //レンダーターゲットへの描画終了
            spriteBatch.End();
            //描画を画面に変える
            graphicsDevice.SetRenderTarget(null);
        }

        public void DrawRenderTargetTexture(
            Vector2 position,
            Rectangle? rect,
            float rotate,
            Vector2 rotatePosition,
            float scale,
            Color color,
            SpriteEffects effects = SpriteEffects.None,
            float depth = 0.0f
            )
        {
            spriteBatch.Draw(
                target2D,
                position,
                rect,
                color,
                rotate,
                rotatePosition,
                scale,
                effects,
                depth
                );
        }

        public void Begin(SpriteSortMode sortMode, BlendState blendState)
        {
            spriteBatch.Begin(sortMode, blendState);
        }

        public void RendCenter(Texture2D texture)
        {
            textureCenter = new Vector2(texture.Width / 2, texture.Height / 2);
        }
    }
}

