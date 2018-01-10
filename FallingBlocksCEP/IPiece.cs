using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FallingBlocksCEP
{
    //                                              
    //                                                 Y
    //                                                 ^
    //                                        -2 j +-----+ a
    //    Y                                        | 0   |
    //    | a   b     c     d     e                |     |
    //  0 +-----+-----+-----+-----+           -1 i +-----+ b  
    //    |  0  | 1   | 2   | 3   |                | 1   |
    //    |     |     |     |     |                |     |
    //  1 +-----+-----+-----+-----+            0 h +-----+ c
    //    j     i     h     g     f                | 2   |
    //                                             |     |
    //  x                                      1 g +-----+ d
    //                g                            | 3   |
    //    0     1     2     3     4                |     |
    //                                         2 f +-----+ e ---> x
    //                                             2     3   
    //                                             
    //                                                                                                                                                                
    //      0° and 180°                         90° and 270°                  
    class IPiece : FallingBlocksPiece             
    {
        public IPiece(int size, Color color)
            : base(size, "I", color,
            #region points
                    new Point[][] {
                                        //           a                 b                      c                      d                              e                       f
                                        //           a                 b                      c                      d                              e                       f
                          new Point[] { new Point(0, 0), new Point(size, 0), new Point(2 * size, 0), new Point(3 * size, 0), new Point(4 * size, 0), new Point(4 * size, size),
                                        //          g                             h                    i                    j                a
                                        new Point(3 * size, size), new Point(2* size, size), new Point(size, size), new Point(0, size), new Point(0, 0) },

                                        //     a                          b                            c                                d                       e                       f
                          new Point[] { new Point(3 * size, -2 * size), new Point(3 * size, -size), new Point(3 * size, 0), new Point(3 * size, size), new Point(3 * size, 2 * size), new Point(2 * size, 2 * size),
                                         //           g                        h                  i                            j                               a
                                        new Point(2 * size, size), new Point(2 * size, 0), new Point(2 * size, -size), new Point(2 * size, -2 * size), new Point(3 * size, -2 * size) },
                },
            #endregion
            #region rectangles
            new Rectangle[][] { 
                                     //                abji                                                       bcih
                   new Rectangle[] { new Rectangle(new Point(0, 0), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)),
                                     //                cdhg                                                       degf
                                     new Rectangle(new Point(2 * size, 0), new Size(size, size)), new Rectangle(new Point(3 * size, 0), new Size(size, size)) },

                                      //                jaib                                                       ibdc
                    new Rectangle[] { new Rectangle(new Point(2 * size, -2 * size), new Size(size, size)), new Rectangle(new Point(2 * size, -size), new Size(size, size)),
                                      //                higd                                                       gdfe          
                                      new Rectangle(new Point(2 * size, 0), new Size(size, size)), new Rectangle(new Point(2 * size, size), new Size(size, size)) },
               },
        #endregion
            #region occupied
            new bool[][][] {
                new bool[][] {
                    new bool[] { true, true, true, true },
                },
                new bool[][] {
                    new bool[] { true },
                    new bool[] { true },
                    new bool[] { true },
                    new bool[] { true }
                }
            },
        #endregion
             new bool[] { true, true, true, true },
             new int[] { size, 4 * size, size, 4 * size},
            FallingBlocksGame.XOffset, FallingBlocksGame.YOffset)
        {
        }
    }
}

