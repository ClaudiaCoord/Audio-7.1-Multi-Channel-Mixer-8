/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

namespace MCM8.UC
{
    public static class InvokeUtils
    {
        public static void Invoker(this Control ctrl, Action act)
        {
            if (ctrl.IsHandleCreated && ctrl.InvokeRequired)
                ctrl.Invoke(act);
            else
                act.Invoke();
        }
        public static void InvokerSafe(this Control ctrl, Action act)
        {
            try { ctrl.Invoker(act); } catch { }
        }
    }
}
