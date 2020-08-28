using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;

namespace UTalDrawSystem.MyGame
{
    class Boton_MainMenu : Base_Boton
    {
        public Boton_MainMenu(string texture, Vector2 pos, bool habilitado, float escala = 1, bool visible = true) : base(texture, pos, habilitado, escala, visible)
        {
        }

        //el bool time, sirve para bloquear el boton play y obligar al usuario a leer las instrucciones antes de jugar
        public void Update(GameTime gameTime, bool time = true)
        {
            if (SobreMi() == false && habilitado == true)
            {
                SetColor(Color.White);
            }
            else
            {
                SetColor(Color.Gray);
            }
            if (Clickeado() == true)
            {
                new EscenaMenu(time);
            }
        }
    }
}
