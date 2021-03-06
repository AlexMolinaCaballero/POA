﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaFisico;

namespace UTalDrawSystem.SistemaGameObject
{    
    public class UTGameObject
    {
        public ObjetoFisico objetoFisico;
        public Dibujable dibujable;
        public float rot { get { return dibujable.rot; } set { dibujable.rot = value; } }
        public Vector2 pos { get { return dibujable.pos; } set { dibujable.pos = value; } }
        public enum FF_form { Circulo, Rectangulo,DosCirculos};
        public UTGameObject(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false)
        {
            dibujable = new Dibujable(imagen, pos, escala);
            objetoFisico = new ObjetoFisico(dibujable);
            if (forma == FF_form.Circulo)
            {
                objetoFisico.agregarFFCirculo(dibujable.ancho/2f, new Vector2(0, 0));
            }
            else if(forma == FF_form.Rectangulo)
            {
                objetoFisico.agregarFFRectangulo(dibujable.ancho, dibujable.alto, new Vector2(0, 0));
            }
            else if (forma == FF_form.DosCirculos)
            {
                objetoFisico.agregarFFCirculo(dibujable.ancho / 2f, new Vector2(0,dibujable.alto/2-dibujable.ancho/2));
                objetoFisico.agregarFFCirculo(dibujable.ancho / 2f, new Vector2(0,-dibujable.alto/2 + dibujable.ancho/2));
            }
            objetoFisico.isStatic = isStatic;
            objetoFisico.OnCollision = OnCollision;
            objetoFisico.GetObject = GetObject;


            UTGameObjectsManager.suscribirObjeto(this);
        }
        private void OnCollision(Object other)
        {
            UTGameObject otherUTG = other as UTGameObject;
            OnCollision(otherUTG);
        }
        public Object GetObject()
        {
            return this as Object;
        }

        public virtual void OnCollision(UTGameObject other)
        {

        }
        public void Destroy()
        {
            UTGameObjectsManager.DestruirObjeto(this);
        }
        public void OnDestroy()
        {
            dibujable.Destruir();
            objetoFisico.Destruir();
        }
        public virtual void Update(GameTime gameTime)
        {

        }

    }
}
