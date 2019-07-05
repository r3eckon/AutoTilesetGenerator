using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoTileGenerator.Scripts
{

    public static class AutoTileUtilities
    {
        //Type count, used for tile type offsets
        public const int TypeCount = 46;

        public static string[] latestAutoTilesetTexturePaths;
        public static string latestAutoTilesetPrefix;

        public static Texture2D[] GetAutoTileCollection(AutoTileFragments[] fragsArray, Texture2D blob, int twidth, int theight)
        {
            Texture2D[] toret = new Texture2D[fragsArray.Length];

            for(int i = 0; i < fragsArray.Length; i++)
            {
                toret[i] = GetAutoTile(fragsArray[i], blob, twidth, theight);
            }

            return toret;
        }

        public static Texture2D GetAutoTile(AutoTileFragments frags, Texture2D atlas, int twidth, int theight)
        {
            Texture2D toret = new Texture2D(twidth, theight, atlas.format, false);
            toret.filterMode = FilterMode.Point;
            int hw = twidth / 2;
            int hh = theight / 2;
            Color32[] blobArray = atlas.GetPixels32();

            //A Minitile
            toret.SetPixels(0, hh, hw, hh, atlas.GetPixels(frags.Apoint.x * twidth, (2 - frags.Apoint.y) * theight + hh, hw, hh));

            //B Minitile
            toret.SetPixels(hw, hh, hw, hh, atlas.GetPixels(frags.Bpoint.x * twidth + hw, (2 - frags.Bpoint.y) * theight + hh, hw, hh));

            //C MiniTile
            toret.SetPixels(0, 0, hw, hh, atlas.GetPixels(frags.Cpoint.x * twidth, (2 - frags.Cpoint.y) * theight, hw, hh));

            //D Minitile
            toret.SetPixels(hw, 0, hw, hh, atlas.GetPixels(frags.Dpoint.x * twidth + hw, (2 - frags.Dpoint.y) * theight, hw, hh));

            return toret;
        }

        public static byte AutoTileValueToTileTypeOffset(byte type)
        {
            byte toret = 48;

            switch (type)
            {
                case 1: toret = 0; break;
                case 2: toret = 1; break;
                case 4:toret = 2; break;
                case 8: toret = 3; break;
                case 16: toret = 4; break;
                case 32: toret = 5; break;
                case 64:toret = 6; break;
                case 128:toret = 7; break;
                case 5:toret = 8; break;
                case 33:toret = 9; break;
                case 129:toret = 10; break;
                case 36:toret = 11; break;
                case 132:toret = 12; break;
                case 160:toret = 13; break;
                case 37:toret = 14; break;
                case 133:toret = 15; break;
                case 161:toret = 16; break;
                case 164:toret = 17; break;
                case 165:toret = 18; break;
                case 66:toret = 19; break;
                case 24:toret = 20; break;
                case 12:toret = 21; break;
                case 136:toret = 22; break;
                case 140:toret = 23; break;
                case 17:toret = 24; break;
                case 48:toret = 25; break;
                case 49:toret = 26; break;
                case 34:toret = 27; break;
                case 130:toret = 28; break;
                case 162:toret = 29; break;
                case 65:toret = 30; break;
                case 68:toret = 31; break;
                case 69:toret = 32; break;
                case 10:toret = 33; break;
                case 18:toret = 34; break;
                case 72:toret = 35; break;
                case 80:toret = 36; break;
                case 138:toret = 37; break;
                case 50:toret = 38; break;
                case 76:toret = 39; break;
                case 81:toret = 40; break;
                case 26:toret = 41; break;
                case 82:toret = 42; break;
                case 88:toret = 43; break;
                case 74:toret = 44; break;
                case 90:toret = 45; break;
                default:Debug.Log(type);break;
            }

            return toret;
        }

        public static byte TileTypeOffsetToAutoTileValue(byte type)
        {
            byte toret = 48;

            switch (type)
            {
                case 0: toret = 1; break;
                case 1: toret = 2; break;
                case 2: toret = 4; break;
                case 3: toret = 8; break;
                case 4: toret = 16; break;
                case 5: toret = 32; break;
                case 6: toret = 64; break;
                case 7: toret = 128; break;
                case 8: toret = 5; break;
                case 9: toret = 33; break;
                case 10: toret = 129; break;
                case 11: toret = 36; break;
                case 12: toret = 132; break;
                case 13: toret = 160; break;
                case 14: toret = 37; break;
                case 15: toret = 133; break;
                case 16: toret = 161; break;
                case 17: toret = 164; break;
                case 18: toret = 165; break;
                case 19: toret = 66; break;
                case 20: toret = 24; break;
                case 21: toret = 12; break;
                case 22: toret = 136; break;
                case 23: toret = 140; break;
                case 24: toret = 17; break;
                case 25: toret = 48; break;
                case 26: toret = 49; break;
                case 27: toret = 34; break;
                case 28: toret = 130; break;
                case 29: toret = 162; break;
                case 30: toret = 65; break;
                case 31: toret = 68; break;
                case 32: toret = 69; break;
                case 33: toret = 10; break;
                case 34: toret = 18; break;
                case 35: toret = 72; break;
                case 36: toret = 80; break;
                case 37: toret = 138; break;
                case 38: toret = 50; break;
                case 39: toret = 76; break;
                case 40: toret = 81; break;
                case 41: toret = 26; break;
                case 42: toret = 82; break;
                case 43: toret = 88; break;
                case 44: toret = 74; break;
                case 45: toret = 90; break;
            }



            return toret;
        }

        public static AutoTileFragments BakePositions(AutoTileFragments frags)
        {
            switch (frags.A)
            {

                case AutoTileFragmentType.ConcaveCorner:
                    frags.Apoint.x = 1;
                    frags.Apoint.y = 0;
                    break;

                case AutoTileFragmentType.ConvexCorner:
                    frags.Apoint.x = 0;
                    frags.Apoint.y = 1;
                    break;

                case AutoTileFragmentType.Full:
                    frags.Apoint.x = 1;
                    frags.Apoint.y = 2;
                    break;

                case AutoTileFragmentType.VerticalSide:
                    frags.Apoint.x = 1;
                    frags.Apoint.y = 1;
                    break;

                case AutoTileFragmentType.HorizontalSide:
                    frags.Apoint.x = 0;
                    frags.Apoint.y = 2;
                    break;
            }

            switch (frags.B)
            {

                case AutoTileFragmentType.ConcaveCorner:
                    frags.Bpoint.x = 1;
                    frags.Bpoint.y = 0;
                    break;

                case AutoTileFragmentType.ConvexCorner:
                    frags.Bpoint.x = 1;
                    frags.Bpoint.y = 1;
                    break;

                case AutoTileFragmentType.Full:
                    frags.Bpoint.x = 0;
                    frags.Bpoint.y = 2;
                    break;

                case AutoTileFragmentType.VerticalSide:
                    frags.Bpoint.x = 0;
                    frags.Bpoint.y = 1;
                    break;

                case AutoTileFragmentType.HorizontalSide:
                    frags.Bpoint.x = 1;
                    frags.Bpoint.y = 2;
                    break;
            }

            switch (frags.C)
            {

                case AutoTileFragmentType.ConcaveCorner:
                    frags.Cpoint.x = 1;
                    frags.Cpoint.y = 0;
                    break;

                case AutoTileFragmentType.ConvexCorner:
                    frags.Cpoint.x = 0;
                    frags.Cpoint.y = 2;
                    break;

                case AutoTileFragmentType.Full:
                    frags.Cpoint.x = 1;
                    frags.Cpoint.y = 1;
                    break;

                case AutoTileFragmentType.VerticalSide:
                    frags.Cpoint.x = 1;
                    frags.Cpoint.y = 2;
                    break;

                case AutoTileFragmentType.HorizontalSide:
                    frags.Cpoint.x = 0;
                    frags.Cpoint.y = 1;
                    break;
            }

            switch (frags.D)
            {

                case AutoTileFragmentType.ConcaveCorner:
                    frags.Dpoint.x = 1;
                    frags.Dpoint.y = 0;
                    break;

                case AutoTileFragmentType.ConvexCorner:
                    frags.Dpoint.x = 1;
                    frags.Dpoint.y = 2;
                    break;

                case AutoTileFragmentType.Full:
                    frags.Dpoint.x = 0;
                    frags.Dpoint.y = 1;
                    break;

                case AutoTileFragmentType.VerticalSide:
                    frags.Dpoint.x = 0;
                    frags.Dpoint.y = 2;
                    break;

                case AutoTileFragmentType.HorizontalSide:
                    frags.Dpoint.x = 1;
                    frags.Dpoint.y = 1;
                    break;
            }

            return frags;
        }

        public static AutoTileFragments AutoTileValueToFragments(byte value)
        {
            AutoTileFragments toret = new AutoTileFragments();

            switch (value)
            {

                case 1:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 2:
                    toret.A = AutoTileFragmentType.VerticalSide;
                    toret.B = AutoTileFragmentType.VerticalSide;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 4:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 8:
                    toret.A = AutoTileFragmentType.HorizontalSide;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.HorizontalSide;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 16:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.HorizontalSide;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.HorizontalSide;
                    break;

                case 32:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 64:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.VerticalSide;
                    toret.D = AutoTileFragmentType.VerticalSide;
                    break;

                case 128:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 5:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 33:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 129:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 36:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 132:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 160:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 37:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 133:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 161:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 164:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 165:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 66:
                    toret.A = AutoTileFragmentType.VerticalSide;
                    toret.B = AutoTileFragmentType.VerticalSide;
                    toret.C = AutoTileFragmentType.VerticalSide;
                    toret.D = AutoTileFragmentType.VerticalSide;
                    break;

                case 24:
                    toret.A = AutoTileFragmentType.HorizontalSide;
                    toret.B = AutoTileFragmentType.HorizontalSide;
                    toret.C = AutoTileFragmentType.HorizontalSide;
                    toret.D = AutoTileFragmentType.HorizontalSide;
                    break;

                case 12:
                    toret.A = AutoTileFragmentType.HorizontalSide;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.HorizontalSide;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 136:
                    toret.A = AutoTileFragmentType.HorizontalSide;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.HorizontalSide;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 140:
                    toret.A = AutoTileFragmentType.HorizontalSide;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.HorizontalSide;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 17:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.HorizontalSide;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.HorizontalSide;
                    break;

                case 48:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.HorizontalSide;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.HorizontalSide;
                    break;

                case 49:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.HorizontalSide;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.HorizontalSide;
                    break;

                case 34:
                    toret.A = AutoTileFragmentType.VerticalSide;
                    toret.B = AutoTileFragmentType.VerticalSide;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 130:
                    toret.A = AutoTileFragmentType.VerticalSide;
                    toret.B = AutoTileFragmentType.VerticalSide;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 162:
                    toret.A = AutoTileFragmentType.VerticalSide;
                    toret.B = AutoTileFragmentType.VerticalSide;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 65:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.VerticalSide;
                    toret.D = AutoTileFragmentType.VerticalSide;
                    break;

                case 68:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.VerticalSide;
                    toret.D = AutoTileFragmentType.VerticalSide;
                    break;

                case 69:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.VerticalSide;
                    toret.D = AutoTileFragmentType.VerticalSide;
                    break;

                case 10:
                    toret.A = AutoTileFragmentType.ConvexCorner;
                    toret.B = AutoTileFragmentType.VerticalSide;
                    toret.C = AutoTileFragmentType.HorizontalSide;
                    toret.D = AutoTileFragmentType.Full;
                    break;

                case 18:
                    toret.A = AutoTileFragmentType.VerticalSide;
                    toret.B = AutoTileFragmentType.ConvexCorner;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.HorizontalSide;
                    break;

                case 72:
                    toret.A = AutoTileFragmentType.HorizontalSide;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.ConvexCorner;
                    toret.D = AutoTileFragmentType.VerticalSide;
                    break;

                case 80:
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.HorizontalSide;
                    toret.C = AutoTileFragmentType.VerticalSide;
                    toret.D = AutoTileFragmentType.ConvexCorner;
                    break;

                case 138:
                    toret.A = AutoTileFragmentType.ConvexCorner;
                    toret.B = AutoTileFragmentType.VerticalSide;
                    toret.C = AutoTileFragmentType.HorizontalSide;
                    toret.D = AutoTileFragmentType.ConcaveCorner;
                    break;

                case 50:
                    toret.A = AutoTileFragmentType.VerticalSide;
                    toret.B = AutoTileFragmentType.ConvexCorner;
                    toret.C = AutoTileFragmentType.ConcaveCorner;
                    toret.D = AutoTileFragmentType.HorizontalSide;
                    break;

                case 76:
                    toret.A = AutoTileFragmentType.HorizontalSide;
                    toret.B = AutoTileFragmentType.ConcaveCorner;
                    toret.C = AutoTileFragmentType.ConvexCorner;
                    toret.D = AutoTileFragmentType.VerticalSide;
                    break;

                case 81:
                    toret.A = AutoTileFragmentType.ConcaveCorner;
                    toret.B = AutoTileFragmentType.HorizontalSide;
                    toret.C = AutoTileFragmentType.VerticalSide;
                    toret.D = AutoTileFragmentType.ConvexCorner;
                    break;

                case 26:
                    toret.A = AutoTileFragmentType.ConvexCorner;
                    toret.B = AutoTileFragmentType.ConvexCorner;
                    toret.C = AutoTileFragmentType.HorizontalSide;
                    toret.D = AutoTileFragmentType.HorizontalSide;
                    break;

                case 82:
                    toret.A = AutoTileFragmentType.VerticalSide;
                    toret.B = AutoTileFragmentType.ConvexCorner;
                    toret.C = AutoTileFragmentType.VerticalSide;
                    toret.D = AutoTileFragmentType.ConvexCorner;
                    break;

                case 88:
                    toret.A = AutoTileFragmentType.HorizontalSide;
                    toret.B = AutoTileFragmentType.HorizontalSide;
                    toret.C = AutoTileFragmentType.ConvexCorner;
                    toret.D = AutoTileFragmentType.ConvexCorner;
                    break;

                case 74:
                    toret.A = AutoTileFragmentType.ConvexCorner;
                    toret.B = AutoTileFragmentType.VerticalSide;
                    toret.C = AutoTileFragmentType.ConvexCorner;
                    toret.D = AutoTileFragmentType.VerticalSide;
                    break;

                case 90:
                    toret.A = AutoTileFragmentType.ConvexCorner;
                    toret.B = AutoTileFragmentType.ConvexCorner;
                    toret.C = AutoTileFragmentType.ConvexCorner;
                    toret.D = AutoTileFragmentType.ConvexCorner;
                    break;

                default://This should not happen
                    toret.A = AutoTileFragmentType.Full;
                    toret.B = AutoTileFragmentType.Full;
                    toret.C = AutoTileFragmentType.Full;
                    toret.D = AutoTileFragmentType.Full;
                    break;

            }

            return toret;
        }

        public static byte NeighborhoodToAutoTileValue(TileNeighborhood n, TileType a, TileType b)
        {
            int toret = 0;

            toret += (n.northwest == b && n.north == a && n.west == a) ? 1 : 0;
            toret += (n.north == b) ? 2 : 0;
            toret += (n.northeast == b && n.north == a && n.east == a) ? 4 : 0;

            toret += (n.west == b) ? 8 : 0;
            toret += (n.east == b) ? 16 : 0;

            toret += (n.southwest == b && n.south == a && n.west == a) ? 32 : 0;
            toret += (n.south == b) ? 64 : 0;
            toret += (n.southeast == b && n.south == a && n.east == a) ? 128 : 0;

            return (byte)toret;
        }

        public static byte NeighborhoodToAutoTileValue(TileNeighborhood n, HashSet<uint> a, TileType b )
        {
            int toret = 0;

            toret += (n.northwest == b && a.Contains(n.north.typeID) && a.Contains(n.west.typeID)) ? 1 : 0;
            toret += (n.north == b) ? 2 : 0;
            toret += (n.northeast == b && a.Contains(n.north.typeID) && a.Contains(n.east.typeID)) ? 4 : 0;

            toret += (n.west == b) ? 8 : 0;
            toret += (n.east == b) ? 16 : 0;

            toret += (n.southwest == b && a.Contains(n.south.typeID) && a.Contains(n.west.typeID)) ? 32 : 0;
            toret += (n.south == b) ? 64 : 0;
            toret += (n.southeast == b && a.Contains(n.south.typeID) && a.Contains(n.east.typeID)) ? 128 : 0;

            return (byte)toret;
        }

    }

    public struct TMPoint
    {
        public int x, y;

        public static bool operator ==(TMPoint a, TMPoint b)
        {
            return (a.x == b.x && a.y == b.y);
        }

        public static bool operator !=(TMPoint a, TMPoint b)
        {
            return !(a == b);
        }
    }

    public struct AutoTileFragments
    {
        public AutoTileFragmentType A, B, C, D;
        public TMPoint Apoint, Bpoint, Cpoint, Dpoint;
    }

    public enum AutoTileFragmentType
    {
        ConvexCorner,
        ConcaveCorner,
        VerticalSide,
        HorizontalSide,
        Full,
    }
}



