using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace NPImage
{
    /// <summary>
    /// Three states nine patch image view.
    /// </summary>
    public class TSNPImageView : NPImageView
    {
        /// <summary>
        /// Cropped bitmap.
        /// </summary>
        SKBitmap _bitmapPressed;
        /// <summary>
        /// Center rectangle.
        /// </summary>
        SKRectI _centerPressed;
        /// <summary>
        /// Cropped bitmap.
        /// </summary>
        SKBitmap _bitmapDisabled;
        /// <summary>
        /// Center rectangle.
        /// </summary>
        SKRectI _centerDisabled;

        /// <summary>
        /// Pressed state.
        /// </summary>
        private bool _IsPressed;
        /// <summary>
        /// Pressed state.
        /// </summary>
        public bool IsPressed
        {
            get { return _IsPressed; }
            set
            {
                _IsPressed = value;
                InvalidateSurface();
            }
        }

        /// <summary>
        /// 9.png resource path.
        /// </summary>
        private string _SourcePressed;
        /// <summary>
        /// 9.png resource path.
        /// </summary>
        public string SourcePressed
        {
            get { return _SourcePressed; }
            set
            {
                var result = BuildBitmap(value);
                _bitmapPressed = result.bitmap;
                _centerPressed = result.center;
                _SourcePressed = value;
            }
        }
        /// <summary>
        /// 9.png resource path.
        /// </summary>
        private string _SourceDisabled;
        /// <summary>
        /// 9.png resource path.
        /// </summary>
        public string SourceDisabled
        {
            get { return _SourceDisabled; }
            set
            {
                var result = BuildBitmap(value);
                _bitmapDisabled = result.bitmap;
                _centerDisabled = result.center;
                _SourceDisabled = value;
            }
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            if (IsEnabled)
            {
                if (IsPressed)
                {
                    OnPaintSurfacePressed(e);
                }
                else
                {
                    OnPaintSurfaceDefault(e);
                }
            }
            else
            {
                OnPaintSurfaceDisabled(e);
            }
        }

        private void OnPaintSurfacePressed(SKPaintSurfaceEventArgs e)
        {
            if (Source == null)
            {
                if (_bitmapPressed == null || _centerPressed == null)
                {
                    var result = BuildBitmap("NPImage.Resources.pressed.9.png");
                    _bitmapPressed = result.bitmap;
                    _centerPressed = result.center;

                }
            }
            else
            {
                if (_bitmapPressed == null || _centerPressed == null)
                {
                    OnPaintSurfaceDefault(e);
                    return;
                }
            }

            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.DrawBitmapNinePatch(_bitmapPressed, _centerPressed, new SKRect(0, 0, e.Info.Width, e.Info.Height));
        }

        private void OnPaintSurfaceDefault(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
        }

        private void OnPaintSurfaceDisabled(SKPaintSurfaceEventArgs e)
        {
            if (Source == null)
            {
                if (_bitmapDisabled == null || _centerDisabled == null)
                {
                    var result = BuildBitmap("NPImage.Resources.disabled.9.png");
                    _bitmapDisabled = result.bitmap;
                    _centerDisabled = result.center;

                }
            }
            else
            {
                if (_bitmapDisabled == null || _centerDisabled == null)
                {
                    OnPaintSurfaceDefault(e);
                    return;
                }
            }

            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.DrawBitmapNinePatch(_bitmapDisabled, _centerDisabled, new SKRect(0, 0, e.Info.Width, e.Info.Height));
        }
    }
}
