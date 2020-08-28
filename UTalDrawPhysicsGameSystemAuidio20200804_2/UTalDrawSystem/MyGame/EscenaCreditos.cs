using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    public class EscenaCreditos : Escena
    {
        Boton_MainMenu mainMenu;
        Texteable creditosTitulo;
        Texteable creditosCuerpoL1;
        Texteable creditosCuerpoL2;
        Texteable creditosCuerpoL3;
        Texteable creditosCuerpoL4;
        Texteable creditosCuerpoL5;
        Texteable creditosCuerpoL6;
        Texteable creditosCuerpoL7;

        public EscenaCreditos()
        {
            mainMenu = new Boton_MainMenu("Boton_MainMenu", new Vector2(150, 800), true);
            creditosTitulo = new Texteable("FuenteA", new Vector2(600, 100), 2, "creditos");
            creditosCuerpoL1 = new Texteable("FuenteA", new Vector2(600, 200), 1, "grupo 5 durante el semestre");
            creditosCuerpoL2 = new Texteable("FuenteA", new Vector2(600, 300), 1, "MOTOR");
            creditosCuerpoL3 = new Texteable("FuenteA", new Vector2(600, 350), 1, "creador del motor.................sven bond brand\neditor del motor.............................alex molina");
            creditosCuerpoL4 = new Texteable("FuenteA", new Vector2(600, 450), 1, "SWALOW COINS");
            creditosCuerpoL5 = new Texteable("FuenteA", new Vector2(600, 500), 1, "artista...............................alex molina\nprogramador.....................alex molina");
            creditosCuerpoL6 = new Texteable("FuenteA", new Vector2(600, 600), 1, "AGRADECIMIENTOS ESPECIALES");
            creditosCuerpoL7 = new Texteable("FuenteA", new Vector2(600, 650), 1, "consultor...............................francisco riffo\n");
        }
        public override void Update(GameTime gameTime)
        {
            mainMenu.Update(gameTime, false);

        }
    }
}
