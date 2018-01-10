using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FallingBlocksCEP
{
    //
    //       Y                               //      Y                  
    //       ^                               //      ^                 
    //       |     c     b     a             //      |
    //    0        +-----+-----+             //  0 a +-----+ j    
    //             |     |     |             //      |     |    
    //            d|     |     |             //      |     | i
    //    1 e+-----+-----+-----+j            //  1 b +-----+-----+ h
    //       |     |     | i                 //      |     |     |     
    //       |     |     |                   //      |     |     |     
    //    2 f+---- +-----+h      --->x       //  2 c +-----+-----+ g
    //             g                         //          d |     |     
    //      0     1     2     3              //            |     |           
    //                                       //  3       e +-----+ f
    //                                       //
    //                                       //      0     1     2
    //   
    //      0° and 180°                      90° and 270°                                    
    class SPiece : FallingBlocksPiece
    {
        public SPiece(int size, Color color)
            : base(size, "S", color,
            #region points
                    new Point[][] {
                                        //     a                      b                          c                           d                 e                       f
                          new Point[] { new Point(3 * size, 0), new Point(2 * size, 0), new Point(size, 0), new Point(size, size), new Point(0, size), new Point(0, 2 * size),
                                         //           g                            h                     i                        j                     a
                                        new Point(size, 2 * size), new Point(2 * size, 2 * size), new Point(2 *size, size), new Point(3 * size, size), new Point(3 * size, 0) },

                                        //     a                      b                          c                      d                       e                           f
                          new Point[] { new Point(0, 0), new Point(0, size), new Point(0, 2 * size), new Point(size, 2 * size), new Point(size, 3 * size), new Point(2 * size, 3 * size),
                                         //           g                            h                     i                    j                     a
                                        new Point(2 * size, 2 * size), new Point(2 * size,  size), new Point(size, size), new Point(size, 0), new Point(0, 0) }
                },
            #endregion
            #region rectangles
            new Rectangle[][] { 
                                      //                baij                                                       cbdi
                    new Rectangle[] { new Rectangle(new Point(2 *size, 0), new Size(size, size)), new Rectangle(new Point(size, 0), new Size(size, size)),
                                      //                digh                                                       edfg
                                      new Rectangle(new Point(size, size), new Size(size, size)), new Rectangle(new Point(0, size), new Size(size, size)) },

                                      //                ajbi                                                       bicd
                    new Rectangle[] { new Rectangle(new Point(0, 0), new Size(size, size)), new Rectangle(new Point(0, size), new Size(size, size)),
                                      //                ihdg                                                       dgef
                                      new Rectangle(new Point(size, size), new Size(size, size)), new Rectangle(new Point(size, 2 * size), new Size(size, size)) }
               },
        #endregion
            #region occupied
            new bool[][][] {
                new bool[][] {
                    new bool[] { false, true, true },
                    new bool[] { true, true, false }
                },
                new bool[][] {
                    new bool[] { true, false },
                    new bool[] { true, true },
                    new bool[] { false, true }
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
