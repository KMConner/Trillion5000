using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Trillion5000
{
    class Program
    {
        private const int ImageWidth = 2500;

        private const int ImageHeight = 320;

        private const int LeftMargin = 20;
        private const int RightMargin = 20;


        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("ファイル名を指定してください。");
                return;
            }

            if (Path.GetExtension(args[0])?.ToLower() != ".png")
            {
                Console.WriteLine("ファイル名は PNG 形式で指定しください。");
                return;
            }

            Console.Write("上に表示する文字を入力してください:");
            string topText = Console.ReadLine();

            Console.Write("下に表示する文字を入力してください:");
            string bottomText = Console.ReadLine();


            var image = DrawImage(topText, bottomText);

            try
            {
                image.Save(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("画像を保存する際にエラーが発生しました。 -- " + e.Message);
            }
        }

        public static Bitmap DrawImage(string topText, string bottomText)
        {
            Bitmap top = DrawTop(topText);
            Bitmap bottom = DrawBottom(bottomText);

            var img = new Bitmap(Math.Max(top.Width, bottom.Width) + LeftMargin + RightMargin, ImageHeight);

            Graphics g = Graphics.FromImage(img);

            g.DrawImage(top, new Point(img.Width - RightMargin - top.Width, 0));
            g.DrawImage(bottom, new Point(img.Width - RightMargin - bottom.Width, 150));
            return img;
        }

        static Bitmap DrawTop(string text)
        {
            using (var img = new Bitmap(ImageWidth, 150))
            using (Graphics g = Graphics.FromImage(img))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;

                PrivateFontCollection coll = new PrivateFontCollection();
                coll.AddFontFile(@"notobk-subset.otf");
                FontFamily topFontFamily = coll.Families[0];

                #region 5000兆円 の描画

                // 黒色
                {
                    var graphiscPath = new GraphicsPath();
                    graphiscPath.AddString(text, topFontFamily, (int)FontStyle.Italic, 100, new PointF(4, 4), null);
                    var pen = new Pen(Brushes.Black, 22)
                    {
                        LineJoin = LineJoin.Round,
                    };
                    g.DrawPath(pen, graphiscPath);
                }


                // 銀色
                {
                    var graphiscPath = new GraphicsPath();
                    graphiscPath.AddString(text, topFontFamily, (int)FontStyle.Italic, 100, new PointF(4, 4), null);
                    LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(0, 20, ImageWidth, 135),
                        Color.AliceBlue, Color.AntiqueWhite, LinearGradientMode.Vertical);
                    ColorBlend blend = new ColorBlend
                    {
                        Colors = new[]
                        {
                            Color.FromArgb(0, 15, 36),
                            Color.FromArgb(0, 15, 36),
                            Color.FromArgb(255, 255, 255),
                            Color.FromArgb(55, 58, 59),
                            Color.FromArgb(55, 58, 59),
                            Color.FromArgb(200, 200, 200),
                            Color.FromArgb(55, 58, 59),
                            Color.FromArgb(25, 20, 31),
                            Color.FromArgb(240, 240, 240),
                            Color.FromArgb(166, 175, 194),
                            Color.FromArgb(50, 50, 50),
                            Color.FromArgb(50, 50, 50),
                        },

                        Positions = new[]
                        {
                            0,
                            0.13f,
                            0.23f,
                            0.3f,
                            0.35f,
                            0.5f,
                            0.65f,
                            0.75f,
                            0.81f,
                            0.84f,
                            0.92f,
                            1,
                        }
                    };
                    brush.InterpolationColors = blend;
                    var pen = new Pen(brush, 20)
                    {
                        LineJoin = LineJoin.Round,
                    };
                    g.DrawPath(pen, graphiscPath);
                }


                // 黒色
                {
                    var graphiscPath = new GraphicsPath();
                    graphiscPath.AddString(text, topFontFamily, (int)FontStyle.Italic, 100, new PointF(0, 0), null);
                    var pen = new Pen(Brushes.Black, 16)
                    {
                        LineJoin = LineJoin.Round,
                    };
                    g.DrawPath(pen, graphiscPath);
                }




                // 金色
                {
                    var graphiscPath = new GraphicsPath();
                    graphiscPath.AddString(text, topFontFamily, (int)FontStyle.Italic, 100, new PointF(0, 0), null);
                    LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(0, 20, ImageWidth, 135),
                        Color.AliceBlue, Color.AntiqueWhite, LinearGradientMode.Vertical);
                    ColorBlend blend = new ColorBlend
                    {
                        Colors = new[]
                        {
                            Color.FromArgb(253, 241, 0),
                            Color.FromArgb(253, 241, 0),
                            Color.FromArgb(245, 253, 187),
                            Color.FromArgb(255, 255, 255),
                            Color.FromArgb(253, 219, 9),
                            Color.FromArgb(127, 53, 0),
                            Color.FromArgb(243, 196, 11),
                            Color.FromArgb(243, 196, 11),
                        },

                        Positions = new[]
                        {
                            0,
                            0.12f,
                            0.25f,
                            0.35f,
                            0.56f,
                            0.66f,
                            0.73f,
                            1
                        }
                    };
                    brush.InterpolationColors = blend;
                    var pen = new Pen(brush, 10)
                    {
                        LineJoin = LineJoin.Round,
                    };
                    g.DrawPath(pen, graphiscPath);
                }



                // 黒
                {
                    var graphiscPath = new GraphicsPath();
                    graphiscPath.AddString(text, topFontFamily, (int)FontStyle.Italic, 100, new PointF(2, -3), null);
                    var pen = new Pen(Brushes.Black, 6)
                    {
                        LineJoin = LineJoin.Round,
                    };
                    g.DrawPath(pen, graphiscPath);
                }

                // 白
                {
                    var graphiscPath = new GraphicsPath();
                    graphiscPath.AddString(text, topFontFamily, (int)FontStyle.Italic, 100, new PointF(0, -3), null);
                    var pen = new Pen(Brushes.White, 6)
                    {
                        LineJoin = LineJoin.Round,
                    };
                    g.DrawPath(pen, graphiscPath);
                }

                // 赤
                {
                    var graphiscPath = new GraphicsPath();
                    graphiscPath.AddString(text, topFontFamily, (int)FontStyle.Italic, 100, new PointF(0, -3), null);
                    LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(0, 20, ImageWidth, 122),
                        Color.AliceBlue, Color.AntiqueWhite, LinearGradientMode.Vertical);
                    ColorBlend blend = new ColorBlend
                    {
                        Colors = new[]
                        {
                            Color.FromArgb(255, 100, 0),
                            Color.FromArgb(255, 100, 0),
                            Color.FromArgb(123, 0, 0),
                            Color.FromArgb(240, 0, 0),
                            Color.FromArgb(5, 0, 0),
                            Color.FromArgb(5, 0, 0),
                        },

                        Positions = new[]
                        {
                            0,
                            0.1f,
                            0.45f,
                            0.46f,
                            0.85f,
                            1
                        }
                    };
                    brush.InterpolationColors = blend;
                    var pen = new Pen(brush, 4)
                    {
                        LineJoin = LineJoin.Round,
                    };
                    g.DrawPath(pen, graphiscPath);
                }

                // 赤
                {
                    GraphicsPath gPath = new GraphicsPath();
                    gPath.AddString(text, topFontFamily, (int)FontStyle.Italic, 100, new PointF(0, -3), null);
                    LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(0, 20, ImageWidth, 122),
                        Color.AliceBlue, Color.AntiqueWhite, LinearGradientMode.Vertical);
                    ColorBlend blend = new ColorBlend
                    {
                        Colors = new[]
                        {
                            Color.FromArgb(230, 0, 0),
                            Color.FromArgb(230, 0, 0),
                            Color.FromArgb(123, 0, 0),
                            Color.FromArgb(240, 0, 0),
                            Color.FromArgb(5, 0, 0),
                            Color.FromArgb(5, 0, 0),
                        },

                        Positions = new[]
                        {
                            0,
                            0.1f,
                            0.45f,
                            0.46f,
                            0.85f,
                            1

                        }
                    };
                    brush.InterpolationColors = blend;
                    g.FillPath(brush, gPath);
                }

                #endregion

                var range = MeasureImage(img);
                return img.Clone(new Rectangle(range.left, 0, range.right - range.left, img.Height), img.PixelFormat);
            }
        }

        static Bitmap DrawBottom(string text)
        {
            var img = new Bitmap(ImageWidth, 150);
            Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = SmoothingMode.HighQuality;

            PrivateFontCollection coll2 = new PrivateFontCollection();
            coll2.AddFontFile(@"notoserifbk-subset.otf");

            FontFamily bottomFontFamily = coll2.Families[0];

            #region 欲しい! の描画

            // 黒色
            {
                var graphiscPath = new GraphicsPath();
                graphiscPath.AddString(text, bottomFontFamily, (int)FontStyle.Italic, 100, new PointF(5, 2), null);
                var pen = new Pen(Color.Black, 22)
                {
                    LineJoin = LineJoin.Round,
                };
                g.DrawPath(pen, graphiscPath);
            }

            // 銀色
            {
                var graphiscPath = new GraphicsPath();
                graphiscPath.AddString(text, bottomFontFamily, (int)FontStyle.Italic, 100, new PointF(5, 2), null);
                LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(0, 15, ImageWidth, 150),
                    Color.AliceBlue, Color.AntiqueWhite, LinearGradientMode.Vertical);
                ColorBlend blend = new ColorBlend
                {
                    Colors = new[]
                    {
                        Color.FromArgb(0, 15, 36),
                        Color.FromArgb(0, 15, 36),
                        Color.FromArgb(250, 250, 250),
                        Color.FromArgb(150, 150, 150),
                        Color.FromArgb(55, 58, 59),
                        Color.FromArgb(25, 20, 31),
                        Color.FromArgb(240, 240, 240),
                        Color.FromArgb(166, 175, 194),
                        Color.FromArgb(50, 50, 50),
                        Color.FromArgb(50, 50, 50),
                    },

                    Positions = new[]
                    {
                        0,
                        0.15f,
                        0.28f,
                        0.35f,
                        0.55f,
                        0.65f,
                        0.72f,
                        0.75f,
                        0.8f,
                        1,
                    }
                };
                brush.InterpolationColors = blend;

                var pen = new Pen(brush, 19)
                {
                    LineJoin = LineJoin.Round,
                };
                g.DrawPath(pen, graphiscPath);
            }

            // 黒色
            {
                var graphiscPath = new GraphicsPath();
                graphiscPath.AddString(text, bottomFontFamily, (int)FontStyle.Italic, 100, new PointF(0, 0), null);
                var pen = new Pen(Color.FromArgb(16, 25, 58), 17)
                {
                    LineJoin = LineJoin.Round,
                };
                g.DrawPath(pen, graphiscPath);
            }

            // 白
            {
                var graphiscPath = new GraphicsPath();
                graphiscPath.AddString(text, bottomFontFamily, (int)FontStyle.Italic, 100, new PointF(0, 0), null);
                var pen = new Pen(Color.FromArgb(13, 13, 13), 7)
                {
                    LineJoin = LineJoin.Round,
                };
                g.DrawPath(pen, graphiscPath);
            }

            // 紺色
            {
                var graphiscPath = new GraphicsPath();
                graphiscPath.AddString(text, bottomFontFamily, (int)FontStyle.Italic, 100, new PointF(0, 0), null);
                LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(0, 0, ImageWidth, 135),
                    Color.AliceBlue, Color.AntiqueWhite, LinearGradientMode.Vertical);
                ColorBlend blend = new ColorBlend
                {
                    Colors = new[]
                    {
                        Color.FromArgb(16,25,58),
                        Color.FromArgb(16,25,58),
                        Color.FromArgb(255,255,255),
                        Color.FromArgb(16,25,58),
                        Color.FromArgb(16,25,58),
                        Color.FromArgb(16,25,58),
                    },

                    Positions = new[]
                    {
                        0,
                        0.23f,
                        0.26f,
                        0.28f,
                        0.37f,
                        1,
                    }
                };
                brush.InterpolationColors = blend;

                var pen = new Pen(brush, 7)
                {
                    LineJoin = LineJoin.Round,
                };
                g.DrawPath(pen, graphiscPath);
            }

            // 銀色
            {
                var graphiscPath = new GraphicsPath();
                graphiscPath.AddString(text, bottomFontFamily, (int)FontStyle.Italic, 100, new PointF(0, 0 - 3), null);
                LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(0, 0, ImageWidth, 135),
                    Color.AliceBlue, Color.AntiqueWhite, LinearGradientMode.Vertical);
                ColorBlend blend = new ColorBlend
                {
                    Colors = new[]
                    {
                        Color.FromArgb(245,246,248),
                        Color.FromArgb(255,255,255),
                        Color.FromArgb(195,213,220),
                        Color.FromArgb(160,190,201),
                        Color.FromArgb(160,190,201),
                        Color.FromArgb(196,215,222),
                        Color.FromArgb(255,255,255),
                        Color.FromArgb(255,255,255),
                    },

                    Positions = new[]
                    {
                        0,
                        0.2f,
                        0.4f,
                        0.55f,
                        0.56f,
                        0.57f,
                        0.82f,
                        1,
                    }
                };
                brush.InterpolationColors = blend;

                g.FillPath(brush, graphiscPath);
            }

            #endregion

            var range = MeasureImage(img);
            return img.Clone(new Rectangle(range.left, 0, range.right - range.left, img.Height), img.PixelFormat);
        }

        static (int left, int right) MeasureImage(Bitmap bitmap)
        {
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            byte[] buf = new byte[bitmapData.Height * bitmapData.Stride];
            Marshal.Copy(bitmapData.Scan0, buf, 0, buf.Length);

            int left = 0;
            int right = 0;

            for (int i = 0; i < bitmapData.Width; i++)
            {
                for (int j = 0; j < bitmapData.Height; j++)
                {
                    if (buf[bitmapData.Stride * j + i * 4 + 3] != 0)
                    {
                        if (left == 0)
                        {
                            left = i;
                        }
                        right = i;
                        break;
                    }
                }
            }

            right++;
            Debug.WriteLine(left);
            Debug.WriteLine(right);

            bitmap.UnlockBits(bitmapData);

            return (left, right);
        }


    }
}
