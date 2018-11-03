using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace NPImage
{
    /// <summary>
    /// Nine patch image view.
    /// </summary>
    public class NPImageView : SKCanvasView
    {
        /// <summary>
        /// Cropped bitmap.
        /// </summary>
        SKBitmap _bitmap;
        /// <summary>
        /// Center rectangle.
        /// </summary>
        SKRectI _center;

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            if (_bitmap == null || _center == null)
            {
                var result = BuildBitmap("NPImage.Resources.default.9.png");
                _bitmap = result.bitmap;
                _center = result.center;
            }

            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.DrawBitmapNinePatch(_bitmap, _center, new SKRect(0, 0, e.Info.Width, e.Info.Height));
        }
        /// <summary>
        /// 9.png resource path.
        /// </summary>
        private string _Source;
        /// <summary>
        /// 9.png resource path.
        /// </summary>
        public string Source
        {
            get { return _Source; }
            set
            {
                var result = BuildBitmap(value);
                _bitmap = result.bitmap;
                _center = result.center;
                _Source = value;
            }
        }

        protected (SKBitmap bitmap, SKRectI center) BuildBitmap(string resourceId)
        {
            var projectName = resourceId?.Split('.')[0];
            System.Diagnostics.Trace.Assert(!string.IsNullOrWhiteSpace(projectName), $"Invalid resoueceId {resourceId}.");

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(asm => asm.FullName.Contains(projectName));
            System.Diagnostics.Trace.Assert(assemblies.Any(), $"NO assembly DLL file for {projectName}.");

            var assembly = assemblies.FirstOrDefault(asm => asm.GetManifestResourceNames().Any(name => name.Equals(resourceId)));
            System.Diagnostics.Trace.Assert(assembly != null, $"NO assembly DLL file for {resourceId}.");

            using (var stream = assembly.GetManifestResourceStream(resourceId))
            {
                return BuildBitmapFromStream(stream);
            }
        }

        private (SKBitmap bitmap, SKRectI center) BuildBitmapFromStream(Stream stream)
        {
            var bitmapAll = SKBitmap.Decode(stream);

            var bitmap = CropBitmap(bitmapAll);

            var center = BuildCenter(bitmapAll);

            return (bitmap, center);
        }

        private static SKBitmap CropBitmap(SKBitmap bitmap)
        {
            var resultBitmap = new SKBitmap(bitmap.Width - 2, bitmap.Height - 2);
            using (var canvas = new SKCanvas(resultBitmap))
            {
                canvas.DrawBitmap(bitmap,
                    new SKRect(1, 1, bitmap.Width - 1, bitmap.Height - 1),
                    new SKRect(0, 0, bitmap.Width - 2, bitmap.Height - 2));
            }

            return resultBitmap;
        }

        private SKRectI BuildCenter(SKBitmap bitmap)
        {
            var left = (bitmap.Width - 2) / 2;
            var right = left + 1;
            var top = (bitmap.Height - 2) / 2;
            var bottom = top + 1;

            var xs = new List<int>();
            for (int i = 1; i < bitmap.Width - 1; i++)
            {
                var color = bitmap.GetPixel(i, 0);
                if (color.Alpha != 0)
                {
                    xs.Add(i - 1);
                }
            }
            if (xs.Count > 0)
            {
                left = xs.Min();
                if (xs.Count == 1)
                {
                    right = left + 1;
                }
                else
                {
                    right = xs.Max();
                }
            }

            var ys = new List<int>();
            for (int i = 1; i < bitmap.Height - 1; i++)
            {
                var color = bitmap.GetPixel(i, 0);
                if (color.Alpha != 0)
                {
                    ys.Add(i - 1);
                }
            }
            if (ys.Count > 0)
            {
                top = ys.Min();
                if (ys.Count == 1)
                {
                    bottom = top + 1;
                }
                else
                {
                    bottom = ys.Max();
                }
            }

            var result = new SKRectI(left, top, right, bottom);
            return result;
        }
    }
}
