using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Chess
{
    
    class Tile
        {
        public static int TileWidth
        { get { return 70;} }
        public static int TileHeight
        { get { return 70; } }
        public int RowInBoard
        {get;set;}
        public int ColumnInBoard
        { get; set; }
        private Rectangle border;
        private Vector2 center;
        public Piece PieceInside
        { get; set; }
        public bool UnderWhiteAttack
        { get; set; }
        public bool UnderBlackAttack
        { get; set; }
        public Tile()
        {
            UnderWhiteAttack = false;
            UnderBlackAttack = false;
        }
        public Tile(Rectangle border, int RowInBoard, int ColumnInBoard, Piece PieceInside)
        {
            this.border = border;
            center.X = this.border.Left + 13;
            center.Y = this.border.Top + 13;
            this.RowInBoard = RowInBoard;
            this.ColumnInBoard = ColumnInBoard;
            this.PieceInside = PieceInside;
            UnderWhiteAttack = false;
            UnderBlackAttack = false;
        }
        public Tile( ref Tile t )
        {
            border = t.border;
            center = t.center;
            RowInBoard = t.RowInBoard;
            ColumnInBoard = t.ColumnInBoard;
            PieceInside = t.PieceInside;
            UnderBlackAttack = t.UnderBlackAttack;
            UnderWhiteAttack = t.UnderWhiteAttack;
        }
        public Tile(Rectangle border)
        {
            this.border = border;
            center.X = border.Left + 13;
            center.Y = border.Top + 13;
        }
        public Rectangle  getBorder()
        {
            return border;
        }
        public void setBorder(Rectangle border)
        {
            this.border = border;
            center.X = border.Left + 13;
            center.Y = border.Top + 13;
        }
        public Vector2 getCenter()
        {
            return center;
        }
        public void colorSelection(ref SpriteBatch s, ref GraphicsDeviceManager g,Color tileColor)//color the tiles generally
        {
            Texture2D t = new Texture2D(g.GraphicsDevice, TileWidth-1, TileHeight-1);
            int numberOfPixels = (TileWidth-1) * (TileHeight-1);
            Color[] data = new Color[numberOfPixels];
            for (int i = 0; i < numberOfPixels; i++) 
                data[i] = tileColor;
            t.SetData(data);
            s.Draw(t, new Vector2(getBorder().Left+1.5315f,getBorder().Top+1.7f), Color.White);
        }
        }

    
}
