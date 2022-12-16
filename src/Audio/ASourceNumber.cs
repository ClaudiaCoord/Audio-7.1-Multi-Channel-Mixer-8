/*
	Git: https://github.com/ClaudiaCoord/Audio-7.1-Multi-Channel-Mixer-8
	ASIO 8 Multi Channel Mixer / 7.1 Sound card compatible (CM6206).
	(c) CC 2022, MIT

	See README.md for more details.
	NOT FOR CHINESE USE FOR SALES! FREE SOFTWARE!
*/

namespace MCM8.Audio
{
    public enum SourceNumber : int
    {
        Source_None = 0,
        Source_1_2 = 1, Source_3_4 = 2, Source_5_6 = 3, Source_7_8 = 4
    }
    public enum PlayerSourceNumber : int
    {
        Player_None = 0,
        Player_1 = 1, Player_2 = 2, Player_3 = 3, Player_4 = 4
    }
    public enum PlayerSourceControl : int
    {
        Player_Clear = -1,
        Player_Idle = 0,
        Player_Play = 1, Player_Pause = 2, Player_FF = 3, Player_RR = 4, Player_Previous = 5, Player_Next = 6, Player_Repeat = 7,
        Player_Stop = 8
    }

    public static class SourceNumberUtils
    {
        public static int ToInt(this SourceNumber cn) =>
            cn switch
            {
                SourceNumber.Source_1_2 => 0,
                SourceNumber.Source_3_4 => 1,
                SourceNumber.Source_5_6 => 2,
                SourceNumber.Source_7_8 => 3,
                _ => -1
            };
        public static SourceNumber SourceFromInt(this int n) =>
            n switch
            {
                0 => SourceNumber.Source_1_2,
                1 => SourceNumber.Source_3_4,
                2 => SourceNumber.Source_5_6,
                3 => SourceNumber.Source_7_8,
                _ => SourceNumber.Source_None
            };

        public static int ToInt(this PlayerSourceNumber cn) =>
            cn switch
            {
                PlayerSourceNumber.Player_1 => 0,
                PlayerSourceNumber.Player_2 => 1,
                PlayerSourceNumber.Player_3 => 2,
                PlayerSourceNumber.Player_4 => 3,
                _ => -1
            };
        public static PlayerSourceNumber PlayerFromInt(this int n) =>
            n switch
            {
                0 => PlayerSourceNumber.Player_1,
                1 => PlayerSourceNumber.Player_2,
                2 => PlayerSourceNumber.Player_3,
                3 => PlayerSourceNumber.Player_4,
                _ => PlayerSourceNumber.Player_None
            };
        public static PlayerSourceNumber PlayerFromSourceNumber(this SourceNumber cn) =>
            cn switch
            {
                SourceNumber.Source_1_2 => PlayerSourceNumber.Player_1,
                SourceNumber.Source_3_4 => PlayerSourceNumber.Player_2,
                SourceNumber.Source_5_6 => PlayerSourceNumber.Player_3,
                SourceNumber.Source_7_8 => PlayerSourceNumber.Player_4,
                _ => PlayerSourceNumber.Player_None
            };
        public static int ToChannelIndex(this int n) =>
            n switch
            {
                2 => 0,
                4 => 1,
                6 => 2,
                8 => 3,
                _ => -1
            };
        public static int ToChannelNumber(this int n) =>
            n switch
            {
                0 => 2,
                1 => 4,
                2 => 6,
                3 => 8,
                _ => -1
            };
        public static bool IsMapChannelsValid(this int[] arr) => arr != null && arr.Length == 2 && arr[0] >= 0 && arr[1] >= 0;
        public static int[] DefaultMapChannels(this SourceNumber cn)
        {
            int[] x = new int[2];
            x[0] = (cn.ToInt() * 2);
            x[1] = x[0] + 1;
            return x;
        }
    }

}
