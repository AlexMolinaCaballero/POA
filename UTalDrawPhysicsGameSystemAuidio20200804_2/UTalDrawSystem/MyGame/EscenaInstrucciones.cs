using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;

namespace UTalDrawSystem.MyGame
{
    public class EscenaInstrucciones :Escena
    {
        Texteable instruccionesTitulo;
        Dibujable coin;
        Dibujable teclaA;
        Dibujable teclaD;
        Dibujable teclaW;
        Texteable cuerpoL1;
        Texteable cuerpoL2;
        Texteable cuerpoL4;
        Dibujable timer;
        Texteable cuerpoL3;
        Boton_MainMenu mainMenu;
        public EscenaInstrucciones()
        {
            instruccionesTitulo = new Texteable("FuenteA", new Vector2(600, 100), 2, "INSTRUCCIONES");
            coin = new Dibujable("Moneda", new Vector2(100, 200), 0.5f);
            cuerpoL1 = new Texteable("FuenteA", new Vector2(650, 200), 1, "-apunta y dispara a las monedas para conseguir el mejor puntaje");
            teclaA = new Dibujable("Tecla_A", new Vector2(75, 275), 1);
            teclaD = new Dibujable("Tecla_D", new Vector2(125, 275), 1);
            cuerpoL2 = new Texteable("FuenteA", new Vector2(645, 275), 1, "-utiliza las teclas \"A\" y \"D\" para rotar y apuntar a tu objetivo");
            teclaW = new Dibujable("Tecla_W", new Vector2(100, 350), 1);
            cuerpoL3 = new Texteable("FuenteA", new Vector2(680, 350), 1, "-utiliza la tecla \"W\" para disparar burbujas y asi conseguir monedas");
            timer = new Dibujable("Timer", new Vector2(100, 425), 0.5f);
            cuerpoL4 = new Texteable("FuenteA", new Vector2(620, 425), 1, "-consigue el mejor puntaje antes de que se acabe el tiempo");
            mainMenu = new Boton_MainMenu("Boton_MainMenu", new Vector2(150, 800), true);
        }
        public override void Update(GameTime gameTime)
        {
            mainMenu.Update(gameTime);
        }
    }
}
