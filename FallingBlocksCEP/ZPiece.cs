using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FallingBlocksCEP
{
    //
    //    Y                              //      Y                     
    //    ^                              //      ^                     
    //    | a   b     c                  //      |     j      a        
    //  0 +-----+-----+                  //  0   |     +-----+         
    //    |  0  | 1   |                  //      |     |  0  |         
    //    |j    |     |d                 //    h |    i|     |         
    //  1 +-----+-----+-----+e           //  1   +-----+-----+ b       
    //         i| 2   | 3   |            //      |  2  |  1  |         
    //          |     |     |            //      |     |     |         
    //  2      h+-----+-----+f  --->x    //  2 g +-----+-----+ c       
    //                g                  //      |  3  | d             
    //    0     1     2     3            //      |     |               
    //                                   //  3 f +-----+ e             
    //                                   //                            
    //                                   //      0     1     2         
    //                                                                                                                                                 
    //      0° and 180°                      90° and 270°                  
    class ZPiece : FallingBlocksPiece
    {
        public ZPiece(int size, Color color)
            : base(size, "Z", color,
            #region points
                    new Point[][] {
                                        //           a                 b                      c                      d                              e                       f
                          new Point[] { new Point(0, 0), new Point(size, 0), new Point(2 * size, 0), new Point(2 * size, size), new Point(3 * size, size), new Point(3 * size, 2 * size),
                                        //          g                             h                    i                    j                a
                                        new Point(2 * size, 2 * size), new Point(size, 2* size), new Point(size, size), new Point(0, size), new Point(0, 0) },

                                        //     a                      b                          c                                d                       e                             f
                          new Point[] { new Point(2 * size, 0), new Point(2 * size, size), new Point(2 * size, 2 * size), new Point(size, 2 * size), new Point(1 * size, 3 * size), new Point(0, 3 * size),
                                         //           g                            h                     i                 j                     a
                                        new Point(0, 2 * size), new Point(0, 1 * size), new Point(size, size), new Point(size, 0), new Point(2 * size, 0) },
                },
            #endregion
            #region rectangles
            new Rectangle[][] { 
                                     //                abji                                                       bcid
                   new Rectangle[] { new Rectangle(new Point(0, 0), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)),
                                     //                idhg                                                       degf
                                     new Rectangle(new Point(size, size), new Size(size, size)), new Rectangle(new Point(2 * size, size), new Size(size, size)) },

                                      //                jaib                                                       ibdc
                    new Rectangle[] { new Rectangle(new Point(size, 0), new Size(size, size)), new Rectangle(new Point(size, size), new Size(size, size)),
                                      //                higd                                                       gdfe          
                                      new Rectangle(new Point(0, size), new Size(size, size)), new Rectangle(new Point(0, 2 *size), new Size(size, size)) },
                     
               },
        #endregion
            #region occupied
            new bool[][][] {
                new bool[][] {
                    new bool[] { true, true, false },
                    new bool[] { false, true, true }
                },
                new bool[][] {
                    new bool[] { false, true },
                    new bool[] { true, true },
                    new bool[] { true, false }
                }
            },
        #endregion
             new bool[] { true, true, true, true },
             new int[] { 2 * size, 3 * size, 2 * size, 3 * size},
            FallingBlocksGame.XOffset, FallingBlocksGame.YOffset)
        {
        }
    }
}
