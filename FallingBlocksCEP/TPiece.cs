using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FallingBlocksCEP
{
    //                                                                            //                                   //                         
    //      Y                              //      Y                              //          Y                        //            Y 
    //      ^                              //      ^                              //          ^                        //            ^
    //      |     b     c                  //      |     j     a                  //          |                        //            | 
    //  0 a +-----+-----+-----+ d          // -1   |     +-----+                  //                                   //      -1  a +-----+ j    
    //      |  0  | 1   | 2   |            //      |     |  0  |                  //      0       g +-----+ h          //            |  0  |            
    //      |     |     |     |            //      |    i|     |                  //                | 3   |            //            |     | i 
    //  1 j +-----+-----+-----+ e          //  0 h +-----+-----+ b                //              f |     | i          //       0  b +-----+-----+ h
    //           i| 3   |f                 //      |  3  |  1  |                  //      1 e +-----+-----+-----+ j    //            |  1  | 3   |
    //            |     |                  //      |     |     |                  //          |  2  | 1   | 0   |      //            |     |     |
    //  2         +-----+        --->x     //  1 g +-----+-----+ c                //          |     |     |     |      //       1  c +-----+-----+ g
    //            h     g                  //           f|  2  |                  //      2 d +-----+-----+-----+ a    //            |  2  |f   
    //      0     1     2     3            //            |     |                  //                c     b            //            |     |   
    //                                     //  2       e +-----+ d                //                                   //       2  d +-----+ e
    //                                     //                                     //          0     1     2     3      //                                    
    //                                     //      0     1     2                  //                                   //            0     1     2   
    //                                                                            //                                   //                                                                         
    //      0°                                        90°                         //     180°                          //             270°  
    class TPiece : FallingBlocksPiece
    {
        public TPiece(int size, Color color)
            : base(size, "T", color,
            #region points
            new Point[][] {
                                        //           a                 b                      c                      d                          e                       f
                          new Point[] { new Point(0, 0), new Point(size, 0), new Point(2 * size, 0), new Point(3 * size, 0), new Point(3 * size, size), new Point(2 * size, size),
                                        //          g                             h                    i                        j                a
                                        new Point(2 * size, 2 * size), new Point(size, 2* size), new Point(size, size), new Point(0, size), new Point(0, 0) },

                                        //       a                        b                          c                                d                       e                             f
                          new Point[] { new Point(2 * size, -size), new Point(2 * size, 0), new Point(2 * size, size), new Point(2 * size, 2 * size), new Point(size, 2 * size), new Point(size, size),
                                         //           g              h                     i                 j                     a
                                        new Point(0, size), new Point(0, 0), new Point(size, 0), new Point(size, -size), new Point(2 * size, -size) },

                                        //           a                         b                              c                        d                          e                       f
                          new Point[] { new Point(3 * size, 2 * size), new Point(2 * size, 2 * size), new Point(size, 2 * size), new Point(0, 2 * size), new Point(0, size), new Point(size, size),
                                        //          g                          h                    i                        j                a
                                        new Point(size, 0), new Point(2 * size, 0), new Point(2 * size, size), new Point(3 * size, size), new Point(3 * size, 2 * size) },

                                        //       a                        b                    c                  d                       e                        f
                          new Point[] { new Point(0, -size), new Point(0, 0), new Point(0, size), new Point(0, 2 * size), new Point(size, 2 * size), new Point(size, size),
                                         //         g                  h                         i                   j                     a
                                        new Point(2 * size, size), new Point(2 * size, 0), new Point(size, 0), new Point(size, -size), new Point(0, -size) }
                },
            #endregion
            #region rectangles
            new Rectangle[][] { 
                                     //                abji                                                       bcif
                   new Rectangle[] { new Rectangle(new Point(0, 0), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)),
                                     //                cdef                                                       ifhg
                                     new Rectangle(new Point(2 * size, 0), new Size(size, size)), new Rectangle(new Point(size, size), new Size(size, size)) },

                                      //                jaib                                                       ibcf
                    new Rectangle[] { new Rectangle(new Point(size, -size), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)),
                                      //                fcde                                                       higf          
                                      new Rectangle(new Point(size, size), new Size(size, size)), new Rectangle(new Point(0, 0), new Size(size, size)) },

                                     //                abji                                                       ficb
                   new Rectangle[] { new Rectangle(new Point(2 * size, size), new Size(size, size)), new Rectangle(new Point(size, size), new Size(size, size)),
                                     //                efdc                                                      ghif
                                     new Rectangle(new Point(0, size), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)) },

                                      //                ajib                                                       bifc
                    new Rectangle[] { new Rectangle(new Point(0, -size), new Size(size, size)), new Rectangle(new Point(0, 0), new Size(size, size)),
                                      //                cfed                                                       ihgf
                                      new Rectangle(new Point(0, size), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)) }
               },
            #endregion
            #region occupied
            new bool[][][] {
                new bool[][] {
                    new bool[] { true, true, true },
                    new bool[] { false, true, false }
                },
                new bool[][] {
                    new bool[] { false, true },
                    new bool[] { true, true },
                    new bool[] { false, true }
                },
                new bool[][] {
                    new bool[] { false, true, false },
                    new bool[] { true, true, true }
                },
                new bool[][] {
                    new bool[] { true, false },
                    new bool[] { true, true },
                    new bool[] { true, false }
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