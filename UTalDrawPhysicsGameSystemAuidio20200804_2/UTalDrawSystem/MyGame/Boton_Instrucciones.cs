using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;

namespace UTalDrawSystem.MyGame
{
    class Boton_Instrucciones:Base_Boton
    {
        public Boton_Instrucciones(string texture, Vector2 pos, bool habilitado, float escala = 1, bool visible = true) : base(texture, pos, habilitado, escala, visible)
        {
        }
        public void Update(GameTime gameTime)
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
                new EscenaInstrucciones();
            }
        }
    }
}
