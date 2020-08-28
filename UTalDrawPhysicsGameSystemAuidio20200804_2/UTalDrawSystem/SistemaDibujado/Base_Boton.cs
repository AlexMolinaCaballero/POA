using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem.SistemaDibujado
{
    public abstract class Base_Boton
    {
        protected bool habilitado;
        Dibujable botonDibujable;

        public bool MouseClick { get; private set; }

        protected Base_Boton(string texture, Vector2 pos, bool habilitado, float escala = 1, bool visible = true)
        {

            botonDibujable = new Dibujable(texture, pos, escala, visible);
            this.habilitado = habilitado;
            if(habilitado == false)
            {
                botonDibujable.color = Color.Gray;
            }
        }
        public void SetVisible(bool dato)
        {
            botonDibujable.visible = dato;
        }
        public void SetColor(Color newColor)
        {
            botonDibujable.color = newColor;
        }
        public bool SobreMi()
        {
            Vector2 posCursor = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            Vector2 posBotonInicial = new Vector2(botonDibujable.pos.X - (botonDibujable.ancho/2), botonDibujable.pos.Y - (botonDibujable.alto / 2));
            Vector2 posBotonFinal = new Vector2(posBotonInicial.X + botonDibujable.ancho, posBotonInicial.Y + botonDibujable.alto);

            if (posCursor.X >= posBotonInicial.X && posCursor.X <= posBotonFinal.X && posCursor.Y >= posBotonInicial.Y && posCursor.Y <= posBotonFinal.Y && habilitado == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Clickeado()
        {

            if (SobreMi() == true)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && MouseClick == false)
                {
                    MouseClick = true;
                }
                else if (Mouse.GetState().LeftButton == ButtonState.Released && MouseClick == true)
                {
                    MouseClick = false;
                    return true;
                }
                return false;
            }

            MouseClick = false;
            return false;
        }

        public void SetPos(Vector2 newPos)
        {
            botonDibujable.pos = newPos;
        }

        public void SetTexture(string newTexture)
        {
            botonDibujable.SetSkin(newTexture);
        }
    }
}
