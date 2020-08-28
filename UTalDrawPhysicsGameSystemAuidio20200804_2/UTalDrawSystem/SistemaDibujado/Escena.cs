using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.SistemaDibujado
{
    public class Escena
    {
        public List<Dibujable> dibujables { get; private set; } = new List<Dibujable>();
        public List<Texteable> texteables { get; private set; } = new List<Texteable>();
        public static Escena INSTANCIA;

        public Escena()
        {
            UTGameObjectsManager.Init();
            INSTANCIA = this;
        }
        public void agregarTex(Texteable tex)
        {
            texteables.Add(tex);
        }
        public void removerTex(Texteable tex)
        {
            texteables.Remove(tex);
        }
        public void agregarDib(Dibujable dib)
        {
            dibujables.Add(dib);
        }
        public void removerDib(Dibujable dib)
        {
            dibujables.Remove(dib);
        }
        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
