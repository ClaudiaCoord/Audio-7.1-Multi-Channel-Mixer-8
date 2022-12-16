/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

namespace MCM8.UC
{
    public class ADevEventArgs : EventArgs
    {
        public ADev Dev { get; }
        public ADevEventArgs(ADev dev) => Dev = dev;
    }
    public class VolumeEventArgs : EventArgs
    {
        public bool Mute { get; }
        public double Volume { get; }
        public VolumeEventArgs(double d) => Volume = d;
        public VolumeEventArgs(float d, bool b) { Volume = 0.0 + d; Mute = b; }
    }
    public class BoolEventArgs : EventArgs
    {
        public bool IsEnable { get; }
        public BoolEventArgs(bool b) => IsEnable = b;
    }
    public class IntEventArgs : EventArgs
    {
        public int Number { get; }
        public IntEventArgs(int i) => Number = i;
    }
    public class StringEventArgs : EventArgs
    {
        public string Text { get; }
        public StringEventArgs(string s) => Text = s;
    }
}
