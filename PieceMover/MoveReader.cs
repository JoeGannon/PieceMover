// ReSharper disable StringIndexOfIsCultureSpecific.1
namespace PieceMover
{
    using System.Collections;
    using ExternalInput;
    using Moves;

    public static class MoveReader
    {
        public static Move ReadMove(string input)
        {
            var move = default(Move);

            if (input.IsPawnMove())
                move = PawnMove(input);

            else if (input.IsPawnTakesMove())
                move = PawnTakesMove(input);

            return move;
        }

        private static bool IsPawnMove(this string move) => move.Length == 2;

        private static bool IsPawnTakesMove(this string move)
        {
            if (move.IsTakesMove())
            {
                var takes = move.IndexOf("x");

                var pawn = move.Substring(0, takes);

                return pawn.Length == 1;
            }

            return false;
        }

        private static bool IsTakesMove(this string move) => move.Contains("x");

        private static Move PawnMove(string move)
        {
            var square = GetSquare(move);

            return new Move(square);
        }

        private static Move PawnTakesMove(string move)
        {
            var pawn = GetFile(move.Substring(0, 1));
            var square = GetSquare(move.Substring(move.Length - 2));

            return new PawnTakesMove(pawn, square);
        }

        private static Square GetSquare(string move)
        {
            var file = move.Substring(0, 1);
            var rank = move.Substring(1);
            var square = new Square(GetFile(file), GetRank(rank));

            return square;
        }

        private static ScanCodeShort GetFile(string file)
        {
            ScanCodeShort fileKey;

            switch (file)
            {
                case "a":
                    fileKey = ScanCodeShort.KEY_A;
                    break;
                case "b":
                    fileKey = ScanCodeShort.KEY_B;
                    break;
                case "c":
                    fileKey = ScanCodeShort.KEY_C;
                    break;
                case "d":
                    fileKey = ScanCodeShort.KEY_D;
                    break;
                case "e":
                    fileKey = ScanCodeShort.KEY_E;
                    break;
                case "f":
                    fileKey = ScanCodeShort.KEY_F;
                    break;
                case "g":
                    fileKey = ScanCodeShort.KEY_G;
                    break;
                case "h":
                    fileKey = ScanCodeShort.KEY_H;
                    break;
                default:
                    fileKey = ScanCodeShort.KEY_I;
                    break;
            }

            return fileKey;
        }

        private static ScanCodeShort GetRank(string rank)
        {
            ScanCodeShort rankKey;

            switch (rank)
            {
                case "1":
                    rankKey = ScanCodeShort.KEY_1;
                    break;
                case "2":
                    rankKey = ScanCodeShort.KEY_2;
                    break;
                case "3":
                    rankKey = ScanCodeShort.KEY_3;
                    break;
                case "4":
                    rankKey = ScanCodeShort.KEY_4;
                    break;
                case "5":
                    rankKey = ScanCodeShort.KEY_5;
                    break;
                case "6":
                    rankKey = ScanCodeShort.KEY_6;
                    break;
                case "7":
                    rankKey = ScanCodeShort.KEY_7;
                    break;
                case "8":
                    rankKey = ScanCodeShort.KEY_8;
                    break;
                default:
                    rankKey = ScanCodeShort.KEY_9;
                    break;
            }

            return rankKey;
        }
    }
}
