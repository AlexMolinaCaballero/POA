using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using UTalDrawSystem.SistemaAudio;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Player : UTGameObject
    {
        bool habilitado;
        public Player() : base("Ranita", new Vector2(600, 700), 1, UTGameObject.FF_form.Circulo, true)
        {
            habilitado = true;
        }
        public override void Update(GameTime gameTime)
        {
            if(EscenaJuego.pausado == true)
            {
                return;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if(rot <= 2f)
                {
                    rot += (float)gameTime.ElapsedGameTime.TotalSeconds * 10;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if(rot >= -2f)
                {
                    rot -= (float)gameTime.ElapsedGameTime.TotalSeconds * 10;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && habilitado == true)
            {
                Shoot();
                habilitado = false;
            }
            else if(Keyboard.GetState().IsKeyUp(Keys.W))
            {
                habilitado = true;
            }
            
        }
        public override void OnCollision(UTGameObject other)
        {
            Coleccionable col = other as Coleccionable;
            if (col != null)
            {
                col.Destroy();
                AudioManager.Play(AudioManager.Sounds.Mystic);
            }
            else
            {
                //Sonido si choca con objetos no coleccionables
            }
        }
        Vector2 Rotate(Vector2 v, double degrees)
        {
            float sin = (float)Math.Sin(degrees);
            float cos = (float)Math.Cos(degrees);

            float tx = v.X;
            float ty = v.Y;
            v.X = (cos * tx) - (sin * ty);
            v.Y = (sin * tx) + (cos * ty);
            return v;
        }

        public void Shoot()
        {
            Vector2 frente = Rotate(new Vector2(0,-1), rot);
            frente *= 60;
            new Bullet(frente + pos, rot);

        }
    }
}