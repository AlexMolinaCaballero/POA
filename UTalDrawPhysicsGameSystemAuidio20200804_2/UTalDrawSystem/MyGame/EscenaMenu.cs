using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
    public class EscenaMenu:Escena
    {
        Camara camara;
        Dibujable titulo;
        Boton_Salir salir;
        Boton_Play play;
        Boton_Creditos creditos;
        Boton_Instrucciones instrucciones;

        public EscenaMenu(bool time = true)
        {
            titulo = new Dibujable("Titulo", new Vector2(600, 300), 1.5f);
            creditos = new Boton_Creditos("Boton_Credits", new Vector2(225, 750), true);
            play = new Boton_Play("Boton_Play", new Vector2(475, 700), time);
            instrucciones = new Boton_Instrucciones("Boton_Instructions", new Vector2(725, 700), true);
            salir = new Boton_Salir("Boton_Exit", new Vector2(975, 750), true);
            AudioManager.PlaySong("Locations_Happy Village (loop)", loop: true);
            camara = new Camara(new Vector2(0, 0), 1, 0);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            creditos.Update(gameTime);
            play.Update(gameTime);
            salir.Update(gameTime);
            instrucciones.Update(gameTime);
        }
    }
}
