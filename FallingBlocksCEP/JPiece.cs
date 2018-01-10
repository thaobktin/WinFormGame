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
    //      |                             //      |     j      a               //       |     g     h     i             //      |
    //  0 a +-----+ b                     //  0 i +-----+-----+                //   0  f+-----+-----+-----+             //  0 a     e +-----+ f
    //      |  0  |                       //      |     |     |                //       |     |     |     |             //            |     | 
    //      |     | c   d                 //      |     |     |                //       |     |     |     |             //            |     |
    //  1 j +-----+-----+-----+ e         //  1 h +-----+-----+ b              //   1   +-----+-----+-----+ j           //  1 b     d +-----+ g
    //      |  1  | 2   | 3   |           //      |     | c                    //       e     d    c|     |             //            |     |     
    //      |     |     |     |           //      |     |                      //                   |     |             //          c |     |     
    //  2 i +-----+-----+-----+ f  --->x  //  2 g +-----+                      //   2               +-----+   --->x     //  2 b +-----+-----+ h
    //            h     g                 //      |     | d                    //                   b     a             //      |     |     |     
    //      0     1     2     3           //      |     |                      //       0     1     2     3             //      |     |     |           
    //                                    //  3 f +-----+ e                    //                                       //  3 a +-----+-----+ i
    //                                    //                                                                            //            j
    //                                    //      0     1     2                                                         //      0     1     2
    //
    //      0°                                        90°                         //     180°                          //             270°  
    class JPiece : FallingBlocksPiece
    {
        public JPiece(int size, Color color)
            : base(size, "J", color,
            #region points
 new Point[][] {
                                        //           a                 b                      c                      d                              e                       f
                          new Point[] { new Point(0, 0), new Point(size, 0), new Point(size, size), new Point(2 * size, size), new Point(3 * size, size), new Point(3 * size, 2 * size),
                                        //          g                             h                    i                    j                a
                                        new Point(2 * size, 2 * size), new Point(size, 2* size), new Point(0, 2 * size), new Point(0, size), new Point(0, 0) },

                                        //     a                      b                          c                                d                       e                       f
                          new Point[] { new Point(2 * size, 0), new Point(2 * size, size), new Point(size, size), new Point(size, 2 * size), new Point(1 * size, 3 * size), new Point(0, 3 * size),
                                         //           g                 h                     i               j                     a
                                        new Point(0, 2 * size), new Point(0, size), new Point(0, 0), new Point(size, 0), new Point(2 * size, 0) },

                                        //     a                             b                          c                                  d                 e                       f
                          new Point[] { new Point(3 * size, 2 * size), new Point(2 * size, 2 * size), new Point(2 * size, size), new Point(size, size), new Point(0, size), new Point(0, 0),
                                         //           g                         h                     i                       j                     a
                                        new Point(size, 0), new Point(2 * size, 0), new Point(3 *size, 0), new Point(3 * size, size), new Point(3 * size, 2 * size) },

                                        //     a                      b                            c                        d                       e                           f
                          new Point[] { new Point(0, 3 * size), new Point(0, 2 * size), new Point(size, 2 * size), new Point(size, size), new Point(size, 0), new Point(2 * size, 0),
                                         //           g                            h                         i                              j                     a
                                        new Point(2 * size, size), new Point(2 * size,  2 * size), new Point(2 * size, 3 * size), new Point(size, 3 * size), new Point(0, 3 * size) }
                },
            #endregion
            #region rectangles
 new Rectangle[][] { 
                                     //                abjc                                                       jcih
                   new Rectangle[] { new Rectangle(new Point(0, 0), new Size(size, size)), new Rectangle(new Point(0, size), new Size(size, size)),
                                     //                cdhg                                                       degf
                                     new Rectangle(new Point(size, size), new Size(size, size)), new Rectangle(new Point(2 * size, size), new Size(size, size)) },

                                      //                jacb                                                       ijhc
                    new Rectangle[] { new Rectangle(new Point(size, 0), new Size(size, size)), new Rectangle(new Point(0, 0), new Size(size, size)),
                                      //                hcgd                                                       gdfe          
                                      new Rectangle(new Point(0, size), new Size(size, size)), new Rectangle(new Point(0, 2 *size), new Size(size, size)) },

                                      //                cjab                                                       hijc
                    new Rectangle[] { new Rectangle(new Point(2 *size, size), new Size(size, size)), new Rectangle(new Point(2 * size, 0), new Size(size, size)),
                                      //                ghcd                                                       fgde
                                      new Rectangle(new Point(size, 0), new Size(size, size)), new Rectangle(new Point(0, 0), new Size(size, size)) },

                                      //                bcja                                                       chji
                    new Rectangle[] { new Rectangle(new Point(0, 2 * size), new Size(size, size)), new Rectangle(new Point(size, 2 * size), new Size(size, size)),
                                      //                dghc                                                       efdg
                                      new Rectangle(new Point(size, size), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)) }
               },
        #endregion
            #region occupied
 new bool[][][] {
                new bool[][] {
                    new bool[] { true, false, false },
                    new bool[] { true, true, true }
                },
                new bool[][] {
                    new bool[] { true, true },
                    new bool[] { true, false },
                    new bool[] { true, false }
                },
                 new bool[][] {
                    new bool[] { true, true, true },
                    new bool[] { false, false, true }
                },
                new bool[][] {
                    new bool[] { false, true },
                    new bool[] { false, true },
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