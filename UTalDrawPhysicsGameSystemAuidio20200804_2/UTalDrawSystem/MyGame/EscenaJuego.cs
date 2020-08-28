using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaAudio;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaFisico;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    public class EscenaJuego:Escena
    {
        static public bool pausado;
        Dibujable reloj;
        Texteable tiempo;
        Dibujable moneda;
        Texteable puntaje;
        Boton_Pause pause;
        Boton_MainMenu menu;
        int contador;
        double tiempoJuego;

        public EscenaJuego()
        {
            tiempoJuego = 30;
            contador = 0;
            
            UTGameObject rana = new Player();
            new Coleccionable("Moneda", new Vector2(500, 500), .5f, UTGameObject.FF_form.Circulo);
            new UTGameObject("Barrera_Arriba", new Vector2(600, 100), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Barrera_Abajo", new Vector2(600, 850), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Barrera_Izq", new Vector2(1150, 500), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Barrera_Der", new Vector2(50, 500), 1, UTGameObject.FF_form.Rectangulo, true);
            pause = new Boton_Pause("Boton_Pause", new Vector2(1050, 100), true);
            menu = new Boton_MainMenu("Boton_MainMenu", new Vector2(750, 700), true, 1, false);

            reloj = new Dibujable("Timer", new Vector2(100, 75), 0.5f);
            tiempo = new Texteable("FuenteA", new Vector2(175, 75), 2, "" + (int)tiempoJuego);
            moneda = new Dibujable("Moneda", new Vector2(100, 130), 0.5f);
            puntaje = new Texteable("FuenteA", new Vector2(175, 130), 2, "" + contador);

            
        }
        public override void Update(GameTime gameTime)
        {
            pause.Update(gameTime);

            if (tiempoJuego > 0)
            {
                menu.SetVisible(pause.GetPausado());
                pausado = pause.GetPausado();
                if (pause.GetPausado() == true)
                {
                    menu.Update(gameTime);
                }
                else
                {
                    string newText = "" + (int)tiempoJuego;
                    tiempo.SetText(newText);
                    tiempoJuego = tiempoJuego - gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            else if (tiempoJuego <= 0)
            {
                new EscenaFinal(contador);
            }
        }

        public void AddScore()
        {
            contador++;
            string newText = "" + (int)contador;
            puntaje.SetText(newText);
        }
    }
}
