using ProjectMorpheus.Units;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus
{
    internal class ActionMenu
    {
        private UnitAction[] actions;
        private Vector2f location;
        private int selected;
        private float rectWidth = 100; //TODO: experiment for right values
        private float textHeight = 17;
        private float rectHeight;

        public ActionMenu(UnitAction[] actions, int selected, Vector2f location) {
            this.actions = actions;
            this.location = location;  //where to draw the menu in window coords
            this.selected = selected; //currently zero-indexed
            rectHeight = 10 + textHeight * actions.Length;
        }

        public void SetSelected(int selected) {
            if ((selected > actions.Length) || (selected < 0)) throw new ArgumentException("Menu selection out of bounds.");
            this.selected = selected;
        }

        public void Update() {
            if (InputManager.KeyAvailable()) {
                KeyboardCommand kc = InputManager.GetKeyCommand();
                /* switch (kc.Key)
                 {
                     case Keyboard.Key.A:
                        // debugLeft = kc.Pressed;
                         break;

                     case Keyboard.Key.D:
                         //debugRight = kc.Pressed;
                         break;

                     case Keyboard.Key.W:
                         //debugUp = kc.Pressed;
                         break;

                     case Keyboard.Key.S:
                         //debugDown = kc.Pressed;
                         break;
                 }*/
                //^ for keyboard support later
            }
            Vector2f mouseLocation = new Vector2f(InputManager.GetMouseLocation().X, InputManager.GetMouseLocation().Y);
            float mX = mouseLocation.X, menuX = location.X, mY = mouseLocation.Y, menuY = location.Y;
            if ((mX < (menuX + rectWidth)) && (mX > menuX) && (mY < (menuY + rectHeight)) && (mY > menuY)) {
                selected = (int)(((mY-menuY) - 5) / textHeight);
                if (selected > (actions.Length - 1)) selected = actions.Length - 1;
            }
        }

        public void Draw(RenderWindow window) {
            RectangleShape menuShape = new RectangleShape(new Vector2f(rectWidth, rectHeight)); //TODO: make fancier
            CircleShape pointer = new CircleShape((int)textHeight/3, 3);

            menuShape.OutlineThickness = 3.0f;
            menuShape.FillColor = new Color(110, 110, 110); //TODO: don't hardcode? can change color based on map or something
            menuShape.OutlineColor = new Color(255, 0, 0);
            menuShape.Position = location;

            //pointer.Origin = new Vector2f(5, 5); //half of radius above
            pointer.Rotation = -30.0f;
            pointer.OutlineThickness = 1.0f;
            pointer.OutlineColor = new Color(0, 0, 0);
            pointer.Position = menuShape.Position + new Vector2f(5, 3 + (textHeight / 2.0f) + textHeight * selected);
            pointer.FillColor = new Color(255, 0, 0);
            window.Draw(menuShape);
            window.Draw(pointer);
            Font actionStringFont = ContentManager.GetFont("testfont");
            //actionStringFont.
            for (int i = 0; i < actions.Length; ++i) {
                Text actionString = new Text(actions[i].ToString(), actionStringFont); //TODO: change to smaller context menu font
                actionString.Color = new Color(255, 255, 255);
                actionString.Scale = new Vector2f(0.5f,0.5f);
                actionString.Position = menuShape.Position + new Vector2f(25, 5 + textHeight * i);
                window.Draw(actionString);
            }
        }
    }
}
