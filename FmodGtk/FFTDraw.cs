using System;

namespace FmodGtk
{
	[System.ComponentModel.ToolboxItem(true)]
	public class FFTDraw : Gtk.DrawingArea
	{
		private System.Threading.Timer updater;
		private float[] spectrum;
		public FmodSharp.Channel.Channel Channel;
		
		public FFTDraw ()
		{
			// Insert initialization code here.
			this.spectrum = new float[1024];
			this.updater = new System.Threading.Timer(this.DoFFT);
			this.updater.Change(0, 50);
		}
		
		protected override bool OnButtonPressEvent (Gdk.EventButton ev)
		{
			// Insert button press handling code here.
			return base.OnButtonPressEvent (ev);
		}

		protected override bool OnExposeEvent (Gdk.EventExpose ev)
		{
			base.OnExposeEvent (ev);
			
			using(Cairo.Context CairoContext = Gdk.CairoHelper.Create(this.GdkWindow)) {
				//Drawing code here.
				
				double Min = double.MaxValue;
				double Max = double.MinValue;
			
				foreach (float FloatItem in this.spectrum) {
					if(FloatItem > Max)
						Max = FloatItem;
					if(FloatItem < Min)
						Min = FloatItem;
				}
				
				Cairo.Rectangle GraphRect = new Cairo.Rectangle(20, 4,
				                                                this.Allocation.Width - 24, this.Allocation.Height - 24);
				
				Cairo.Rectangle XScaleRect = new Cairo.Rectangle(20, this.Allocation.Height - 20,
				                                                 this.Allocation.Width - 24, 16);
				
				Cairo.Rectangle YScaleRect = new Cairo.Rectangle(4, 4,
				                                                 16, this.Allocation.Height - 24);
				
				//Graph Background
				CairoContext.LineWidth = 1;
				CairoContext.SetSourceRGB(0.2, 0.2, 0.2);
				CairoContext.Rectangle(GraphRect);
				CairoContext.StrokePreserve();
				CairoContext.SetSourceRGB(1, 1, 1);
				CairoContext.Fill();
				
				//XScale
				for (int X = 0; X < XScaleRect.Width; X += 5) {
					CairoContext.MoveTo(XScaleRect.X + X, XScaleRect.Y);
					CairoContext.LineTo(XScaleRect.X + X, XScaleRect.Y + XScaleRect.Height);
				}
				
				//YScale
				for (int Y = 0; Y < YScaleRect.Height; Y += 5) {
					CairoContext.MoveTo(YScaleRect.X, YScaleRect.Y + Y);
					CairoContext.LineTo(YScaleRect.X + YScaleRect.Width, YScaleRect.Y + Y);
				}
				
				
				//Graph Line
				if(this.spectrum.Length <= 0)
					return true;
				
				Cairo.Point LastValue = new Cairo.Point(0, 0);
				CairoContext.SetSourceRGB(0.5, 0.5, 0.5);
				for (int i = 0; i < this.spectrum.Length; i ++) {
					
					double X = GraphRect.X + Scale(i, 0, (double)this.spectrum.Length, 4d, (double)GraphRect.Width - 8d);
					double Y = GraphRect.Y + Scale(this.spectrum[i], Min, Max, (double)GraphRect.Height - 8d, 4d);
					
					if(LastValue.X != 0 && LastValue.Y != 0) {
						CairoContext.MoveTo(X, Y);
						CairoContext.LineTo(LastValue.X, LastValue.Y);
					}
					LastValue.X = (int)X;
					LastValue.Y = (int)Y;
				}
				CairoContext.Stroke();
				
			}
			
			return true;
		}

		protected override void OnSizeAllocated (Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated (allocation);
			// Insert layout code here.
		}

		protected override void OnSizeRequested (ref Gtk.Requisition requisition)
		{
			// Calculate desired size here.
			requisition.Height = 50;
			requisition.Width = 50;
		}
		
		private void DoFFT(object state)
		{
			if(this.Channel == null || !this.Channel.IsPlaying)
				return;
			
			this.Channel.Spectrum(this.spectrum, this.spectrum.Length, 0, FmodSharp.Dsp.FFTWindow.BlackmanHarris);
			this.QueueDraw();
		}
		
		private static double Scale(double Value, double In_Min, double In_Max, double Out_Min, double Out_Max)
		{
			return (Value - In_Min) * (Out_Max - Out_Min) / (In_Max - In_Min) + Out_Min;
		}
	}
}

