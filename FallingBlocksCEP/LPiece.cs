using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FallingBlocksCEP
{
    //
    //      Y                             //      Y                            //       Y                               //      Y                  
    //      ^                             //      ^                            //       ^                               //      ^                 
    //      |i    h     g     f           //      |     j                      //       |           b     a             //      |
    //  0   +-----+-----+-----+          //  0  a +-----+-----+ i              //   0               +-----+             //  0 f +-----+ e
    //      | 1   | 2   | 3   |           //      |     |     |                //                   |     |             //      |     | 
    //      |     |     |     |           //      |     |     |                //       e     d    c|     |             //      |     |
    //  1 j +-----+-----+-----+           //  1 b +-----+-----+  h             //   1   +-----+-----+-----+ j           //  1 g +-----+ d
    //      |     |c    d     e           //          c |     |                //       |     |     |     |             //      |     |     
    //      | 0   |                       //            |     |                //       |     |     |     |             //      |     | c    
    //  2 a +-----+b               --->x  //  2       d +-----+  g             //   2   +-----+-----+-----+   --->x     //  2 h +-----+-----+ b
    //                                    //            |     |                //       f     g     h     i             //      |     |     |     
    //      0     1     2     3           //            |     |                //       0     1     2     3             //      |     |     |           
    //                                    //  3       e +-----+  f             //                                       //  3 i +-----+-----+ a
    //                                    //                                                                            //            j
    //                                    //      0     1     2                                                         //      0     1     2
    //
    //      0°                                        90°                         //     180°                          //             270°  
    class LPiece : FallingBlocksPiece
    {
        public LPiece(int size, Color color)
            : base(size, "L", color,
            #region points
 new Point[][] {
                                        //           a                 b                      c                      d                              e                       f
                          new Point[] { new Point(0, 2 * size), new Point(size, 2 * size), new Point(size, size), new Point(2 * size, size), new Point(3 * size, size), new Point(3 * size, 0),
                                        //          g                           h                i                 j                a
                                        new Point(2 * size, 0), new Point(size, 0), new Point(0, 0), new Point(0, size), new Point(0, 2 * size) },

                                        //     a                      b                       c                       d                       e                             f
                          new Point[] { new Point(0, 0), new Point(0, size), new Point(size, size), new Point( size, 2 * size), new Point(1 * size, 3 * size), new Point(2 *size, 3 * size),
                                         //           g                     h                         i                           j                     a
                                        new Point(2 * size, 2 * size), new Point(2 * size, size), new Point(2 * size, 0), new Point(size, 0), new Point(0, 0) },

                                        //     a                            b                          c                          d                 e                       f
                          new Point[] { new Point(3 * size, 0), new Point(2 * size, 0), new Point(2 * size, size), new Point(size, size), new Point(0, size), new Point(0, 2 * size),
                                         //           g                         h                     i                                    j                     a
                                        new Point(size, 2 * size), new Point(2 * size, 2 * size), new Point(3 * size, 2 * size), new Point(3 * size, size), new Point(3 * size, 0) },

                                        //     a                        b                                   c                      d                             e              f
                          new Point[] { new Point(2 * size, 3 * size), new Point(2 * size, 2 * size), new Point(size, 2 * size), new Point(size, size), new Point(size, 0), new Point(0, 0),
                                         //           g                          h                         i                   j                     a
                                        new Point(0, size), new Point(0,  2 * size), new Point(0, 3 * size), new Point(size, 3 * size), new Point(2 * size, 3 * size) }
                },
            #endregion
            #region rectangles
 new Rectangle[][] { 
                                     //                jcba                                                       ihjc
                   new Rectangle[] { new Rectangle(new Point(0, size), new Size(size, size)), new Rectangle(new Point(0, 0), new Size(size, size)),
                                     //                hgcd                                                       gfde
                                     new Rectangle(new Point(size, 0), new Size(size, size)), new Rectangle(new Point(2 * size, 0), new Size(size, size)) },

                                      //                ajbc                                                       jich
                    new Rectangle[] { new Rectangle(new Point(0, 0), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)),
                                      //                chdg                                                       dgef          
                                      new Rectangle(new Point(size, size), new Size(size, size)), new Rectangle(new Point(size, 2 * size), new Size(size, size)) },

                                      //                bacj                                                       cjhi
                    new Rectangle[] { new Rectangle(new Point(2 *size, 0), new Size(size, size)), new Rectangle(new Point(2 * size, size), new Size(size, size)),
                                      //                dcgh                                                       edfg
                                      new Rectangle(new Point(size, size), new Size(size, size)), new Rectangle(new Point(0, size), new Size(size, size)) },

                                      //                cbja                                                       hcij
                    new Rectangle[] { new Rectangle(new Point(size, 2 * size), new Size(size, size)), new Rectangle(new Point(0, 2 * size), new Size(size, size)),
                                      //                gdhc                                                       fegd
                                      new Rectangle(new Point(0, size), new Size(size, size)), new Rectangle(new Point(0, 0), new Size(size, size)) }
               },
        #endregion
            #region occupied
 new bool[][][] {
                new bool[][] {
                    new bool[] { true, true, true },
                    new bool[] { true, false, false }
                },
                new bool[][] {
                    new bool[] { true, true },
                    new bool[] { false, true },
                    new bool[] { false, true }
                },
                 new bool[][] {
                    new bool[] { false, false, true },
                    new bool[] { true, true, true }
                },
                new bool[][] {
                    new bool[] { true, false },
                    new bool[] { true, false },
                    new bool[] { true, true }
                }
            },
        #endregion
            new bool[] { true, true, true, true },
            new int[] { 2 * size, 3 * size, 2 * size, 3 * size },
            FallingBlocksGame.XOffset, FallingBlocksGame.YOffset)
        {
        }
    }
}