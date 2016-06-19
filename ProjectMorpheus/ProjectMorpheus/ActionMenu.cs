using ProjectMorpheus.Units;
using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus
{
    class ActionMenu
    {
        private UnitAction[] actions;
        private Vector2f location;
        private int selected;
        public ActionMenu(UnitAction[] actions, int selected, Vector2f location)
        {
            this.actions = actions;
            this.location = location;  //where to draw the menu in window coords
            this.selected = selected; //currently zero-indexed
        }
        public void SetSelected(int selected)
        {
            if ((selected > actions.Length) || (selected < 0)) throw new ArgumentException("Menu selection out of bounds.");
            this.selected = selected;
        }
        public void Update()
        {
            //TODO: peek at keys first. If it's a dire Esc or something, break update
            
        }
        public void Draw(RenderWindow window)
        {
            float rectWidth = 150; //TODO: experiment for right values
            float textHeight = 35;
            float rectHeight = 10 + textHeight * actions.Length;
            RectangleShape menuShape = new RectangleShape(new Vector2f(rectWidth,rectHeight)); //TODO: make fancier
            CircleShape pointer = new CircleShape(10, 3);

            menuShape.OutlineThickness = 3.0f;
            menuShape.FillColor = new Color(110, 110, 110); //TODO: don't hardcode? can change color based on map or something
            menuShape.OutlineColor = new Color(255, 0, 0);
            menuShape.Position = location;

            //pointer.Origin = new Vector2f(5, 5); //half of radius above
            pointer.Rotation = -30.0f;
            pointer.Position = menuShape.Position + new Vector2f(0, 5 + (textHeight/2.0f) + textHeight * selected);
            pointer.FillColor = new Color(255, 0, 0);
            window.Draw(menuShape);
            window.Draw(pointer);
            Font actionStringFont = ContentManager.GetFont("testfont");
            //actionStringFont.
            for (int i = 0; i < actions.Length; ++i)
            {                
                Text actionString = new Text(actions[i].ToString(),actionStringFont); //TODO: change to context menu font
                actionString.Color = new Color(255,255,255);
                actionString.Position = menuShape.Position + new Vector2f(30, 5+textHeight * i);
                window.Draw(actionString);
            }
        }
    }
}
