using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;

namespace UTalDrawSystem.MyGame
{
    class EscenaFinal:Escena
    {
        Boton_Play replay;
        Boton_MainMenu mainMenu;
        Dibujable moneda;
        Texteable puntaje;
        Texteable titulo;
        Texteable bestScore;

        public EscenaFinal(int contador)
        {
            replay = new Boton_Play("Boton_Replay", new Vector2(475, 700), true);
            mainMenu = new Boton_MainMenu("Boton_MainMenu", new Vector2(750, 700), true);
            titulo = new Texteable("FuenteA", new Vector2(600, 300), 3, "FIN DEL JUEGO");
            bestScore = new Texteable("FuenteA", new Vector2(600, 550), 1, "puntaje obtenido");
            moneda = new Dibujable("Moneda", new Vector2(550, 600), 0.5f);
            puntaje = new Texteable("FuenteA", new Vector2(750, 600), 2, "" + contador);
        }
        public override void Update(GameTime gameTime)
        {
            replay.Update(gameTime);
            mainMenu.Update(gameTime);
        }
    }
}
