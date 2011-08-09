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

public partial class MainWindow : Gtk.Window
{
	FmodSharp.Gtk.FFTDraw fft_Draw;
	FmodSharp.SoundSystem.SoundSystem SoundSystem;
	FmodSharp.Channel.Channel Channel;
	FmodSharp.Sound.Sound SoundFile;
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		this.SoundSystem = new FmodSharp.SoundSystem.SoundSystem();
		this.SoundSystem.Init();
		
		this.SoundFile = SoundSystem.CreateSound (@"/home/madrang/Music/Tetris.mp3", FmodSharp.Mode.Default);
		
		if(this.Channel == null)
			this.Channel = this.SoundSystem.PlaySound(SoundFile);
		else
			this.SoundSystem.PlaySound(SoundFile, false, this.Channel);
		
		
		this.fft_Draw = new FmodSharp.Gtk.FFTDraw();
		this.fft_Draw.Source = this.Channel;
		this.fft_Draw.Show();
		this.Add(this.fft_Draw);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		this.SoundFile.Dispose();
		this.SoundSystem.CloseSystem();
		this.SoundSystem.Dispose();
		
		Application.Quit ();
		a.RetVal = true;
	}
	
}
