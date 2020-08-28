using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UTalDrawSystem.SistemaAudio;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Bullet : UTGameObject
    {
        Vector2 oldVel;
        double tiempoVida;
        Random rand = new Random();

        public Bullet(Vector2 pos, float degree) : base("Bala", pos, 1, UTGameObject.FF_form.Circulo, false)
        {
            oldVel = Vector2.Zero;
            var direccion = Rotate(new Vector2(0, -1), degree);
            objetoFisico.SetVelocity(direccion * 60f);
            tiempoVida = 2;
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

        public override void OnCollision(UTGameObject other)
        {
            Coleccionable col = other as Coleccionable;
            if (col != null)
            {
                col.Destroy();
                new Coleccionable("Moneda", new Vector2(rand.Next(200, 700), rand.Next(300, 600)), .5f, UTGameObject.FF_form.Circulo);
                AudioManager.Play(AudioManager.Sounds.Mystic);
                try
                {
                    ((EscenaJuego)Escena.INSTANCIA).AddScore();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error por usar lo anterior en una escena distinta a \"EscenaJuego\"");
                    Console.WriteLine(ex.StackTrace);
                }
                
            }
            else
            {
                //Sonido si choca con objetos no coleccionables
            }
        }

        public override void Update(GameTime gameTime)
        {
            if(EscenaJuego.pausado == true)
            {
                if(oldVel == Vector2.Zero)
                {
                    oldVel = objetoFisico.vel;
                    objetoFisico.SetVelocity(Vector2.Zero);
                }
                return;
            }
            else
            {
                if(oldVel != Vector2.Zero)
                {
                    objetoFisico.SetVelocity(oldVel);
                    oldVel = Vector2.Zero;
                }
            }
            if (tiempoVida > 0)
            {
                tiempoVida = tiempoVida - gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                objetoFisico.Destruir();
                dibujable.Destruir();
            }
        }
    }
}
