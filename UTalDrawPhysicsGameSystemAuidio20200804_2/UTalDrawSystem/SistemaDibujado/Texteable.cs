using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem.SistemaDibujado
{
    public class Texteable
    {
        private SpriteFont fuente;
        public string texto;
        public Color color;
        public Vector2 pos;
        private Vector2 centro;
        public float escala;
        public int ancho { get { return (int)(this.fuente.MeasureString(texto).X * this.escala); } set { escala = this.fuente.MeasureString(texto).X / value; } }
        public int alto { get { return (int)(this.fuente.MeasureString(texto).Y * this.escala); } set { escala = this.fuente.MeasureString(texto).Y / value; } }
        public float rot;
        public Texteable(string fuenteNombre, Vector2 pos, float escala, string texto)
        {
            this.pos = pos;
            this.escala = escala;
            this.texto = texto;
            this.fuente = Game1.INSTANCE.Content.Load<SpriteFont>(fuenteNombre);
            Escena.INSTANCIA.agregarTex(this);
            this.centro = fuente.MeasureString(texto) / 2;
            this.color = Color.Black;
        }
        public void Destruir()
        {
            Escena.INSTANCIA.removerTex(this);
        }

        public void SetText(string newText)
        {
            texto = newText;
        }

        public void Draw(SpriteBatch SB, Vector2 camaraPos, float camaraRot, float camaraScale)
        {
            SB.DrawString(fuente, texto, pos, color, 0, centro, escala, SpriteEffects.None, 0);
        }

        public Vector2 Rotate(Vector2 v, double degrees)
        {
            float sin = (float)Math.Sin(degrees);
            float cos = (float)Math.Cos(degrees);

            float tx = v.X;
            float ty = v.Y;
            v.X = (cos * tx) - (sin * ty);
            v.Y = (sin * tx) + (cos * ty);
            return v;
        }
    }
}
