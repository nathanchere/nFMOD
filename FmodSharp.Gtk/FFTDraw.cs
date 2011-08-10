//Author:
//      Marc-Andre Ferland <madrang@gmail.com>
//
//Copyright (c) 2011 TheWarrentTeam
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using System;
using Gtk;

namespace TheWarrentTeam.FmodSharp.Gtk
{
	[System.ComponentModel.ToolboxItem(true)]
	public class FFTDraw : DrawingArea
	{
		private System.Threading.Timer updater;
		private float[] data;
		public TheWarrentTeam.FmodSharp.iSpectrumWave Source;
		Cairo.Rectangle graphRect;
		Cairo.Rectangle scaleRectX;
		Cairo.Rectangle scaleRectY;
		
		public FFTDraw ()
		{
			// Insert initialization code here.
			this.data = new float[512];
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
				
				//Graph Background
				CairoContext.LineWidth = 1;
				CairoContext.SetSourceRGB(0.2, 0.2, 0.2);
				CairoContext.Rectangle(this.graphRect);
				CairoContext.StrokePreserve();
				CairoContext.SetSourceRGB(1, 1, 1);
				CairoContext.Fill();
				
				if(this.data.Length <= 0)
					return true;
				
				double Min = double.MaxValue;
				double Max = double.MinValue;
				
				foreach (float FloatItem in this.data) {
					if(FloatItem > Max)
						Max = FloatItem;
					if(FloatItem < Min)
						Min = FloatItem;
				}
				
				//XScale
				int XStep = 100 - ((int)(Min - Max) / 100);
				XStep = Math.Max(XStep, 1);
				for (int X = 0; X < this.scaleRectX.Width; X += XStep) {
					CairoContext.MoveTo(this.scaleRectX.X + X, this.scaleRectX.Y);
					CairoContext.LineTo(this.scaleRectX.X + X, this.scaleRectX.Y + this.scaleRectX.Height);
				}
				
				//YScale
				int YStep = 100 - (this.data.Length / 100);
				YStep = Math.Max(YStep, 1);
				for (int Y = 0; Y < this.scaleRectY.Height; Y += YStep) {
					CairoContext.MoveTo(this.scaleRectY.X, this.scaleRectY.Y + Y);
					CairoContext.LineTo(this.scaleRectY.X + this.scaleRectY.Width, this.scaleRectY.Y + Y);
				}
				
				//Graph Line
				CairoContext.LineWidth = 2;
				Cairo.Point LastValue = new Cairo.Point(0, 0);
				CairoContext.SetSourceRGB(0.5, 0.5, 0.5);
				for (int i = 0; i < this.data.Length; i ++) {
					
					double X = this.graphRect.X + Scale(i, 0, (double)this.data.Length, 4d, (double)this.graphRect.Width - 8d);
					double Y = this.graphRect.Y + Scale(this.data[i], Min, Max, (double)this.graphRect.Height - 8d, 4d);
					
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
			
			this.graphRect = new Cairo.Rectangle(20, 4,
			                                     allocation.Width - 24, allocation.Height - 24);
				
			this.scaleRectX = new Cairo.Rectangle(20, allocation.Height - 20,
			                                      allocation.Width - 24, 16);
				
			this.scaleRectY = new Cairo.Rectangle(4, 4,
			                                      16, allocation.Height - 24);
		}

		protected override void OnSizeRequested (ref Requisition requisition)
		{
			// Calculate desired size here.
			requisition.Height = 50;
			requisition.Width = 50;
		}
		
		private void DoFFT(object state)
		{
			if(this.Source == null || !this.Source.IsPlaying)
				return;
			
			this.Source.GetSpectrum(this.data, this.data.Length, 0, TheWarrentTeam.FmodSharp.Dsp.FFTWindow.BlackmanHarris);
			//this.Channel.GetWaveData (this.spectrum, this.spectrum.Length, 0);
			this.QueueDraw();
		}
		
		private static double Scale(double Value, double In_Min, double In_Max, double Out_Min, double Out_Max)
		{
			return (Value - In_Min) * (Out_Max - Out_Min) / (In_Max - In_Min) + Out_Min;
		}
	}
}

