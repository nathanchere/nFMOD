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
		this.fft_Draw.Channel = this.Channel;
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
