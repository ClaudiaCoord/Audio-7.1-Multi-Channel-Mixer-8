/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(cmn) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

using System.Runtime.CompilerServices;

namespace MCM8.Audio
{
    [Serializable]
    public class Audio8Exception : Exception {
		public int ExcLine = -1;
        public string? ExcPath = null;
        public string? ExcClass = null;
		public Audio8Exception() { }
        public Audio8Exception(string m, string? cmn, string? cfp, int cln) : base(m) {
            ExcLine = cln;
            ExcPath = cfp;
            ExcClass = cmn;
        }
        public Audio8Exception(string message) : base(message) { }
		public Audio8Exception(string message, Exception inner) : base(message, inner) { }
		protected Audio8Exception(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
    public class Audio8ArgumentException : ArgumentException {
        public int ExcLine = -1;
        public string? ExcPath = null;
        public string? ExcClass = null;
        public Audio8ArgumentException() { }
        public Audio8ArgumentException(string m, string n, string? cmn, string? cfp, int cln) : base(m,n)
        {
            ExcLine = cln;
            ExcPath = cfp;
            ExcClass = cmn;
        }
        public Audio8ArgumentException(string m, string n) : base(m, n) { }
        public Audio8ArgumentException(string message, Exception inner) : base(message, inner) { }
        protected Audio8ArgumentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public static class ExceptionUtils {
        public static Audio8Exception AudioException(this string s,
            [CallerMemberName] string? cmn = null,
            [CallerFilePath] string? cfp = null,
            [CallerLineNumber] int cln = 0) {
            return new Audio8Exception(s, cmn, cfp, cln);
        }
        public static Audio8ArgumentException AudioArgumentException(this string s, string n,
            [CallerMemberName] string? cmn = null,
            [CallerFilePath] string? cfp = null,
            [CallerLineNumber] int cln = 0) {
            return new Audio8ArgumentException(s, n, cmn, cfp, cln);
        }
    }
}
