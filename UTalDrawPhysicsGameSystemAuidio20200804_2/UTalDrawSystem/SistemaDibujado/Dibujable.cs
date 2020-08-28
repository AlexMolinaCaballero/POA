using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem.SistemaDibujado
{
    public class Dibujable
    {
        private Texture2D textura;
        public bool visible;
        public Color color;
        public Vector2 pos;
        private Vector2 centro;
        public float escala;
        public int ancho { get { return (int)(this.textura.Width * this.escala); } set{ escala = this.textura.Width/value; }}
        public int alto { get { return (int)(this.textura.Height * this.escala); } set { escala = this.textura.Height / value; } }
        public float rot;

        public Dibujable(string texturaNombre, Vector2 pos, float escala, bool visible = true)
        {
            this.visible = visible;
            this.pos = pos;
            this.escala = escala;
            this.textura = Game1.INSTANCE.Content.Load<Texture2D>(texturaNombre);
            Escena.INSTANCIA.agregarDib(this);
            this.centro = new Vector2(this.textura.Width / 2, this.textura.Height / 2);
            this.color = Color.White;
        }
        public void Destruir()
        {
            Escena.INSTANCIA.removerDib(this);
        }

        public void Draw(SpriteBatch SB, Vector2 camaraPos, float camaraRot, float camaraScale)
        {
            if(visible == true)
            {
                SB.Draw(textura, Rotate(((pos - camaraPos) * camaraScale), camaraRot), null, color, camaraRot + rot, centro, camaraScale * escala, SpriteEffects.None, 1);
            }
            
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

        public void SetSkin(string newSkin)
        {
            this.textura = Game1.INSTANCE.Content.Load<Texture2D>(newSkin);
        }
    }
}
