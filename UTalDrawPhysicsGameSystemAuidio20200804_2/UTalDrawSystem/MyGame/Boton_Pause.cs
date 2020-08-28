using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UTalDrawSystem.SistemaDibujado;

namespace UTalDrawSystem.MyGame
{
    class Boton_Pause : Base_Boton
    {
        private bool pausado;
        Vector2 pos1;
        Vector2 pos2;
        public Boton_Pause(string texture, Vector2 pos, bool habilitado, float escala = 1, bool visible = true) : base(texture, pos, habilitado, escala, visible)
        {
            pos1 = pos;
            pos2 = new Vector2(475, 700);
            pausado = false;
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
                if(pausado == false)
                {
                    SetPos(pos2);
                    SetTexture("Boton_Play");
                    pausado = true;
                }
                else
                {
                    SetPos(pos1);
                    SetTexture("Boton_Pause");
                    pausado = false;
                }
            }
        }

        public bool GetPausado()
        {
            return pausado;
        }
    }
}
