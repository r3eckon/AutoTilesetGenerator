using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace AutoTileGenerator.Scripts
{
    public class TileType
    {
        
        public Color32 val;
        public string name;
        public uint typeID;
        public string spritePath;

        public TileType(Color32 v, string n, string p)
        {
            this.val = v;
            this.name = n;
            this.typeID = ColorTypeToInt();
            this.spritePath = p;
        }

        public uint ColorTypeToInt()
        {
            return (uint)(val.r + (val.g << 8) + (val.b << 16) + (val.a << 24));
        }

        public static Color32 UIntToColor32(uint val)
        {
            return new Color32((byte)(val << 24 >> 24) , (byte)(val << 16 >> 24)  , (byte)(val << 8 >> 24) , (byte)(val >> 24));
        }

        //Overloaded comparison operators to only check the type value since colors cannot be compared
        public static bool operator== (TileType a, TileType b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return ReferenceEquals(b, null) && ReferenceEquals(a, null);
            }

            return a.typeID == b.typeID;
        }
        public static bool operator!= (TileType a, TileType b)
        {
            return !(a.typeID == b.typeID);
        }

    }

    public struct TileNeighborhood
    {
        public TileType north;
        public TileType east;
        public TileType west;
        public TileType south;
        public TileType center;
        public TileType northeast;
        public TileType northwest;
        public TileType southeast;
        public TileType southwest;
    }

}


