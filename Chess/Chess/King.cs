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
    class King:Piece
    {
        public List<Tile> ReachTiles  // allowed destinations for pieces when checked
        { get; set; }
        public List<Tile> SafeTiles  // safe tile for the king when checked
        { get; set; }
        public List<Tile> ShadowTiles // Tile behind the king when checked 
        { get; set; }
        public bool[] CheckedDirections  // number of checks on the king
        { get; set; }
        public King():base()
        {
            ReachTiles=new List<Tile>();
            SafeTiles = new List<Tile>();
            ShadowTiles = new List<Tile>();
            CheckedDirections = new bool[8];
            for (int i = 0; i < 8; i++)
                CheckedDirections[i] = false;
        }
        public King(bool IsWhite, Tile Position):base(IsWhite,Position)
        {
            ReachTiles = new List<Tile>();
            SafeTiles = new List<Tile>();
            ShadowTiles = new List<Tile>();
            CheckedDirections = new bool[8];
            for (int i = 0; i < 8; i++)
                CheckedDirections[i] = false;
        }
        public override bool move(ref Tile startingTile, ref Tile destinationTile, ChessBoard chess)
        {
            if (destinationTile.PieceInside != null)
            {
                if (destinationTile.PieceInside.IsWhite == IsWhite)
                    return false;             
            }
            if ((destinationTile.UnderBlackAttack && IsWhite) || (destinationTile.UnderWhiteAttack && !IsWhite)||(ShadowTiles.Contains(destinationTile)))
                return false;
      if (Math.Abs(Position.RowInBoard - destinationTile.RowInBoard) == 1&&Math.Abs(Position.ColumnInBoard-destinationTile.ColumnInBoard)==0|| Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard) == 1&&Math.Abs(Position.RowInBoard-destinationTile.RowInBoard)==0||Math.Abs(Position.RowInBoard-destinationTile.RowInBoard)==1&&Math.Abs(Position.ColumnInBoard-destinationTile.ColumnInBoard)==1 )
            {
                changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                return true;
            }
            return false;
   
        }
        public override void attackTile( ref ChessBoard chess)
        {
            if (IsWhite)
            {
                try
                {
                    chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].UnderWhiteAttack = true;
                }
                catch (IndexOutOfRangeException)
                { }
                    
                try
                {
                    chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                
                
            }
            else
            {

                try
                {
                    chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].UnderBlackAttack = true;
                }
                catch (IndexOutOfRangeException)
                { }

                try
                {
                    chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                
                
               
            }
        }
        public bool checkPath(ref ChessBoard chess)  // assigns shadow , safe and reach tiles when checked
        {
            if (IsWhite && Position.UnderBlackAttack)
            {
                //pawn reach tiles
                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].PieceInside != null)
                    {

                        if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].PieceInside is Pawn && !chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }



                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].PieceInside != null)
                    {


                        if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].PieceInside is Pawn && !chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }

                //knight reach tiles
                try
                {
                    if (chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1].PieceInside is Knight && !chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1].PieceInside is Knight && !chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2].PieceInside is Knight && !chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 2].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 2].PieceInside is Knight && !chess.Tiles[Position.RowInBoard -1, Position.ColumnInBoard + 2].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 2]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 2].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 2].PieceInside is Knight && !chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard -2].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 2]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 2].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 2].PieceInside is Knight && !chess.Tiles[Position.RowInBoard -1, Position.ColumnInBoard -2].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 2]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1].PieceInside is Knight && !chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard -1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }


                try
                {
                    if (chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1].PieceInside is Knight && !chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }
                //end knight
                int index = 0;
                bool fill = false;
                int k = 0;
                for (int i = Position.RowInBoard + 1; i < 8; i++)
                {
                    Piece p = chess.Tiles[i, Position.ColumnInBoard].PieceInside;
                    if (p != null)
                    {
                        if ((p is Rook && !p.IsWhite) || (p is Queen && !p.IsWhite))
                        {
                            //adding a shadow tile
                            if(Position.RowInBoard-1>=0)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard-1,Position.ColumnInBoard]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            break;
                        }
                        else
                            break;
                    }
                }
                if (fill)
                {
                    for (int i = Position.RowInBoard + 1; i <= index; i++)
                    {
                        ReachTiles.Add(chess.Tiles[i, Position.ColumnInBoard]);
                    }
                }
                fill = false;
                k++;
                for (int i = Position.RowInBoard - 1; i >= 0; i--)
                {
                    Piece p = chess.Tiles[i, Position.ColumnInBoard].PieceInside;
                    if (p != null)
                    {
                        if ((p is Rook && !p.IsWhite) || (p is Queen && !p.IsWhite))
                        {
                            //adding a shadow tile
                            if (Position.RowInBoard + 1 < 8)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            break;
                        }
                        else
                            break;
                    }
                }
                if (fill)
                {
                    for (int i = Position.RowInBoard - 1; i >= index; i--)
                    {
                        ReachTiles.Add(chess.Tiles[i, Position.ColumnInBoard]);
                    }
                }
                fill = false;
                k++;
                for (int i = Position.ColumnInBoard + 1; i < 8; i++)
                {
                    Piece p = chess.Tiles[Position.RowInBoard, i].PieceInside;
                    if (p != null)
                    {
                        if ((p is Rook && !p.IsWhite) || (p is Queen && !p.IsWhite))
                        {
                            //adding a shadow tile
                            if (Position.ColumnInBoard - 1 >=0)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard-1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            break;
                        }
                        else
                            break;
                    }
                }
                if (fill)
                {
                    for (int i = Position.ColumnInBoard + 1; i <= index; i++)
                    {
                        ReachTiles.Add(chess.Tiles[Position.RowInBoard, i]);
                    }
                }
                fill = false;
                k++;
                for (int i = Position.ColumnInBoard - 1; i >= 0; i--)
                {
                    Piece p = chess.Tiles[Position.RowInBoard, i].PieceInside;
                    if (p != null)
                    {
                        if ((p is Rook && !p.IsWhite) || (p is Queen && !p.IsWhite))
                        {
                            //adding a shadow tile
                            if (Position.ColumnInBoard + 1 < 8)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            break;
                        }
                        else
                            break;
                    }
                }
                if (fill)
                {
                    for (int i = Position.ColumnInBoard + 1; i <= index; i++)
                    {
                        ReachTiles.Add(chess.Tiles[Position.RowInBoard, i]);
                    }
                }
                fill = false;
                int indexC = 0;
                k++;
                int c = Position.ColumnInBoard + 1;
                for (int i = Position.RowInBoard + 1; i < 8 && c < 8; i++)
                {
                    Piece p = chess.Tiles[i, c].PieceInside;
                    if (p != null)
                    {
                        if ((p is Bishop && !p.IsWhite) || (p is Queen && !p.IsWhite))
                        {
                            //adding a shadow tile
                            if (Position.ColumnInBoard - 1 >= 0&&Position.RowInBoard-1>=0)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard-1, Position.ColumnInBoard - 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            indexC = c;
                            break;
                        }
                        else
                            break;

                    }
                    c++;
                }
                if (fill)
                {
                    c = Position.ColumnInBoard + 1;
                    for (int i = Position.RowInBoard + 1; i <= index && c <= indexC; i++)
                    {
                        ReachTiles.Add(chess.Tiles[i, c]);
                        c++;
                    }

                }

                fill = false;
                indexC = 0;
                k++;
                c = Position.ColumnInBoard - 1;
                for (int i = Position.RowInBoard - 1; i >= 0 && c >= 0; i--)
                {
                    Piece p = chess.Tiles[i, c].PieceInside;
                    if (p != null)
                    {
                        if ((p is Bishop && !p.IsWhite) || (p is Queen && !p.IsWhite))
                        {
                            //adding a shadow tile
                            if (Position.ColumnInBoard + 1 < 8 && Position.RowInBoard + 1 < 8)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            indexC = c;
                            break;
                        }
                        else
                            break;

                    }
                    c--;
                }
                if (fill)
                {
                    c = Position.ColumnInBoard - 1;
                    for (int i = Position.RowInBoard - 1; i >= index && c >= indexC; i--)
                    {
                        ReachTiles.Add(chess.Tiles[i, c]);
                        c--;
                    }

                }


                fill = false;
                indexC = 0;
                k++;
                c = Position.ColumnInBoard + 1;
                for (int i = Position.RowInBoard - 1; i >= 0 && c < 8; i--)
                {
                    Piece p = chess.Tiles[i, c].PieceInside;
                    if (p != null)
                    {
                        if ((p is Bishop && !p.IsWhite) || (p is Queen && !p.IsWhite))
                        {
                            //adding a shadow tile
                            if (Position.ColumnInBoard - 1 >= 0 && Position.RowInBoard + 1 < 8)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            indexC = c;
                            break;
                        }
                        else
                            break;

                    }
                    c++;
                }
                if (fill)
                {
                    c = Position.ColumnInBoard + 1;
                    for (int i = Position.RowInBoard - 1; i >= index && c <= indexC; i--)
                    {
                        ReachTiles.Add(chess.Tiles[i, c]);
                        c++;
                    }

                }
                fill = false;
                indexC = 0;
                k++;
                c = Position.ColumnInBoard - 1;
                for (int i = Position.RowInBoard + 1; i < 8 && c >= 0; i++)
                {
                    Piece p = chess.Tiles[i, c].PieceInside;
                    if (p != null)
                    {
                        if ((p is Bishop && !p.IsWhite) || (p is Queen && !p.IsWhite))
                        {
                            //adding a shadow tile
                            if (Position.ColumnInBoard + 1 < 8 && Position.RowInBoard - 1 >= 0)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            indexC = c;
                            break;
                        }
                        else
                            break;

                    }
                    c--;
                }
                if (fill)
                {
                    c = Position.ColumnInBoard - 1;
                    for (int i = Position.RowInBoard + 1; i <= index && c >= indexC; i++)
                    {
                        ReachTiles.Add(chess.Tiles[i, c]);
                        c--;
                    }

                }
                //safe tiles addition
                try
                {
                    if (chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard+1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1]);
                    }
                    else if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard+1]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard-1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1]);
                    }
                    else if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard-1]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]);
                    }
                    else if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]);
                    }
                    else if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard+1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1]);
                    }
                    else if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard+1]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard+1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1]);
                    }
                    else if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard+1]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard-1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1]);
                    }

                    else if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard-1]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {

                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard-1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1]);
                    }
                    else if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].UnderBlackAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard-1]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                return true;
            }
            else if (!IsWhite && Position.UnderWhiteAttack)
            {
                //pawn reach tiles
                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].PieceInside != null)
                    {


                        if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].PieceInside is Pawn && chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].PieceInside != null)
                    {

                        if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].PieceInside is Pawn && chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1]);
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }

                //knight reach tiles

                try
                {
                    if (chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1].PieceInside is Knight && chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1].PieceInside is Knight && chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2].PieceInside is Knight && chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 2].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 2].PieceInside is Knight && chess.Tiles[Position.RowInBoard -1, Position.ColumnInBoard + 2].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 2]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 2].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 2].PieceInside is Knight && chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard -2].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 2]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 2].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 2].PieceInside is Knight && chess.Tiles[Position.RowInBoard -1, Position.ColumnInBoard -2].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 2]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    if (chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1].PieceInside is Knight && chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }


                try
                {
                    if (chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1].PieceInside != null)
                    {
                        if (chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1].PieceInside is Knight && chess.Tiles[Position.RowInBoard -2, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                        {
                            ReachTiles.Add(chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1]);

                        }

                    }
                }
                catch (IndexOutOfRangeException) { }
                //end  knight
                int index = 0;
                bool fill = false;
                int k = 0;
                for (int i = Position.RowInBoard + 1; i < 8; i++)
                {
                    Piece p = chess.Tiles[i, Position.ColumnInBoard].PieceInside;
                    if (p != null)
                    {
                        if ((p is Rook && p.IsWhite) || (p is Queen && p.IsWhite))
                        {
                            //adding a shadow tile
                            if (Position.RowInBoard - 1 >= 0)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            break;
                        }
                        else
                            break;
                    }
                }
                if (fill)
                {
                    for (int i = Position.RowInBoard + 1; i <= index; i++)
                    {
                        ReachTiles.Add(chess.Tiles[i, Position.ColumnInBoard]);
                    }
                }
                fill = false;
                k++;
                for (int i = Position.RowInBoard - 1; i >= 0; i--)
                {
                    Piece p = chess.Tiles[i, Position.ColumnInBoard].PieceInside;
                    if (p != null)
                    {
                        if ((p is Rook && p.IsWhite) || (p is Queen && p.IsWhite))
                        {
                            if (Position.RowInBoard + 1 < 8)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            break;
                        }
                        else
                            break;
                    }
                }
                if (fill)
                {
                    for (int i = Position.RowInBoard - 1; i >= index; i--)
                    {
                        ReachTiles.Add(chess.Tiles[i, Position.ColumnInBoard]);
                    }
                }
                fill = false;
                k++;
                for (int i = Position.ColumnInBoard + 1; i < 8; i++)
                {
                    Piece p = chess.Tiles[Position.RowInBoard, i].PieceInside;
                    if (p != null)
                    {
                        if ((p is Rook && p.IsWhite) || (p is Queen && p.IsWhite))
                        {
                            if (Position.ColumnInBoard - 1 >= 0)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            break;
                        }
                        else
                            break;
                    }
                }
                if (fill)
                {
                    for (int i = Position.ColumnInBoard + 1; i <= index; i++)
                    {
                        ReachTiles.Add(chess.Tiles[Position.RowInBoard, i]);
                    }
                }
                fill = false;
                k++;
                for (int i = Position.ColumnInBoard - 1; i >= 0; i--)
                {
                    Piece p = chess.Tiles[Position.RowInBoard, i].PieceInside;
                    if (p != null)
                    {
                        if ((p is Rook && p.IsWhite) || (p is Queen && p.IsWhite))
                        {
                            if (Position.ColumnInBoard + 1 < 8)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            break;
                        }
                        else
                            break;
                    }
                }
                if (fill)
                {
                    for (int i = Position.ColumnInBoard + 1; i <= index; i++)
                    {
                        ReachTiles.Add(chess.Tiles[Position.RowInBoard, i]);
                    }
                }
                fill = false;
                int indexC = 0;
                k++;
                int c = Position.ColumnInBoard + 1;
                for (int i = Position.RowInBoard + 1; i < 8 && c < 8; i++)
                {
                    Piece p = chess.Tiles[i, c].PieceInside;
                    if (p != null)
                    {
                        if ((p is Bishop && p.IsWhite) || (p is Queen && p.IsWhite))
                        {
                            if (Position.ColumnInBoard - 1 >= 0 && Position.RowInBoard - 1 >= 0)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            indexC = c;
                            break;
                        }
                        else
                            break;

                    }
                    c++;
                }
                if (fill)
                {
                    c = Position.ColumnInBoard + 1;
                    for (int i = Position.RowInBoard + 1; i <= index && c <= indexC; i++)
                    {
                        ReachTiles.Add(chess.Tiles[i, c]);
                        c++;
                    }

                }

                fill = false;
                indexC = 0;
                k++;
                c = Position.ColumnInBoard - 1;
                for (int i = Position.RowInBoard - 1; i >= 0 && c >= 0; i--)
                {
                    Piece p = chess.Tiles[i, c].PieceInside;
                    if (p != null)
                    {
                        if ((p is Bishop && p.IsWhite) || (p is Queen && p.IsWhite))
                        {
                            if (Position.ColumnInBoard + 1 < 8 && Position.RowInBoard + 1 < 8)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            indexC = c;
                            break;
                        }
                        else
                            break;

                    }
                    c--;
                }
                if (fill)
                {
                    c = Position.ColumnInBoard - 1;
                    for (int i = Position.RowInBoard - 1; i >= index && c >= indexC; i--)
                    {
                        ReachTiles.Add(chess.Tiles[i, c]);
                        c--;
                    }

                }


                fill = false;
                indexC = 0;
                k++;
                c = Position.ColumnInBoard + 1;
                for (int i = Position.RowInBoard - 1; i >= 0 && c < 8; i--)
                {
                    Piece p = chess.Tiles[i, c].PieceInside;
                    if (p != null)
                    {
                        if ((p is Bishop && p.IsWhite) || (p is Queen && p.IsWhite))
                        {
                            if (Position.ColumnInBoard - 1 >= 0 && Position.RowInBoard + 1 < 8)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            indexC = c;
                            break;
                        }
                        else
                            break;

                    }
                    c++;
                }
                if (fill)
                {
                    c = Position.ColumnInBoard + 1;
                    for (int i = Position.RowInBoard - 1; i >= index && c <= indexC; i--)
                    {
                        ReachTiles.Add(chess.Tiles[i, c]);
                        c++;
                    }

                }
                fill = false;
                indexC = 0;
                k++;
                c = Position.ColumnInBoard - 1;
                for (int i = Position.RowInBoard + 1; i < 8 && c >= 0; i++)
                {
                    Piece p = chess.Tiles[i, c].PieceInside;
                    if (p != null)
                    {
                        if ((p is Bishop && p.IsWhite) || (p is Queen && p.IsWhite))
                        {
                            if (Position.ColumnInBoard + 1 < 8 && Position.RowInBoard - 1 >= 0)
                                ShadowTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1]);
                            fill = true;
                            CheckedDirections[k] = true;
                            index = i;
                            indexC = c;
                            break;
                        }
                        else
                            break;

                    }
                    c--;
                }
                if (fill)
                {
                    c = Position.ColumnInBoard - 1;
                    for (int i = Position.RowInBoard + 1; i <= index && c >= indexC; i++)
                    {
                        ReachTiles.Add(chess.Tiles[i, c]);
                        c--;
                    }
                    
                }
                //safe tiles addition
                try
                {

                    if (chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1]);
                    }
                    else if (chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard + 1]);
                    }

                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1]);
                    }
                    else if (chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard, Position.ColumnInBoard - 1]);
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {

                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard+1, Position.ColumnInBoard]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]);
                    }
                    else if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard]);
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]);
                    }
                    else if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard]);
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard+1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1]);
                    }
                    else if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard+1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1]);
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard+1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1]);
                    }
                    else if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard+1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1]);
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].PieceInside == null)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard-1]))

                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1]);
                    }
                    else if (chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                    {
                        if (!chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard-1]))
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1]);
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].PieceInside == null)
                        if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard-1]))
                        {
                            SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1]);
                        }
                        else if (chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].PieceInside.IsWhite)
                        {
                            if (!chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].UnderWhiteAttack && !ShadowTiles.Contains(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard-1]))
                                SafeTiles.Add(chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1]);
                        }
                }
                catch (IndexOutOfRangeException) { }
                return true;
            }

            return false;
            
        }
        public void clearKing()  // clears safe , shadow and reach tiles each turn
        {
            SafeTiles.Clear();
            ReachTiles.Clear();
            ShadowTiles.Clear();
            for (int i = 0; i < 8; i++)
                CheckedDirections[i] = false;
        }
        private bool defineColor (bool white , ref ChessBoard chess,ref Tile destinationTile, Piece p) // part of can move before king function
        {
            int sidePositionr = 0;
            int sidePositionc = 0;
            bool found = false;
            int sidePosition = 0;
            for (int i = Position.RowInBoard + 1; i < 8; i++)
            {
                if (chess.Tiles[i, Position.ColumnInBoard].PieceInside != null)
                {
                    if (chess.Tiles[i, Position.ColumnInBoard].PieceInside != p)
                        break;
                    if (chess.Tiles[i, Position.ColumnInBoard].PieceInside == p && white || chess.Tiles[i, Position.ColumnInBoard].PieceInside == p && !white)
                    {
                        sidePosition = i;
                        found = true;
                        break;
                    }
                }
            }
            if (found)
            {
                for (int k = sidePosition + 1; k < 8; k++)
                {
                    if (chess.Tiles[k, Position.ColumnInBoard].PieceInside != null)
                    {
                        if (!(chess.Tiles[k, Position.ColumnInBoard].PieceInside is Queen || chess.Tiles[k, Position.ColumnInBoard].PieceInside is Rook))
                            return true;
                        if (chess.Tiles[k, Position.ColumnInBoard].PieceInside.IsWhite!=white&& destinationTile.ColumnInBoard != Position.ColumnInBoard)
                        {
                            return false;
                        }
                    }
                }
            }
            found = false;
            sidePosition = 0;
            for (int i = Position.RowInBoard - 1; i >= 0; i--)
            {
                if (chess.Tiles[i, Position.ColumnInBoard].PieceInside != null)
                {
                    if (chess.Tiles[i, Position.ColumnInBoard].PieceInside != p)
                        break;
                    if (chess.Tiles[i, Position.ColumnInBoard].PieceInside == p && white || chess.Tiles[i, Position.ColumnInBoard].PieceInside == p && !white)
                    {
                        sidePosition = i;
                        found = true;
                        break;
                    }
                }
            }
            if (found)
            {
                for (int k = sidePosition - 1; k >= 0; k--)
                {
                    if (chess.Tiles[k, Position.ColumnInBoard].PieceInside != null)
                    {
                        if (!(chess.Tiles[k, Position.ColumnInBoard].PieceInside is Queen || chess.Tiles[k, Position.ColumnInBoard].PieceInside is Rook))
                            return true;
                        if (chess.Tiles[k, Position.ColumnInBoard].PieceInside.IsWhite != white && destinationTile.ColumnInBoard != Position.ColumnInBoard)
                        {
                            return false;
                        }
                    }
                }
            }
            found = false;
            sidePosition = 0;
            for (int i = Position.ColumnInBoard + 1; i < 8; i++)
            {
                if (chess.Tiles[Position.RowInBoard, i].PieceInside != null)
                {
                    if (chess.Tiles[ Position.RowInBoard,i].PieceInside != p)
                        break;
                    if (chess.Tiles[Position.RowInBoard, i].PieceInside == p && white || chess.Tiles[i, Position.ColumnInBoard].PieceInside == p && !white)
                    {
                        sidePosition = i;
                        found = true;
                        break;
                    }
                }
            }
            if (found)
            {
                for (int k = sidePosition + 1; k < 8; k++)
                {
                    if (chess.Tiles[Position.RowInBoard, k].PieceInside != null)
                    {
                        if (!(chess.Tiles[Position.RowInBoard, k].PieceInside is Queen || chess.Tiles[Position.RowInBoard,k].PieceInside is Rook))
                            return true;
                        if (chess.Tiles[Position.RowInBoard, k].PieceInside.IsWhite != white && destinationTile.RowInBoard != Position.RowInBoard)
                        {
                            return false;
                        }
                    }
                }
            }
            found = false;
            sidePosition = 0;
            for (int i = Position.ColumnInBoard - 1; i >= 0; i--)
            {
                if (chess.Tiles[Position.RowInBoard, i].PieceInside != null)
                {
                    if (chess.Tiles[ Position.RowInBoard,i].PieceInside != p)
                        break;
                    if (chess.Tiles[Position.RowInBoard, i].PieceInside == p && white || chess.Tiles[i, Position.ColumnInBoard].PieceInside == p && !white)
                    {
                        sidePosition = i;
                        found = true;
                        break;
                    }
                }
            }
            if (found)
            {
                for (int k = sidePosition - 1 ; k >= 0; k--)
                {
                    if (chess.Tiles[Position.RowInBoard, k].PieceInside != null)
                    {
                        if (!(chess.Tiles[Position.RowInBoard, k].PieceInside is Queen || chess.Tiles[Position.RowInBoard, k].PieceInside is Rook))
                            return true;
                        if (chess.Tiles[Position.RowInBoard, k].PieceInside.IsWhite != white && destinationTile.RowInBoard != Position.RowInBoard)
                        {
                            return false;
                        }
                    }
                }
            }
            found = false;
            sidePositionr = 0;
            sidePositionc = 0;
            int rdiff=0;
            int cdiff=0;
             int c = Position.ColumnInBoard+1;
            for (int i = Position.RowInBoard + 1; i < 8 && c < 8; i++)
            {
                if (chess.Tiles[i, c].PieceInside != null)
                {
                    if (chess.Tiles[i, c].PieceInside != p)
                        break;
                    if (chess.Tiles[i, c].PieceInside == p && white || chess.Tiles[i, c].PieceInside == p && !white)
                    {
                        sidePositionr = i;
                        sidePositionc = c;
                        found = true;
                        break;
                    }
                }
                c++;
            }
            c = sidePositionc+1;
            if (found)
            {
                for (int i = sidePositionr + 1; i < 8 && c < 8; i++)
                {
                    if (chess.Tiles[i, c].PieceInside != null)
                    {
                        rdiff=destinationTile.RowInBoard-Position.RowInBoard;
                        cdiff=destinationTile.ColumnInBoard-Position.ColumnInBoard;
                        if (!(chess.Tiles[i, c].PieceInside is Queen || chess.Tiles[i, c].PieceInside is Bishop))
                            return true;
                        if (chess.Tiles[i, c].PieceInside.IsWhite != white && !(rdiff==cdiff&&rdiff>0&&cdiff>0))
                        {
                            return false;
                        }
                    }
                    c++;
                }
            }
            found = false;
            sidePositionr = 0;
            sidePositionc = 0;
             rdiff = 0;
             cdiff = 0;
             c = Position.ColumnInBoard - 1;
            for (int i = Position.RowInBoard - 1; i >=0 && c >= 0; i--)
            {
                if (chess.Tiles[i, c].PieceInside != null)
                {
                    if (chess.Tiles[i, c].PieceInside != p)
                        break;
                    if (chess.Tiles[i, c].PieceInside == p && white || chess.Tiles[i, c].PieceInside == p && !white)
                    {
                        sidePositionr = i;
                        sidePositionc = c;
                        found = true;
                        break;
                    }
                }
                c--;
            }
            c = sidePositionc-1;
            if (found)
            {
                for (int i = sidePositionr - 1; i >=0 && c >= 0; i--)
                {
                    if (chess.Tiles[i, c].PieceInside != null)
                    {
                        rdiff = destinationTile.RowInBoard - Position.RowInBoard;
                        cdiff = destinationTile.ColumnInBoard - Position.ColumnInBoard;
                        if (!(chess.Tiles[i, c].PieceInside is Queen || chess.Tiles[i, c].PieceInside is Bishop))
                            return true;
                        if (chess.Tiles[i, c].PieceInside.IsWhite != white && !(rdiff == cdiff && rdiff < 0 && cdiff < 0))
                        {
                            return false;
                        }
                    }
                    c--;
                }
            }
            found = false;
            sidePositionr = 0;
            sidePositionc = 0;
             rdiff = 0;
             cdiff = 0;
             c = Position.ColumnInBoard + 1;
            for (int i = Position.RowInBoard - 1; i >= 0 && c < 8; i--)
            {
                if (chess.Tiles[i, c].PieceInside != null)
                {
                    if (chess.Tiles[i, c].PieceInside != p)
                        break;
                    if (chess.Tiles[i, c].PieceInside == p && white || chess.Tiles[i, c].PieceInside == p && !white)
                    {
                        sidePositionr = i;
                        sidePositionc = c;
                        found = true;
                        break;
                    }
                }
                c++;
            }
            c = sidePositionc+1;
            if (found)
            {
                for (int i = sidePositionr - 1; i >= 0 && c < 8; i--)
                {
                    if (chess.Tiles[i, c].PieceInside != null)
                    {
                        rdiff = destinationTile.RowInBoard - Position.RowInBoard;
                        cdiff = destinationTile.ColumnInBoard - Position.ColumnInBoard;
                        if (!(chess.Tiles[i, c].PieceInside is Queen || chess.Tiles[i, c].PieceInside is Bishop))
                            return true;
                        if (chess.Tiles[i, c].PieceInside.IsWhite != white && !(rdiff == -cdiff && rdiff < 0 && cdiff > 0))
                        {
                            return false;
                        }
                    }
                    c++;
                }
            }
            found = false;
            sidePositionr = 0;
            sidePositionc = 0;
            rdiff = 0;
            cdiff = 0;
            c = Position.ColumnInBoard - 1;
            for (int i = Position.RowInBoard + 1; i < 8 && c >= 0; i++)
            {
                if (chess.Tiles[i, c].PieceInside != null)
                {
                    if (chess.Tiles[i, c].PieceInside != p)
                        break;
                    if (chess.Tiles[i, c].PieceInside == p && white || chess.Tiles[i, c].PieceInside == p && !white)
                    {
                        sidePositionr = i;
                        sidePositionc = c;
                        found = true;
                        break;
                    }
                }
                c--;
            }
            c = sidePositionc-1;
            if (found)
            {
                for (int i = sidePositionr + 1; i < 8 && c >= 0; i++)
                {
                    if (chess.Tiles[i, c].PieceInside != null)
                    {
                        rdiff = destinationTile.RowInBoard - Position.RowInBoard;
                        cdiff = destinationTile.ColumnInBoard - Position.ColumnInBoard;
                        if (!(chess.Tiles[i, c].PieceInside is Queen || chess.Tiles[i, c].PieceInside is Bishop))
                            return true;
                        if (chess.Tiles[i, c].PieceInside.IsWhite != white && !(rdiff ==- cdiff && rdiff > 0 && cdiff < 0))
                        {
                            return false;
                        }
                    }
                    c--;
                }
            }
            return true;
        }
        //bool function of freeze
        public bool canMoveBeforeKing(ref ChessBoard chess,ref Tile destinationTile,Piece p)
        {
            if (IsWhite)
            {
                return defineColor(true, ref chess, ref destinationTile, p);
            }
            else
            {
                return defineColor(false, ref chess, ref destinationTile, p);
            }
        }
        /// <summary>
        /// winning condition (checkmate)
        /// </summary>
        public void checkmate(Player player1,Player player2,ref ChessBoard chess)
        {
            bool guard = true;
            int counter = 0;
            for (int i = 0; i < 8; i++)
            {
                if (CheckedDirections[i])
                {
                    counter++;
                }
            }
            if (SafeTiles.Count == 0 && counter > 1)
            {
                //load a form for the winner
                if (IsWhite)
                    player1.Checkmate = true;
                else
                    player2.Checkmate = true;
            }
            else
            {
                if (IsWhite)
                {
                    for (int i = 0; i < ReachTiles.Count; i++)
                    {
                        if (ReachTiles[i].UnderWhiteAttack)
                        {
                            guard = false;
                            break;
                        }
                        Tile t=chess.Tiles[ReachTiles[i].RowInBoard+1,ReachTiles[i].ColumnInBoard];
                        if (t.PieceInside != null)
                        {
                            if (t.PieceInside is Pawn && t.PieceInside.IsWhite&&ReachTiles[i].PieceInside==null)
                            {
                                guard = false;
                                break;
                            }
                        }
                        try
                        {
                            Tile tright = chess.Tiles[ReachTiles[i].RowInBoard + 1, ReachTiles[i].ColumnInBoard + 1];
                            if (tright.PieceInside != null)
                            {
                                if (tright.PieceInside is Pawn && tright.PieceInside.IsWhite && ReachTiles[i].PieceInside != null)
                                {
                                    guard = false;
                                    break;
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        { }
                        try
                        {
                            Tile tleft = chess.Tiles[ReachTiles[i].RowInBoard + 1, ReachTiles[i].ColumnInBoard - 1];
                            if (tleft.PieceInside != null)
                            {
                                if (tleft.PieceInside is Pawn && tleft.PieceInside.IsWhite && ReachTiles[i].PieceInside != null)
                                {
                                    guard = false;
                                    break;
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        { }
                    }
                }

                else
                {

                    for (int i = 0; i < ReachTiles.Count; i++)
                    {
                        if (ReachTiles[i].UnderBlackAttack)
                        {
                            guard = false;
                            break;
                        }
                        Tile t = chess.Tiles[ReachTiles[i].RowInBoard - 1, ReachTiles[i].ColumnInBoard];
                        if (t.PieceInside != null)
                        {
                            if (t.PieceInside is Pawn && !t.PieceInside.IsWhite&&ReachTiles[i].PieceInside == null)
                            {
                                guard = false;
                                break;
                            }
                        }
                        try
                        {
                            Tile tright = chess.Tiles[ReachTiles[i].RowInBoard - 1, ReachTiles[i].ColumnInBoard + 1];
                            if (tright.PieceInside != null)
                            {
                                if (tright.PieceInside is Pawn && !tright.PieceInside.IsWhite && ReachTiles[i].PieceInside != null)
                                {
                                    guard = false;
                                    break;
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        { }
                        try
                        {
                            Tile tleft = chess.Tiles[ReachTiles[i].RowInBoard - 1, ReachTiles[i].ColumnInBoard - 1];
                            if (tleft.PieceInside != null)
                            {
                                if (tleft.PieceInside is Pawn && !tleft.PieceInside.IsWhite && ReachTiles[i].PieceInside != null)
                                {
                                    guard = false;
                                    break;
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        { }
                    }
                }
                    if (SafeTiles.Count == 0 && counter == 1 && guard)
                    {
                        //load a form for the winner
                        if (IsWhite)
                            player1.Checkmate = true;
                        else
                            player2.Checkmate = true;
                    }
                }
            
        }
        public override void loadTexture(ContentManager c)
        {
            if (IsWhite)
                PieceTexture = c.Load<Texture2D>(@"white king");
            else
                PieceTexture = c.Load<Texture2D>(@"black king");
        }

    }
}
