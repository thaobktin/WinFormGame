using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FallingBlocksCEP
{
    //
    //      Y                                   
    //      ^                                   
    //      |     b     
    // -1 a +-----+-----+ c                       
    //      |  0  | 1   |                       
    //      |     |i    |                     
    //  0 h +-----+-----+ d
    //      | 2   | 3   |
    //      |     |     |
    //  1   +-----+-----+ e  --->x         
    //      g     f                             
    //
    //     -1     0     1
    //                                        
    //      0°, 90°, 180°, 270°
    class OPiece : FallingBlocksPiece
    {
        public OPiece(int size, Color color)
            : base(size, "O", color,
            #region points
            new Point[][] {
                                        //           a                 b                      c                         d                           e                       f
                          new Point[] { new Point(-size, -size), new Point(0, -size), new Point(size, -size), new Point(size, 0), new Point(size, size), 
                                        //           f                        g                       h              a   
                                        new Point(0, size), new Point(-size, size), new Point(-size, 0),  new Point(-size, -size) }
                },
            #endregion
            #region rectangles
            new Rectangle[][] { 
                                     //                abih                                                       bcdi
                   new Rectangle[] { new Rectangle(new Point(-size, -size), new Size(size, size)), new Rectangle(new Point(0, -size), new Size(size, size)),
                                     //                hifg                                                       idef
                                     new Rectangle(new Point(-size, 0), new Size(size, size)), new Rectangle(new Point(0, 0), new Size(size, size)) },
                     
               },
            #endregion
            #region occupied
            new bool[][][] {
                new bool[][] {
                    new bool[] { true, true },
                    new bool[] { true, true }
                }
            },
            #endregion
            new bool[] { true, true, true, true },
            new int[] { 2 * size, 2 * size, 2 * size, 2 * size },
            FallingBlocksGame.XOffset + FallingBlocksGame.ColumnWidth, FallingBlocksGame.YOffset + FallingBlocksGame.ColumnHeight)
        {
        }
    }
}
