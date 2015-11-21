using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Interop;
using ImagingDevice;
using System.Drawing;

namespace WebcamCapture
{
    /// <summary>
    /// 
    /// Parts of this code is sourced from a sample by Jon Preece @ http://www.jpreece.com/wpf/webcam-image-capture/
    /// This code is made available under the GNU License. 
    /// This code is provided AS IS. No Warranties.
    /// 
    /// </summary>
    public partial class WebcamCapture : UserControl
    {
        private ImageGrabber _grabber;
        private IntPtr _hwnd = IntPtr.Zero;

        public WebcamCapture()
        {
            InitializeComponent();
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {

        }

        public void StartCapture()
        {
            var hwndSource = PresentationSource.FromVisual(CameraImage) as HwndSource;

            if (hwndSource != null)
            {
                _hwnd = hwndSource.Handle;

                _grabber = new ImageGrabber(_hwnd.ToInt32());
                _grabber.ImageCaptured += grabber_ImageCaptured;
                _grabber.Start();
            }
        }

        public void StopCapture()
        {
            if (_grabber != null)
            {
                _grabber.Stop();
                _grabber = null;
                _hwnd = IntPtr.Zero;
            }
        }

        public BitmapSource GrabImage()
        {
            return (BitmapSource)CameraImage.Source;
        }

        private void grabber_ImageCaptured(object source, ImageGrabberEventArgs e)
        {
            CameraImage.Source = e.DeviceImage.ToBitmapSource();
        }
    }

    /// <summary>
    /// http://stackoverflow.com/questions/94456/load-a-wpf-bitmapimage-from-a-system-drawing-bitmap
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts a <see cref="System.Drawing.Image"/> into a WPF <see cref="BitmapSource"/>.
        /// </summary>
        /// <param name="source">The source image.</param>
        /// <returns>A BitmapSource</returns>
        public static BitmapSource ToBitmapSource(this System.Drawing.Image source)
        {
            var bitmap = new Bitmap(source);

            var bitSrc = bitmap.ToBitmapSource();

            bitmap.Dispose();

            return bitSrc;
        }

        /// <summary>
        /// Converts a <see cref="System.Drawing.Bitmap"/> into a WPF <see cref="BitmapSource"/>.
        /// </summary>
        /// <remarks>Uses GDI to do the conversion. Hence the call to the marshalled DeleteObject.
        /// </remarks>
        /// <param name="source">The source bitmap.</param>
        /// <returns>A BitmapSource</returns>
        public static BitmapSource ToBitmapSource(this Bitmap source)
        {
            BitmapSource bitSrc;

            IntPtr hBitmap = source.GetHbitmap();

            try
            {
                bitSrc = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Win32Exception)
            {
                bitSrc = null;
            }
            finally
            {
                NativeMethods.DeleteObject(hBitmap);
            }

            return bitSrc;
        }

        #region Nested type: NativeMethods

        /// <summary>
        /// FxCop requires all Marshalled functions to be in a class called NativeMethods.
        /// </summary>
        internal static class NativeMethods
        {
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool DeleteObject(IntPtr hObject);
        }

        #endregion
    }
}

