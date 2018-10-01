// ReSharper disable StringIndexOfIsCultureSpecific.1
namespace PieceMover
{
    using ExternalInput;
    using Moves;
    using Pieces;

    public static class MoveReader
    {
        private const ScanCodeShort NullRank = ScanCodeShort.KEY_9;
        private const ScanCodeShort NullFile = ScanCodeShort.KEY_I;

        public static Input ReadMove(string input)
        {
            var move = default(Input);

            if (input.IsPawnMove())
                move = PawnMove(input);

            else if (input.IsPawnTakesMove())
                move = PawnTakesMove(input);

            else if (input.IsPieceTakesMove())
                move = PieceTakesMove(input);

            else if (input.IsPieceMove())
                move = PieceMove(input);

            if (input.IsPromotionMove())
                move = PromotionMove(input);

            if (input.IsPromotionTakesMove())
                move = PromotionTakesMove(input);

            return move;
        }

        private static bool IsPawnMove(this string move) => move.Length == 2;

        private static bool IsPawnTakesMove(this string move)
        {
            if (move.IsTakesMove())
            {
                var takes = move.IndexOf("x");

                var pawn = move.Substring(0, takes);

                return pawn.Length == 1 && GetPiece(move) == null;
            }

            return false;
        }

        private static bool IsTakesMove(this string move) => move.Contains("x");

        private static bool IsPieceMove(this string move) => (move.Contains("N") ||
                                                             move.Contains("B") ||
                                                             move.Contains("R") ||
                                                             move.Contains("Q") ||
                                                             move.Contains("K")) && !IsPromotionMove(move);

        private static bool IsPieceTakesMove(this string move)
        {
            return move.Contains("x") && IsPieceMove(move);
        }

        private static bool IsPromotionTakesMove(this string move)
        {
            return move.Contains("=") && move.Contains("x");
        }

        private static bool IsPromotionMove(this string move)
        {
            return move.Contains("=");
        }

        private static Move PawnMove(string move)
        {
            var square = GetSquare(move);

            return new Move(square);
        }

        private static Move PawnTakesMove(string move)
        {
            var pawn = GetFile(move.Substring(0, 1));
            var square = GetSquare(move);

            return new PawnTakesMove(pawn, square);
        }

        private static Move PieceTakesMove(string move)
        {
            var square = GetSquare(move);

            var pieceInput = move.Substring(0, move.IndexOf("x"));

            var piece = GetPiece(pieceInput);

            return new TakeMove(piece, square);
        }

        private static Move PieceMove(string move)
        {
            var square = GetSquare(move);

            var piece = GetPiece(move);

            return new Move(piece, square);
        }

        private static Input PromotionMove(string move)
        {
            var piece = GetPiece(move.Substring(move.Length - 1, 1));
            var square = GetSquare(move.Substring(0, 2));

            return new Promotion(new Move(square), piece);
        }

        private static Input PromotionTakesMove(string move)
        {
            var piece = GetPiece(move.Substring(move.Length - 1, 1));
            var square = GetSquare(move.Substring(move.IndexOf("x") + 1, 2));
            var file = GetFile(move.Substring(0, 1));

            return new Promotion(new PawnTakesMove(file, square), piece);
        }

        private static Square GetSquare(string move)
        {
            var file = move.Substring(move.Length -2, 1);
            var rank = move.Substring(move.Length - 1, 1);
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
                    fileKey = NullFile;
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
                    rankKey = NullRank;
                    break;
            }

            return rankKey;
        }

        private static Piece GetPiece(string piece)
        {
            var type = piece.Substring(0, 1);
            Piece pieceType;

            if (piece.Length >= 2)
            {
                pieceType = NewUp(piece.Substring(1, 1));
            }
            else
            {
                pieceType = NewUp();
            }

            return pieceType;

            Piece NewUp(string id = null)
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var rank = GetRank(id);
                    var file = GetFile(id);

                    var val = rank == NullRank ? file : rank;

                    switch (type)
                    {
                        case "N":
                            return new Knight(val);
                        case "B":
                            return new Bishop(val);
                        case "R":
                            return new Rook(val);
                        case "Q":
                            return new Queen(val);
                        default:
                            return default(Piece);
                    }
                }
                else
                {
                    switch (type)
                    {
                        case "N":
                            return new Knight();
                        case "B":
                            return new Bishop();
                        case "R":
                            return new Rook();
                        case "Q":
                            return new Queen();
                        case "K":
                            return new King();
                        default:
                            return default(Piece);
                    }
                }
            }
        }
    }
}
